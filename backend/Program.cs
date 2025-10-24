using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend.Models;
using backend.DTOs;
using backend.Helpers;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure database based on connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=mini-pm.db";
if (connectionString.Contains("Host=") || connectionString.Contains("Server="))
{
    // PostgreSQL connection
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseNpgsql(connectionString));
}
else
{
    // SQLite connection
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlite(connectionString));
}

builder.Services.AddScoped<SmartSchedulerService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
                "http://localhost:3000", // Development
                "https://your-frontend-url.vercel.app", // Vercel
                "https://your-frontend-url.netlify.app"  // Netlify
              )
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});
var jwtKey = builder.Configuration["Jwt:Key"] ?? "change_this_super_secret_key";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "mini-pm";
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
builder.Services.AddAuthorization();
var app = builder.Build();

// Auto-apply EF migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger(); 
app.UseSwaggerUI();

// Configure CORS
app.UseCors("AllowFrontend");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapPost("/api/auth/register", async (AppDbContext db, UserRegisterDto dto) => {
    if (await db.Users.AnyAsync(u => u.Email == dto.Email)) return Results.BadRequest(new { error = "Email exists" });
    var user = new User { Email = dto.Email, PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) };
    db.Users.Add(user); await db.SaveChangesAsync();
    return Results.Ok(new { id = user.Id, email = user.Email });
});

app.MapPost("/api/auth/login", async (AppDbContext db, UserLoginDto dto) => {
    var user = await db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
    if (user == null) return Results.Unauthorized();
    if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)) return Results.Unauthorized();
    var token = JwtHelpers.GenerateToken(user, jwtKey, jwtIssuer);
    return Results.Ok(new { token, user = new { id = user.Id, email = user.Email } });
});

app.MapGet("/api/projects", async (AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var list = await db.Projects.Where(p => p.OwnerId == uid)
                .Select(p => new { p.Id, p.Title, p.Description, p.CreatedAt })
                .ToListAsync();
    return Results.Ok(list);
}).RequireAuthorization();

app.MapPost("/api/projects", async (AppDbContext db, ProjectCreateDto dto, HttpContext http) => {
    var uid = http.GetUserId();
    var p = new Project { Title = dto.Title, Description = dto.Description, OwnerId = uid, CreatedAt = DateTime.UtcNow };
    db.Projects.Add(p); await db.SaveChangesAsync();
    return Results.Created($"/api/projects/{p.Id}", new { p.Id, p.Title, p.Description, p.CreatedAt });
}).RequireAuthorization();

app.MapGet("/api/projects/{id}", async (int id, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var p = await db.Projects.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == id && x.OwnerId == uid);
    if (p == null) return Results.NotFound();
    var resp = new {
        p.Id, p.Title, p.Description, p.CreatedAt,
        tasks = p.Tasks.Select(t => new { t.Id, t.Title, t.DueDate, t.IsCompleted })
    };
    return Results.Ok(resp);
}).RequireAuthorization();

app.MapDelete("/api/projects/{id}", async (int id, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var p = await db.Projects.FirstOrDefaultAsync(x => x.Id == id && x.OwnerId == uid);
    if (p == null) return Results.NotFound();
    db.Projects.Remove(p); await db.SaveChangesAsync();
    return Results.NoContent();
}).RequireAuthorization();

app.MapPost("/api/projects/{projectId}/tasks", async (int projectId, TaskCreateDto dto, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var proj = await db.Projects.FirstOrDefaultAsync(p => p.Id == projectId && p.OwnerId == uid);
    if (proj == null) return Results.NotFound();
    var t = new TaskItem { Title = dto.Title, DueDate = dto.DueDate, IsCompleted = false, ProjectId = projectId };
    db.Tasks.Add(t); await db.SaveChangesAsync();
    return Results.Created($"/api/projects/{projectId}/tasks/{t.Id}", new { t.Id, t.Title, t.DueDate, t.IsCompleted });
}).RequireAuthorization();

app.MapPut("/api/tasks/{id}", async (int id, TaskUpdateDto dto, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var task = await db.Tasks.Include(t => t.Project).FirstOrDefaultAsync(t => t.Id == id && t.Project.OwnerId == uid);
    if (task == null) return Results.NotFound();
    if (dto.Title != null) task.Title = dto.Title;
    if (dto.DueDate.HasValue) task.DueDate = dto.DueDate;
    if (dto.IsCompleted.HasValue) task.IsCompleted = dto.IsCompleted.Value;
    await db.SaveChangesAsync();
    return Results.Ok(new { task.Id, task.Title, task.DueDate, task.IsCompleted });
}).RequireAuthorization();

app.MapDelete("/api/tasks/{id}", async (int id, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var task = await db.Tasks.Include(t => t.Project).FirstOrDefaultAsync(t => t.Id == id && t.Project.OwnerId == uid);
    if (task == null) return Results.NotFound();
    db.Tasks.Remove(task); await db.SaveChangesAsync();
    return Results.NoContent();
}).RequireAuthorization();

app.MapPost("/api/v1/projects/{projectId}/schedule", async (int projectId, ScheduleRequestDto dto, SmartSchedulerService scheduler, AppDbContext db, HttpContext http) => {
    var uid = http.GetUserId();
    var project = await db.Projects.FirstOrDefaultAsync(p => p.Id == projectId && p.OwnerId == uid);
    if (project == null) return Results.NotFound();
    
    try {
        var response = scheduler.GenerateSchedule(dto);
        return Results.Ok(response);
    } catch (InvalidOperationException ex) {
        return Results.BadRequest(new { error = ex.Message });
    }
}).RequireAuthorization();

app.Run();

static class HttpContextExtensions {
    public static int GetUserId(this HttpContext http) {
        var idClaim = http.User.FindFirst("id") ?? http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        return int.Parse(idClaim?.Value ?? "0");
    }
}

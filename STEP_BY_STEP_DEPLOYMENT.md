# 🚀 **Step-by-Step Deployment Guide**

## ✅ **PART A COMPLETED - Repository is Deployment-Ready**

### **Files Created/Updated:**
- ✅ `global.json` - Pins .NET 8.0.121
- ✅ `backend/Dockerfile` - Multi-stage Docker build
- ✅ `backend/Program.cs` - Auto-migration + CORS + PostgreSQL support
- ✅ `backend/backend.csproj` - Added PostgreSQL package
- ✅ `.gitignore` - Updated for deployment
- ✅ Code committed and ready for push

---

## 🎯 **PART B - Deploy Backend to Render**

### **Step 1: Push to GitHub**
```bash
# Add your GitHub remote (replace YOUR_USERNAME)
git remote add origin https://github.com/YOUR_USERNAME/mini-pm.git
git branch -M main
git push -u origin main
```

### **Step 2: Create PostgreSQL Database on Render**
1. Go to [render.com](https://render.com)
2. Sign up/Login with GitHub
3. Click **"New +"** → **"Postgres"**
4. Configure:
   - **Name**: `mini-pm-db`
   - **Plan**: Choose plan (Starter is fine)
   - **Region**: Choose closest to you
5. Click **"Create Database"**
6. Once created, go to the database page
7. Click **"Connection Details"** → Copy the connection string
8. Convert to .NET format:
   ```
   Host=<host>;Port=5432;Database=<database>;Username=<username>;Password=<password>;Include Error Detail=true
   ```

### **Step 3: Create Web Service on Render**
1. Go to Render Dashboard
2. Click **"New +"** → **"Web Service"**
3. Connect your GitHub repository
4. Choose branch: `main`
5. Configure:
   - **Name**: `mini-pm-backend`
   - **Environment**: `Docker`
   - **Dockerfile Path**: `backend/Dockerfile`
   - **Plan**: Choose plan (Starter is fine)
6. Click **"Create Web Service"**

### **Step 4: Set Environment Variables**
In your Render service settings → **Environment** tab, add:

```
Jwt__Key = your-super-secret-jwt-key-at-least-32-characters-long
Jwt__Issuer = mini-pm
ConnectionStrings__DefaultConnection = Host=<host>;Port=5432;Database=<database>;Username=<username>;Password=<password>;Include Error Detail=true
ASPNETCORE_ENVIRONMENT = Production
```

### **Step 5: Deploy and Test**
1. Render will automatically build and deploy
2. Watch the **Build Logs** for any errors
3. Once deployed, test your backend:
   - **Swagger UI**: `https://your-service-name.onrender.com/swagger`
   - **Health Check**: `https://your-service-name.onrender.com/api/projects`

### **Step 6: Test API Endpoints**
```bash
# Register a user
curl -X POST https://your-service-name.onrender.com/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Password1!"}'

# Login (get token)
curl -X POST https://your-service-name.onrender.com/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Password1!"}'
```

---

## 🎨 **PART C - Deploy Frontend to Vercel**

### **Step 1: Prepare Frontend**
1. Update `frontend/src/services/api.ts` (already done)
2. Create `.env.local` in frontend directory:
   ```
   REACT_APP_API_URL=https://your-service-name.onrender.com/api
   REACT_APP_ENVIRONMENT=production
   ```

### **Step 2: Deploy to Vercel**
1. Go to [vercel.com](https://vercel.com)
2. Sign up/Login with GitHub
3. Click **"New Project"**
4. Import your GitHub repository
5. Configure:
   - **Framework Preset**: `Create React App`
   - **Root Directory**: `frontend`
   - **Build Command**: `npm run build`
   - **Output Directory**: `build`
6. Set Environment Variables:
   - `REACT_APP_API_URL` = `https://your-service-name.onrender.com/api`
   - `REACT_APP_ENVIRONMENT` = `production`
7. Click **"Deploy"**

### **Step 3: Update CORS in Backend**
After getting your Vercel URL, update the backend CORS:
1. Go to your Render service
2. Update environment variables:
   - Add your Vercel URL to the CORS origins in `Program.cs`
3. Redeploy the backend

---

## 🔧 **PART D - Configure CORS & Production Tweaks**

### **Update CORS in Program.cs**
Replace the CORS origins in `backend/Program.cs`:
```csharp
policy.WithOrigins(
    "http://localhost:3000", // Development
    "https://your-frontend-url.vercel.app", // Your actual Vercel URL
    "https://your-frontend-url.netlify.app"  // If using Netlify
)
```

### **Redeploy Backend**
```bash
git add backend/Program.cs
git commit -m "Update CORS for production frontend URL"
git push
```

---

## 🧪 **PART E - Test Complete Application**

### **Test Full Flow**
1. **Open Frontend**: Visit your Vercel URL
2. **Register**: Create a new user account
3. **Login**: Sign in with your credentials
4. **Create Project**: Add a new project
5. **Add Tasks**: Create tasks within the project
6. **Test Smart Scheduler**: Use the AI-powered scheduling feature

### **Common Issues & Fixes**

#### **Build Fails on Render**
- Check that `global.json` targets 8.x
- Verify Dockerfile uses correct .NET 8 images
- Check build logs for specific errors

#### **Database Connection Issues**
- Verify PostgreSQL connection string format
- Check environment variables are set correctly
- Ensure database is accessible from Render

#### **CORS Errors**
- Update CORS origins in backend
- Ensure frontend URL is correct
- Check that both services use HTTPS

#### **Frontend Can't Reach Backend**
- Verify `REACT_APP_API_URL` is correct
- Check backend is running and accessible
- Ensure both services use HTTPS

---

## 🎉 **Deployment Complete!**

### **Your URLs:**
- **Backend API**: `https://your-service-name.onrender.com`
- **API Documentation**: `https://your-service-name.onrender.com/swagger`
- **Frontend**: `https://your-frontend-url.vercel.app`

### **Features Available:**
- ✅ User Authentication (JWT)
- ✅ Project Management
- ✅ Task Management
- ✅ Smart Scheduler (AI-powered)
- ✅ Responsive UI
- ✅ Production-ready deployment

**Your Mini Project Manager is now live and ready for users! 🚀**

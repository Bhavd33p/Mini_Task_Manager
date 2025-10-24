# ✅ **Deployment Checklist - Mini Project Manager**

## **PART A - Repository Preparation** ✅ COMPLETED
- [x] `global.json` created (pins .NET 8.0.121)
- [x] `backend/Dockerfile` created (multi-stage build)
- [x] `backend/Program.cs` updated (auto-migration + CORS + PostgreSQL)
- [x] `backend/backend.csproj` updated (PostgreSQL package added)
- [x] `.gitignore` updated
- [x] Code committed to Git

## **PART B - Backend Deployment (Render)**
- [ ] Push code to GitHub
- [ ] Create PostgreSQL database on Render
- [ ] Create Web Service on Render
- [ ] Set environment variables:
  - [ ] `Jwt__Key` (32+ characters)
  - [ ] `Jwt__Issuer` = `mini-pm`
  - [ ] `ConnectionStrings__DefaultConnection` (PostgreSQL)
  - [ ] `ASPNETCORE_ENVIRONMENT` = `Production`
- [ ] Deploy and test backend
- [ ] Test API endpoints with curl
- [ ] Note backend URL for frontend

## **PART C - Frontend Deployment (Vercel)**
- [ ] Create `.env.local` in frontend with backend URL
- [ ] Deploy to Vercel
- [ ] Set environment variables:
  - [ ] `REACT_APP_API_URL` = backend URL
  - [ ] `REACT_APP_ENVIRONMENT` = `production`
- [ ] Deploy and test frontend
- [ ] Note frontend URL for CORS update

## **PART D - CORS Configuration**
- [ ] Update CORS origins in `backend/Program.cs`
- [ ] Add frontend URL to allowed origins
- [ ] Commit and push changes
- [ ] Redeploy backend

## **PART E - Final Testing**
- [ ] Test user registration
- [ ] Test user login
- [ ] Test project creation
- [ ] Test task management
- [ ] Test Smart Scheduler
- [ ] Test on mobile devices
- [ ] Verify HTTPS is working

## **Quick Commands**

### **Push to GitHub**
```bash
git remote add origin https://github.com/YOUR_USERNAME/mini-pm.git
git push -u origin main
```

### **Test Backend**
```bash
curl https://your-backend-url.onrender.com/swagger
```

### **Test API**
```bash
curl -X POST https://your-backend-url.onrender.com/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"Password1!"}'
```

## **Environment Variables Reference**

### **Backend (Render)**
```
Jwt__Key = your-super-secret-jwt-key-at-least-32-characters-long
Jwt__Issuer = mini-pm
ConnectionStrings__DefaultConnection = Host=<host>;Port=5432;Database=<database>;Username=<username>;Password=<password>;Include Error Detail=true
ASPNETCORE_ENVIRONMENT = Production
```

### **Frontend (Vercel)**
```
REACT_APP_API_URL = https://your-backend-url.onrender.com/api
REACT_APP_ENVIRONMENT = production
```

## **Expected URLs**
- **Backend**: `https://mini-pm-backend.onrender.com`
- **API Docs**: `https://mini-pm-backend.onrender.com/swagger`
- **Frontend**: `https://mini-pm-frontend.vercel.app`

## **Troubleshooting**
- **Build fails**: Check .NET version and Dockerfile
- **Database issues**: Verify PostgreSQL connection string
- **CORS errors**: Update allowed origins in backend
- **Frontend can't reach backend**: Check API URL and HTTPS

**Ready to deploy! Follow the checklist step by step. 🚀**

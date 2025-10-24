# 🚀 **Deployment Guide - Mini Project Manager**

This guide will help you deploy your Mini Project Manager application to production platforms.

## 📋 **Deployment Overview**

- **Backend**: Deploy to Render or Railway
- **Frontend**: Deploy to Vercel or Netlify
- **Database**: SQLite (included with backend)

## 🔧 **Backend Deployment**

### **Option 1: Render (Recommended)**

1. **Push to GitHub**
   ```bash
   git add .
   git commit -m "Add deployment configurations"
   git push origin main
   ```

2. **Deploy to Render**
   - Go to [render.com](https://render.com)
   - Sign up/Login with GitHub
   - Click "New +" → "Web Service"
   - Connect your GitHub repository
   - Select your repository
   - Configure settings:
     - **Name**: `mini-pm-backend`
     - **Environment**: `Docker`
     - **Build Command**: `cd backend && dotnet publish -c Release -o ./publish`
     - **Start Command**: `cd backend && dotnet ./publish/backend.dll`
     - **Instance Type**: `Free`

3. **Set Environment Variables**
   - `ASPNETCORE_ENVIRONMENT` = `Production`
   - `JWT_SECRET` = `your-super-secret-jwt-key-here`
   - `JWT_EXPIRY_DAYS` = `7`
   - `CONNECTION_STRING` = `Data Source=data.db`

4. **Deploy**
   - Click "Create Web Service"
   - Wait for deployment to complete
   - Note your backend URL (e.g., `https://mini-pm-backend.onrender.com`)

### **Option 2: Railway**

1. **Deploy to Railway**
   - Go to [railway.app](https://railway.app)
   - Sign up/Login with GitHub
   - Click "New Project" → "Deploy from GitHub repo"
   - Select your repository
   - Railway will auto-detect .NET project

2. **Set Environment Variables**
   - Go to your project → Variables tab
   - Add the same environment variables as Render

3. **Deploy**
   - Railway will automatically build and deploy
   - Note your backend URL

## 🎨 **Frontend Deployment**

### **Option 1: Vercel (Recommended)**

1. **Deploy to Vercel**
   - Go to [vercel.com](https://vercel.com)
   - Sign up/Login with GitHub
   - Click "New Project"
   - Import your GitHub repository
   - Configure settings:
     - **Framework Preset**: `Create React App`
     - **Root Directory**: `frontend`
     - **Build Command**: `npm run build`
     - **Output Directory**: `build`

2. **Set Environment Variables**
   - Go to Project Settings → Environment Variables
   - Add:
     - `REACT_APP_API_URL` = `https://your-backend-url.onrender.com/api/v1`
     - `REACT_APP_ENVIRONMENT` = `production`

3. **Deploy**
   - Click "Deploy"
   - Wait for deployment to complete
   - Note your frontend URL

### **Option 2: Netlify**

1. **Deploy to Netlify**
   - Go to [netlify.com](https://netlify.com)
   - Sign up/Login with GitHub
   - Click "New site from Git"
   - Connect your GitHub repository
   - Configure settings:
     - **Base directory**: `frontend`
     - **Build command**: `npm run build`
     - **Publish directory**: `build`

2. **Set Environment Variables**
   - Go to Site Settings → Environment Variables
   - Add the same environment variables as Vercel

3. **Deploy**
   - Click "Deploy site"
   - Wait for deployment to complete

## 🔄 **Update Frontend API URL**

After deploying the backend, update the frontend's API URL:

1. **Update Vercel/Netlify Environment Variables**
   - Replace `your-backend-url.onrender.com` with your actual backend URL

2. **Update Local Files**
   ```bash
   # Update frontend/env.production
   REACT_APP_API_URL=https://your-actual-backend-url.onrender.com/api/v1
   ```

3. **Redeploy Frontend**
   - Push changes to trigger automatic redeployment

## 🧪 **Testing Deployment**

### **Test Backend**
```bash
# Test API health
curl https://your-backend-url.onrender.com/swagger

# Test API endpoints
curl https://your-backend-url.onrender.com/api/v1/projects
```

### **Test Frontend**
1. Visit your frontend URL
2. Try to register a new user
3. Create a project
4. Add tasks
5. Test Smart Scheduler

## 🔧 **Troubleshooting**

### **Backend Issues**
- **Build Fails**: Check .NET 8 SDK is available
- **Database Issues**: Ensure SQLite is properly configured
- **CORS Issues**: Update CORS settings in `appsettings.Production.json`

### **Frontend Issues**
- **API Connection**: Verify `REACT_APP_API_URL` is correct
- **Build Fails**: Check Node.js version and dependencies
- **Environment Variables**: Ensure they're set correctly

## 📊 **Monitoring**

### **Render**
- Check deployment logs in Render dashboard
- Monitor resource usage
- Set up alerts for downtime

### **Vercel/Netlify**
- Check deployment logs
- Monitor build times
- Set up custom domains if needed

## 🔒 **Security Considerations**

1. **JWT Secret**: Use a strong, unique secret key
2. **CORS**: Configure allowed origins properly
3. **Environment Variables**: Never commit secrets to Git
4. **HTTPS**: All production URLs should use HTTPS

## 📈 **Scaling**

### **Backend Scaling**
- **Render**: Upgrade to paid plan for better performance
- **Railway**: Use Railway's scaling features
- **Database**: Consider PostgreSQL for production

### **Frontend Scaling**
- **CDN**: Vercel/Netlify provide global CDN
- **Caching**: Configure proper caching headers
- **Performance**: Monitor Core Web Vitals

## 🎯 **Next Steps**

1. **Custom Domain**: Set up custom domain for both frontend and backend
2. **SSL Certificates**: Ensure HTTPS is properly configured
3. **Monitoring**: Set up application monitoring (e.g., Sentry)
4. **CI/CD**: Configure automatic deployments on Git push
5. **Database Backup**: Set up regular database backups

## 📞 **Support**

- **Render**: [Render Documentation](https://render.com/docs)
- **Railway**: [Railway Documentation](https://docs.railway.app)
- **Vercel**: [Vercel Documentation](https://vercel.com/docs)
- **Netlify**: [Netlify Documentation](https://docs.netlify.com)

---

**🎉 Your Mini Project Manager is now deployed and ready for production use!**

# 🔧 **Port Conflict Resolution Guide**

## 🚨 **The Problem**
```
System.IO.IOException: Failed to bind to address http://127.0.0.1:5127: address already in use.
```

This error occurs when:
- A previous backend instance is still running on port 5127
- Multiple attempts to start the backend without properly stopping the previous instance
- Background processes holding onto the port

## ✅ **Solution Applied**

### **Step 1: Kill Existing Processes**
```bash
lsof -ti:5127 | xargs kill -9
```

### **Step 2: Verify Port is Free**
```bash
lsof -ti:5127
# Should return nothing if port is free
```

### **Step 3: Start Backend with Correct .NET 8**
```bash
export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"
export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"
cd backend
dotnet run
```

## 🎯 **Current Status: RESOLVED**

- ✅ **Port 5127**: Now free and available
- ✅ **Backend**: Running successfully on http://localhost:5127
- ✅ **Frontend**: Running successfully on http://localhost:3000
- ✅ **API Documentation**: Available at http://localhost:5127/swagger

## 🛠️ **Prevention Tips**

### **Always Use the Startup Script**
```bash
./start-backend-dotnet8.sh
```

### **Manual Process Management**
```bash
# Check what's using port 5127
lsof -ti:5127

# Kill processes on port 5127
lsof -ti:5127 | xargs kill -9

# Check what's using port 3000
lsof -ti:3000

# Kill processes on port 3000
lsof -ti:3000 | xargs kill -9
```

### **Proper Shutdown**
- Use `Ctrl+C` to stop the backend gracefully
- Always check for running processes before restarting
- Use the startup script to avoid environment issues

## 🚀 **Quick Commands**

### **Kill All Port Conflicts**
```bash
lsof -ti:5127 | xargs kill -9
lsof -ti:3000 | xargs kill -9
```

### **Start Backend Safely**
```bash
export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"
export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"
cd backend && dotnet run
```

### **Start Frontend Safely**
```bash
cd frontend && npm start
```

## 📊 **Verification Commands**

### **Check Backend Status**
```bash
curl -s http://localhost:5127/swagger/index.html | head -3
```

### **Check Frontend Status**
```bash
curl -s http://localhost:3000 | head -3
```

### **Check Port Usage**
```bash
lsof -i:5127
lsof -i:3000
```

## 🎉 **Result**

Your Mini Project Manager is now running successfully:
- **Backend**: http://localhost:5127 ✅
- **Frontend**: http://localhost:3000 ✅
- **API Docs**: http://localhost:5127/swagger ✅

**The port conflict has been resolved and both services are operational!**

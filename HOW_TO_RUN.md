# How to Run the Mini Project Manager

## ✅ Project is Currently Running!

Both servers are running and accessible:

### Backend Server
- **URL**: http://localhost:5000
- **Swagger API Documentation**: http://localhost:5000/swagger/index.html
- **Status**: ✅ Running

### Frontend Application
- **URL**: http://localhost:3000
- **Status**: ✅ Running

### ✅ Issues Fixed:
- Removed Tailwind CSS dependency conflicts
- Replaced with custom CSS utility classes
- All styling preserved and working
- TypeScript errors resolved

## Quick Start

1. **Open your browser** and go to: http://localhost:3000
2. **Register a new account** or login with existing credentials
3. **Create projects** and manage tasks
4. **Try the Smart Scheduler** feature for automatic task planning

## API Testing

You can test the API directly using Swagger UI:
- Go to: http://localhost:5000/swagger/index.html
- Try the authentication endpoints first
- Test the Smart Scheduler API at `/api/v1/projects/{projectId}/schedule`

## Features Available

### Core Features
- ✅ User Registration & Login
- ✅ Project Management (Create, Read, Delete)
- ✅ Task Management (Create, Update, Delete, Complete)
- ✅ JWT Authentication
- ✅ Responsive Design

### Smart Scheduler (NEW!)
- ✅ Automatic task dependency analysis
- ✅ Optimal task ordering algorithm
- ✅ Circular dependency detection
- ✅ Visual workflow recommendations

## Troubleshooting

If you need to restart the servers:

### Backend
```bash
cd backend
dotnet run --urls "http://localhost:5000"
```

### Frontend
```bash
cd frontend
npm start
```

## Example Smart Scheduler Usage

1. Create a project
2. Go to project details
3. Click "Smart Scheduler" button
4. Add tasks with dependencies like:
   - Task: "Design API" (no dependencies)
   - Task: "Implement Backend" (depends on "Design API")
   - Task: "Build Frontend" (depends on "Design API")
   - Task: "End-to-End Test" (depends on "Implement Backend", "Build Frontend")
5. Click "Generate Schedule" to see the optimal order

The system will automatically determine the best execution sequence!

## Database

The application uses SQLite database (`mini-pm.db`) which is automatically created in the backend directory.

---

**🎉 Your Mini Project Manager with Smart Scheduler is ready to use!**

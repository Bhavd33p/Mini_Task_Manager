# 🚀 Mini Project Manager

A full-stack project management application built with **.NET 8** backend and **React** frontend, featuring AI-powered Smart Scheduler, user authentication, and modern black & white UI.

![.NET](https://img.shields.io/badge/.NET-8.0-purple) ![React](https://img.shields.io/badge/React-18.2.0-blue) ![TypeScript](https://img.shields.io/badge/TypeScript-4.9.5-blue) ![SQLite](https://img.shields.io/badge/SQLite-3.0-lightblue) ![License](https://img.shields.io/badge/License-MIT-green)

## ✨ Features

### 🔐 Authentication & Security
- User registration and login
- JWT token-based authentication
- Password hashing with BCrypt
- Protected routes and API endpoints

### 📋 Project Management
- Create, edit, and delete projects
- Project ownership and permissions
- Project descriptions and metadata
- Real-time project updates

### ✅ Task Management
- Create and manage tasks within projects
- Mark tasks as complete/incomplete
- Task due dates and descriptions
- Task dependencies and relationships

### 🧠 Smart Scheduler (AI-Powered)
- AI-powered task scheduling algorithm
- Dependency resolution using topological sorting
- Optimal timeline generation
- Resource allocation optimization
- Conflict detection and resolution

### 🎨 Modern UI/UX
- Responsive black & white theme
- Mobile-friendly design
- Loading indicators and user feedback
- Intuitive navigation and interactions

## 🏗️ Architecture

### Backend (.NET 8)
- **Framework:** ASP.NET Core Web API
- **Database:** SQLite with Entity Framework Core
- **Authentication:** JWT Bearer tokens
- **API:** RESTful endpoints with Swagger documentation
- **Algorithm:** Topological sorting for Smart Scheduler

### Frontend (React)
- **Framework:** React 18 with TypeScript
- **State Management:** Context API
- **HTTP Client:** Axios
- **Routing:** React Router
- **Styling:** Custom CSS with responsive design

## 🚀 Quick Start

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- [Git](https://git-scm.com/)

### Local Development

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/mini-pm.git
   cd mini-pm
Start Backend

# Use the startup script (recommended)
./start-backend-dotnet8.sh

# Or manually
export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"
export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"
cd backend && dotnet run


Start Frontend

cd frontend
npm install
npm start


Access the Application

Frontend: http://localhost:3000

Backend API: http://localhost:5127

API Documentation: http://localhost:5127/swagger

📚 API Documentation
Authentication Endpoints

POST /api/v1/auth/register - User registration

POST /api/v1/auth/login - User login

Project Endpoints

GET /api/v1/projects - Get user's projects

POST /api/v1/projects - Create new project

GET /api/v1/projects/{id} - Get project details

PUT /api/v1/projects/{id} - Update project

DELETE /api/v1/projects/{id} - Delete project

Task Endpoints

GET /api/v1/projects/{id}/tasks - Get project tasks

POST /api/v1/projects/{id}/tasks - Create new task

PUT /api/v1/tasks/{id} - Update task

DELETE /api/v1/tasks/{id} - Delete task

Smart Scheduler Endpoint

POST /api/v1/projects/{id}/schedule - Generate optimal schedule

📁 Project Structure
mini-pm/
├── backend/                 # .NET 8 Web API
│   ├── Controllers/         # API Controllers
│   ├── Models/              # Database Models
│   ├── DTOs/                # Data Transfer Objects
│   ├── Services/            # Business Logic
│   ├── Helpers/             # Utility Classes
│   ├── Program.cs           # Application Entry Point
│   └── backend.csproj       # Project File
├── frontend/                # React Application
│   ├── public/              # Static Assets
│   ├── src/
│   │   ├── components/      # React Components
│   │   ├── contexts/        # Context Providers
│   │   ├── services/        # API Services
│   │   ├── types/           # TypeScript Types
│   │   └── App.tsx          # Main App Component
│   └── package.json         # Dependencies
├── docs/                    # Documentation
├── scripts/                 # Deployment Scripts
└── README.md                # This File

🧪 Smart Scheduler Example
// Example API call for Smart Scheduler
const scheduleRequest = {
  tasks: [
    {
      id: 1,
      title: "Design Database",
      duration: 2,
      dependencies: []
    },
    {
      id: 2,
      title: "Implement API",
      duration: 5,
      dependencies: [1]
    },
    {
      id: 3,
      title: "Create Frontend",
      duration: 3,
      dependencies: [2]
    }
  ],
  startDate: "2024-01-01",
  workingHoursPerDay: 8
};

const response = await schedulerApi.generateSchedule(projectId, scheduleRequest);

🛠️ Development
Backend Development
cd backend
dotnet watch run  # Hot reload development
dotnet test       # Run tests
dotnet build      # Build project

Frontend Development
cd frontend
npm start         # Development server
npm test          # Run tests
npm run build     # Production build

📊 Performance

Backend: Optimized with .NET 8 performance improvements

Database: SQLite for fast local development

Frontend: React 18 with concurrent features

API: RESTful design with efficient data transfer

🔒 Security

JWT token authentication

Password hashing with BCrypt

CORS configuration

Input validation and sanitization

SQL injection protection with Entity Framework

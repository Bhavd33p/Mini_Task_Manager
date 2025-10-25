# 🚀 Mini Project Manager

A modern, full-stack project management application with intelligent task scheduling capabilities. Built with ASP.NET Core Web API backend and React TypeScript frontend.

## ✨ Features

### 🔐 Authentication & User Management
- **Secure JWT Authentication** - Token-based authentication with secure password hashing
- **User Registration & Login** - Complete user management system
- **Protected Routes** - Secure access to authenticated features

### 📋 Project Management
- **Create & Manage Projects** - Organize your work into projects
- **Project Details** - View project information and associated tasks
- **Delete Projects** - Remove projects when no longer needed

### ✅ Task Management
- **Create Tasks** - Add tasks to projects with titles and due dates
- **Mark Complete** - Toggle task completion status
- **Delete Tasks** - Remove tasks from projects
- **Due Date Tracking** - Visual indicators for overdue tasks

### 🧠 Smart Scheduler (AI-Powered)
- **Dependency Management** - Define task dependencies and estimated hours
- **Topological Sorting** - Automatically calculates optimal task execution order
- **Workflow Optimization** - Minimizes project completion time
- **Visual Task Flow** - Clear step-by-step execution plan

### 🎨 Modern UI/UX
- **Black & White Theme** - Clean, professional monochrome design
- **Responsive Design** - Works perfectly on desktop, tablet, and mobile
- **Glass Morphism Effects** - Modern UI with backdrop blur effects
- **Smooth Animations** - Engaging micro-interactions and transitions
- **Loading States** - Beautiful loading spinners and feedback
- **Accessibility** - WCAG compliant with proper focus management

## 🏗️ Architecture

### Backend (ASP.NET Core Web API)
```
backend/
├── Controllers/          # API Controllers
├── Models/              # Entity Framework Models
├── DTOs/                # Data Transfer Objects
├── Services/            # Business Logic Services
├── Helpers/             # Utility Classes
└── Program.cs           # Application Entry Point
```

**Key Technologies:**
- **.NET 7** - Modern C# framework
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Lightweight database
- **JWT Authentication** - Secure token-based auth
- **BCrypt** - Password hashing
- **Topological Sorting** - Smart scheduling algorithm

### Frontend (React TypeScript)
```
frontend/
├── src/
│   ├── components/      # React Components
│   ├── contexts/        # React Context (Auth)
│   ├── services/        # API Service Layer
│   ├── types/           # TypeScript Interfaces
│   └── App.tsx          # Main Application
└── public/              # Static Assets
```

**Key Technologies:**
- **React 18** - Modern React with hooks
- **TypeScript** - Type-safe JavaScript
- **React Router** - Client-side routing
- **Axios** - HTTP client for API calls
- **Context API** - State management
- **Custom CSS** - Modern styling with animations

## 🚀 Quick Start

### Prerequisites
- **.NET 7 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/7.0)
- **Node.js 16+** - [Download here](https://nodejs.org/)
- **npm** - Comes with Node.js

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd mini-pm
   ```

2. **Backend Setup**
   ```bash
   cd backend
   dotnet restore
   dotnet run
   ```
   Backend will be available at: `http://localhost:5127`

3. **Frontend Setup**
   ```bash
   cd frontend
   npm install
   npm start
   ```
   Frontend will be available at: `http://localhost:3000`

### Using the Application

1. **Register** a new account or **Login** with existing credentials
2. **Create Projects** to organize your work
3. **Add Tasks** to projects with due dates
4. **Use Smart Scheduler** to optimize task execution order
5. **Track Progress** by marking tasks as complete

## 🔧 API Endpoints

### Authentication
- `POST /api/v1/auth/register` - User registration
- `POST /api/v1/auth/login` - User login

### Projects
- `GET /api/v1/projects` - Get user's projects
- `POST /api/v1/projects` - Create new project
- `GET /api/v1/projects/{id}` - Get project details
- `DELETE /api/v1/projects/{id}` - Delete project

### Tasks
- `POST /api/v1/projects/{projectId}/tasks` - Create task
- `PUT /api/v1/tasks/{id}` - Update task
- `DELETE /api/v1/tasks/{id}` - Delete task

### Smart Scheduler
- `POST /api/v1/projects/{projectId}/schedule` - Generate optimized schedule

## 🧠 Smart Scheduler Algorithm

The Smart Scheduler uses **Topological Sorting (Kahn's Algorithm)** to:

1. **Analyze Dependencies** - Maps task relationships
2. **Calculate Critical Path** - Identifies longest dependency chain
3. **Optimize Order** - Minimizes total project completion time
4. **Handle Cycles** - Detects and reports circular dependencies
5. **Generate Schedule** - Provides step-by-step execution plan

### Example Usage
```json
{
  "tasks": [
    {
      "title": "Design Database",
      "estimatedHours": 4,
      "dependencies": []
    },
    {
      "title": "Create API",
      "estimatedHours": 8,
      "dependencies": ["Design Database"]
    },
    {
      "title": "Build Frontend",
      "estimatedHours": 12,
      "dependencies": ["Create API"]
    }
  ]
}
```

## 🎨 UI/UX Features

### Design System
- **Monochrome Palette** - Black, white, and gray tones
- **Typography** - System fonts with proper hierarchy
- **Spacing** - Consistent 8px grid system
- **Shadows** - Subtle depth and elevation
- **Borders** - Clean, minimal borders

### Responsive Breakpoints
- **Mobile**: < 640px
- **Tablet**: 640px - 1024px
- **Desktop**: > 1024px

### Interactive Elements
- **Hover Effects** - Smooth color transitions
- **Focus States** - Accessibility-compliant focus indicators
- **Loading States** - Spinner animations
- **Form Validation** - Real-time error feedback

## 🔒 Security Features

- **JWT Tokens** - Secure authentication
- **Password Hashing** - BCrypt encryption
- **CORS Configuration** - Cross-origin request handling
- **Input Validation** - Server-side validation
- **SQL Injection Protection** - Entity Framework parameterized queries

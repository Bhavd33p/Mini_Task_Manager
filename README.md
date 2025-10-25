🚀 Mini Project Manager

A full-stack project management system built with .NET 8 (backend) and React + TypeScript (frontend).
It includes secure authentication, project & task management, and an AI-powered Smart Scheduler.

✨ Features
🔐 Authentication

User registration and login

JWT-based authentication

Password hashing (BCrypt)

📋 Projects

Create, update, and delete projects

User-specific access and permissions

✅ Tasks

Manage tasks within projects

Track completion status and due dates

Task dependencies

🧠 Smart Scheduler

AI-based scheduling using topological sorting

Automatically resolves task dependencies

Generates optimal project timelines

🎨 UI

Modern black & white theme

Responsive and mobile-friendly

🏗️ Tech Stack
Layer	Technology
Backend	ASP.NET Core 8 Web API
Database	SQLite + Entity Framework Core
Frontend	React 18 + TypeScript
Auth	JWT Bearer Tokens
Algorithm	Topological Sorting (Smart Scheduler)
⚙️ Setup Instructions
Prerequisites

.NET 8 SDK

Node.js 18 or later

Git

Steps

Clone Repository

git clone https://github.com/yourusername/mini-pm.git
cd mini-pm


Run Backend

cd backend
dotnet run


Backend runs at http://localhost:5127

Run Frontend

cd frontend
npm install
npm start


Frontend runs at http://localhost:3000

🧩 API Overview
Category	Endpoint	Description
Auth	POST /api/v1/auth/register	Register user
	POST /api/v1/auth/login	Login user
Projects	GET /api/v1/projects	Get all projects
	POST /api/v1/projects	Create project
	PUT /api/v1/projects/{id}	Update project
	DELETE /api/v1/projects/{id}	Delete project
Tasks	GET /api/v1/projects/{id}/tasks	Get tasks
	POST /api/v1/projects/{id}/tasks	Create task
	PUT /api/v1/tasks/{id}	Update task
	DELETE /api/v1/tasks/{id}	Delete task
Scheduler	POST /api/v1/projects/{id}/schedule	Generate optimal schedule
📁 Folder Structure
mini-pm/
├── backend/              # .NET 8 Web API
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── Program.cs
├── frontend/             # React App
│   ├── src/
│   │   ├── components/
│   │   ├── contexts/
│   │   ├── services/
│   │   └── App.tsx
└── README.md

🧠 Example Smart Scheduler Request
{
  "tasks": [
    { "id": 1, "title": "Design DB", "duration": 2, "dependencies": [] },
    { "id": 2, "title": "Build API", "duration": 5, "dependencies": [1] },
    { "id": 3, "title": "Create UI", "duration": 3, "dependencies": [2] }
  ],
  "startDate": "2024-01-01",
  "workingHoursPerDay": 8
}

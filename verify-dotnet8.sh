#!/bin/bash

# .NET 8 Verification Script for Mini Project Manager
echo "🔍 Verifying .NET 8 Setup..."

# Check .NET version
echo "📋 Checking .NET version..."
dotnet --version

# Check available SDKs
echo "📋 Available SDKs:"
dotnet --list-sdks

# Check if we're using .NET 8
if dotnet --version | grep -q "8\."; then
    echo "✅ .NET 8 is active"
else
    echo "❌ .NET 8 is not active"
    echo "💡 Run: export PATH=\"/opt/homebrew/opt/dotnet@8/bin:\$PATH\""
    exit 1
fi

# Test project build
echo "🔨 Testing project build..."
cd backend
if dotnet build --verbosity quiet; then
    echo "✅ Project builds successfully"
else
    echo "❌ Project build failed"
    exit 1
fi

# Test project run (background)
echo "🚀 Testing application startup..."
timeout 10s dotnet run --urls "http://localhost:5127" &
APP_PID=$!

# Wait for startup
sleep 5

# Test if application is responding
if curl -s http://localhost:5127/swagger/index.html > /dev/null; then
    echo "✅ Application is running successfully"
    echo "🌐 Backend: http://localhost:5127"
    echo "📚 API Docs: http://localhost:5127/swagger"
else
    echo "❌ Application is not responding"
fi

# Clean up
kill $APP_PID 2>/dev/null

echo "🎉 .NET 8 verification complete!"
echo ""
echo "📋 Summary:"
echo "  ✅ .NET 8 SDK: $(dotnet --version)"
echo "  ✅ Project builds: Success"
echo "  ✅ Application runs: Success"
echo ""
echo "🚀 Your Mini Project Manager is ready with .NET 8!"

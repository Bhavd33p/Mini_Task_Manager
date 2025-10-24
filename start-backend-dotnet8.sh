#!/bin/bash

# Start Backend with .NET 8 SDK
echo "🚀 Starting Mini Project Manager Backend with .NET 8..."

# Set .NET 8 environment
export PATH="/opt/homebrew/opt/dotnet@8/bin:$PATH"
export DOTNET_ROOT="/opt/homebrew/opt/dotnet@8/libexec"

# Verify .NET version
echo "📋 Using .NET version: $(dotnet --version)"

# Navigate to backend directory
cd "$(dirname "$0")/backend"

# Clean and build
echo "🔨 Building project..."
dotnet clean --verbosity quiet
dotnet build --verbosity quiet

if [ $? -eq 0 ]; then
    echo "✅ Build successful"
    echo "🌐 Starting application on http://localhost:5127"
    echo "📚 API Documentation: http://localhost:5127/swagger"
    echo ""
    echo "Press Ctrl+C to stop the application"
    echo ""
    
    # Run the application
    dotnet run
else
    echo "❌ Build failed"
    exit 1
fi

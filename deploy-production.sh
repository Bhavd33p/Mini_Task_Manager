#!/bin/bash

echo "🚀 Deploying Mini Project Manager to Production..."

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Function to print colored output
print_status() {
    echo -e "${BLUE}[INFO]${NC} $1"
}

print_success() {
    echo -e "${GREEN}[SUCCESS]${NC} $1"
}

print_warning() {
    echo -e "${YELLOW}[WARNING]${NC} $1"
}

print_error() {
    echo -e "${RED}[ERROR]${NC} $1"
}

# Check if git is initialized
if [ ! -d ".git" ]; then
    print_error "Git repository not initialized. Please run 'git init' first."
    exit 1
fi

# Check if there are uncommitted changes
if [ -n "$(git status --porcelain)" ]; then
    print_warning "You have uncommitted changes. Committing them now..."
    git add .
    git commit -m "Deploy to production - $(date)"
fi

# Push to GitHub
print_status "Pushing to GitHub..."
git push origin main

if [ $? -eq 0 ]; then
    print_success "Code pushed to GitHub successfully!"
else
    print_error "Failed to push to GitHub. Please check your git configuration."
    exit 1
fi

# Display deployment instructions
echo ""
echo "🎯 Next Steps:"
echo ""
echo "1. Backend Deployment:"
echo "   - Go to https://render.com or https://railway.app"
echo "   - Connect your GitHub repository"
echo "   - Deploy the backend service"
echo "   - Note your backend URL (e.g., https://mini-pm-backend.onrender.com)"
echo ""
echo "2. Frontend Deployment:"
echo "   - Go to https://vercel.com or https://netlify.com"
echo "   - Connect your GitHub repository"
echo "   - Deploy the frontend service"
echo "   - Update environment variables with your backend URL"
echo ""
echo "3. Update API URL:"
echo "   - Update REACT_APP_API_URL in your frontend deployment"
echo "   - Update CORS settings in backend if needed"
echo ""
echo "📚 For detailed instructions, see DEPLOYMENT_GUIDE.md"
echo ""
print_success "Deployment preparation complete! 🎉"

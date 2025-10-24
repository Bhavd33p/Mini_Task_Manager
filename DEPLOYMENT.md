# 🚀 Deployment Guide

This guide covers different deployment options for the Mini Project Manager application.

## 📋 Prerequisites

- **Docker** and **Docker Compose** installed
- **Git** for version control
- **Domain name** (optional, for production)
- **SSL certificate** (for HTTPS in production)

## 🐳 Docker Deployment (Recommended)

### Quick Start
```bash
# Clone the repository
git clone <your-repository-url>
cd mini-pm

# Deploy with Docker Compose
./deploy.sh
```

### Manual Docker Deployment
```bash
# Build and start services
docker-compose up --build -d

# Check service status
docker-compose ps

# View logs
docker-compose logs -f
```

### Service URLs
- **Frontend**: http://localhost:3000
- **Backend API**: http://localhost:5000
- **API Documentation**: http://localhost:5000/swagger

## ☁️ Cloud Deployment Options

### 1. AWS Deployment

#### Using AWS ECS (Elastic Container Service)
```bash
# Build and push images to ECR
aws ecr create-repository --repository-name mini-pm-backend
aws ecr create-repository --repository-name mini-pm-frontend

# Tag and push images
docker tag mini-pm_backend:latest <account>.dkr.ecr.<region>.amazonaws.com/mini-pm-backend:latest
docker push <account>.dkr.ecr.<region>.amazonaws.com/mini-pm-backend:latest
```

#### Using AWS App Runner
1. Connect your GitHub repository
2. Configure build settings:
   - **Backend**: `Dockerfile.backend`
   - **Frontend**: `Dockerfile.frontend`
3. Set environment variables
4. Deploy automatically

### 2. Google Cloud Platform

#### Using Cloud Run
```bash
# Build and deploy backend
gcloud builds submit --tag gcr.io/<project-id>/mini-pm-backend
gcloud run deploy --image gcr.io/<project-id>/mini-pm-backend --platform managed

# Build and deploy frontend
gcloud builds submit --tag gcr.io/<project-id>/mini-pm-frontend
gcloud run deploy --image gcr.io/<project-id>/mini-pm-frontend --platform managed
```

### 3. Azure Deployment

#### Using Azure Container Instances
```bash
# Create resource group
az group create --name mini-pm-rg --location eastus

# Deploy backend
az container create \
  --resource-group mini-pm-rg \
  --name mini-pm-backend \
  --image <your-registry>/mini-pm-backend:latest \
  --ports 80

# Deploy frontend
az container create \
  --resource-group mini-pm-rg \
  --name mini-pm-frontend \
  --image <your-registry>/mini-pm-frontend:latest \
  --ports 80
```

### 4. DigitalOcean App Platform

1. Connect your GitHub repository
2. Configure services:
   - **Backend Service**: Use `Dockerfile.backend`
   - **Frontend Service**: Use `Dockerfile.frontend`
3. Set environment variables
4. Deploy with automatic scaling

## 🔧 Environment Configuration

### Production Environment Variables

Create a `.env` file with the following variables:

```bash
# Backend
JWT_SECRET=your-super-secret-jwt-key-minimum-32-characters
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=Data Source=/app/data/app.db

# Frontend
REACT_APP_API_URL=https://your-api-domain.com

# Database (if using external database)
DB_HOST=your-db-host
DB_PORT=5432
DB_NAME=minipm
DB_USER=postgres
DB_PASSWORD=your-secure-password
```

### Security Considerations

1. **JWT Secret**: Use a strong, random secret (minimum 32 characters)
2. **HTTPS**: Always use HTTPS in production
3. **Database**: Use managed database services for production
4. **Environment Variables**: Never commit secrets to version control
5. **CORS**: Configure CORS properly for your domain

## 📊 Monitoring and Logging

### Application Monitoring
```bash
# View application logs
docker-compose logs -f backend
docker-compose logs -f frontend

# Monitor resource usage
docker stats
```

### Health Checks
- **Backend**: `GET /health` or `GET /swagger`
- **Frontend**: `GET /` (should return index.html)

## 🔄 CI/CD Pipeline

### GitHub Actions Example
```yaml
name: Deploy to Production

on:
  push:
    branches: [main]

jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      
      - name: Deploy to server
        run: |
          docker-compose -f docker-compose.prod.yml up -d
```

## 🚨 Troubleshooting

### Common Issues

1. **Port Conflicts**
   ```bash
   # Check what's using the port
   lsof -i :3000
   lsof -i :5000
   ```

2. **Database Issues**
   ```bash
   # Reset database
   docker-compose down -v
   docker-compose up -d
   ```

3. **Build Failures**
   ```bash
   # Clean build
   docker-compose down
   docker system prune -f
   docker-compose up --build
   ```

### Performance Optimization

1. **Enable Gzip Compression**
2. **Use CDN for static assets**
3. **Implement caching strategies**
4. **Database connection pooling**
5. **Load balancing for high traffic**

## 📈 Scaling

### Horizontal Scaling
- Use load balancers (nginx, HAProxy)
- Deploy multiple backend instances
- Use managed database services
- Implement Redis for session storage

### Vertical Scaling
- Increase container resources
- Optimize database queries
- Use caching layers
- Implement database indexing

## 🔐 SSL/HTTPS Setup

### Using Let's Encrypt
```bash
# Install certbot
sudo apt install certbot

# Generate certificate
sudo certbot certonly --standalone -d yourdomain.com

# Update nginx configuration
# Add SSL configuration to nginx.conf
```

### Using Cloudflare
1. Add your domain to Cloudflare
2. Enable SSL/TLS encryption
3. Configure DNS records
4. Enable automatic HTTPS rewrites

## 📞 Support

For deployment issues:
1. Check the logs: `docker-compose logs -f`
2. Verify environment variables
3. Test individual services
4. Check network connectivity
5. Review security groups/firewall rules

---

**Happy Deploying! 🚀**

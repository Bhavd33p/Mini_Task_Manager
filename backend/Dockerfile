# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY backend/*.csproj ./ 
RUN dotnet restore

COPY backend/ ./
RUN dotnet publish -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5127
EXPOSE 5127

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]

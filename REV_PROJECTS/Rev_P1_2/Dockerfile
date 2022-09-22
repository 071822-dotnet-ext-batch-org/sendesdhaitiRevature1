# every dockerfile must start with a base image. so we'll get the dot net 6.0 sdk as our base image needed to run the .Net program
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

#create folder inside the container
WORKDIR /app

# make available port 5222 of app for mapping to the containers port
EXPOSE 5222

# override whatever port the app exposes already
ENV ASPNETCORE_URLS = http://+:5222

#get (again) the .NET6.0 SDK image for this stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build

#create a new folder inside the container and (cd into it) to hold the folders and files below
WORKDIR /src

#This is the api layer sln file location
COPY ["ReImbursementApp_Web_API/ReImbursementApp_Web_API.sln", "."]

# these are the referenced class libraries and projects (businesslayer ..) (all csproj files)
COPY ["ReImbursementApp_Web_API/ReImbursementApp_Web_API/ReImbursementApp_Web_API.csproj", "ReImbursementApp_Web_API/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["ModelLayer/ModelLayer.csproj", "ModelLayer/"]
COPY ["RepoLayer/RepoLayer.csproj", "RepoLayer/"]


#Re
RUN dotnet restore ReImbursementApp_Web_API/ReImbursementApp_Web_API/ReImbursementApp_Web_API.csproj

COPY ReImbursementApp_Web_API/ReImbursementApp_Web_API/ ./ReImbursementApp_Web_API/
COPY BusinessLayer/ ./BusinessLayer/
COPY ModelLayer/ ./ModelLayer/
COPY RepoLayer/ ./RepoLayer/


#I'm already inside src ...does this create second src?
WORKDIR "src/ReImbursementApp_Web_API"

RUN dotnet build "ReImbursementApp_Web_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReImbursementApp_Web_API.csproj"

#








@echo off
title Starting local Identity Server
# FYI: some views wouldn't render in Production environment so that's why using Development environment
# see for example the HomeController Index action: Swapcode.IdentityServer.ForDevs\Quickstart\Home\HomeController.cs
set ASPNETCORE_ENVIRONMENT=Development
set ASPNETCORE_URLS=http://localhost:5000
echo Starting local Identity Server...

cd Swapcode.IdentityServer.ForDevs
start "Local Identity Server" dotnet run -c Release --no-launch-profile

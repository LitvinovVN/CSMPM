#!/bin/bash
pwd
whoami
echo "Stopping kestrel-csmpmweb.service..."
systemctl stop kestrel-csmpmweb.service
echo "STOPPED"
echo "Git pulling..."
git pull
echo "Git pulled"
echo "Publishing ASP .NET Core MVC project"
dotnet publish
echo "Published"

echo "Dotnet EF Database Updating..."
dotnet ef database update --project CSMPMWeb
echo "Updated"

echo "Starting kestrel-csmpmweb.service..."
systemctl start kestrel-csmpmweb.service
echo "STARTED"
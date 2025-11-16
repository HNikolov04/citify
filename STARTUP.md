📘 Startup.md — Local Setup Guide
🚀 Citify — Local Development Setup Guide

This document explains how to run the Citify application locally.
It covers environment setup, database configuration, running migrations, and starting the API.

🛠️ 1. Prerequisites

Make sure you have the following installed:

Backend Requirements

.NET SDK 9.0+

SQL Server Express / SQL Server Developer

Visual Studio 2022 or JetBrains Rider

EF Core Tools (installed globally)

Install EF Tools:

dotnet tool install --global dotnet-ef

⚙️ 2. Clone the Repository
git clone https://github.com/<your-username>/Citify.git
cd Citify

🔧 3. Configure appsettings.json

The repository does not include real secrets or real connection strings.
Before running the API, create a new file in:

Citify.Api/appsettings.json


Paste the template below:

📄 appsettings.json (Template)
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CitifyDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "Jwt": {
    "Issuer": "CitifyApi",
    "Audience": "CitifyClient",
    "Key": "CHANGE_ME_TO_A_LONG_RANDOM_SECRET_KEY"
  },

  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  },

  "AllowedHosts": "*"
}

🗃️ 4. Configure the Database
4.1 Find your local SQL Server instance

Update the connection string accordingly.

🗄️ 5. Apply Migrations

Navigate to the API project:

cd Citify.Api


Run migrations:

dotnet ef database update


This will:

✔ Create the database
✔ Create Identity tables
✔ Create Country & City tables

🌱 6. Development Seeder (Optional)

When running in Development mode, the API automatically seeds:

Example Countries

Example Cities

A test user → test@citify.com / Test123!

Nothing is required from you — it runs automatically on startup.

▶️ 7. Run the API

From the solution root:

dotnet run --project Citify.Api


Or from Visual Studio:

Select Citify.Api as startup project

Press F5

API should become available at:

https://localhost:5001/swagger

🔐 8. Authenticate Using JWT in Swagger

Register or log in using:

POST /api/auth/login

Copy the returned token

Click Authorize in Swagger

Paste it as:

Bearer <your-token>


You can now access protected city/country endpoints.

🎉 9. You’re Ready!

The Citify system is now running locally with:

Full database

Seed data

Auth system

Swagger documentation

Clean Architecture backend
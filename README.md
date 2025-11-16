📘 Citify — City & Country Management System
🌍 Overview

Citify is a small but professionally structured web application designed to demonstrate modern Clean Architecture, ASP.NET Core development practices, and enterprise-grade application structure.
Although the functional scope is intentionally simple (managing cities and countries), the implementation follows scalable, maintainable, and production-ready standards.

🎯 Purpose

The project serves as a demonstration of:

Clean Architecture principles

Layered design with clear separation of concerns

Repository + Unit of Work patterns

Authentication using ASP.NET Identity + JWT

A real-world API suitable for extension into mobile/desktop clients

Proper DTO mapping, exception handling, and validation

Modern ASP.NET Core 9 development

🏗️ Architecture & Technology Stack
Backend

Framework: ASP.NET Core Web API (Clean Architecture)

Language: C#

Database: Microsoft SQL Server

ORM: Entity Framework Core

Authentication: ASP.NET Identity + JWT Bearer

Logging: Serilog

Documentation: Swagger (OpenAPI)

Patterns:

Repository Pattern

Unit of Work

DTO + Mapping Layer

Global Exception Middleware

Frontend (planned)

Blazor WebApp (Server Mode)

Clean UI to interact with the API

✨ Key Features

🔐 Authentication — JWT-secured endpoints

🌍 Cities & Countries CRUD

👥 Identity-backed User system

🧱 Modular Clean Architecture

📚 Swagger UI with JWT support

📦 Automatic database seeding in Development

🛠️ Global Exception Handling Middleware

🧭 Repository + Unit of Work pattern

🌐 CORS configured

🚀 Planned Enhancements

Blazor UI

Paging & filtering improvements

🗂️ Project Structure
Citify.sln
│
├── Citify.Domain          → Entities, Contracts, Base Interfaces
├── Citify.Persistence     → DbContext, Repositories, Configurations, Migrations
├── Citify.Application     → DTOs, Mappers, Services, Interfaces
├── Citify.Api             → Controllers, Middleware, Auth, Swagger, DI setup
└── Citify.WebApp          → Blazor UI Frontend

📝 License

This project is open-source and licensed under the MIT License.
See the LICENSE file for full details.
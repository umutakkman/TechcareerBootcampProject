# Car Rental Website

## Overview

Car Rental Website is a Razor Pages-based Car Rental web application built with .NET 8. The project enables users to browse and rent cars while allowing an administrator to manage the car listings and user accounts.

## Features

- **Car Rental**  
  Users can view car details, filter search results, and rent a car for a specific period.

- **Admin Panel**  
  Administrators can:
  - Create, edit, and delete car listings.
  - Manage car categories (brand, type, and seat number).
  - View and delete non-admin user accounts.

- **User Authentication**  
  - Admin and regular users can log in to access their respective functionalities.
  - Sample login credentials are provided below.

## Sample Users

### Admin User
- **Username:** admin  
- **Password:** 123456789

### Normal User
- **Username:** umutakman  
- **Password:** umutakman

## Setup

1. **Clone the Repository**

```bash
git clone https://github.com/umutakkman/CarRentalWebsite 
cd TechcareerBootcampFest4Project
```

2. **Dependencies**

   Ensure you have the following installed:
   - [.NET 8 SDK](https://dotnet.microsoft.com/download)
   - A database engine supported by EF Core (the project uses SQLite by default)

3. **Database Setup**

	The project uses Entity Framework Core for data access. To set up the database, run the following commands in the project directory:

```bash
dotnet ef migrations add InitialCreate 
dotnet ef database update
```

4. **Build and Run**

   Build and run the project using the following command:

```bash
dotnet run
```

   The application should be accessible at `https://localhost:5001` (or another port if configured).

## Project Structure

- **Controllers**: Contains MVC controllers such as `AdminController` which handles car management and user list functionalities.
- **Views**: Contains Razor Pages for user interactions, including views for Home, Admin, and Users.
- **Models & ViewModels**: Defines the data models (e.g., `Car`, `Category`, `User`) and view models (e.g., `CarViewModel`, `RegisterViewModel`, `LoginViewModel`) used by the application.
- **Data**: Contains repositories and context classes configured with Entity Framework Core.
- **Migrations**: Holds EF Core migrations for database creation and updates.
- **wwwroot**: Contains static files such as CSS, images, and JavaScript.

## Technologies

- ASP.NET Core Razor Pages (.NET 8)
- Entity Framework Core
- Bootstrap for styling
- SQLite (or another supported database provider)

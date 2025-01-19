Project ReadMe: Database Selection in .NET 8

Overview

This project is built using .NET 8 and supports SQL Server and MongoDB as its data sources. Users can select their preferred database type (SQL or NoSQL) from the frontend. Based on the selection, the project dynamically changes the connection string what we set in appsetting.json and executes database-specific logic. The application uses Entity Framework Core for SQL Server with migrations, and MongoDB for NoSQL operations.

Prerequisites

Ensure the following prerequisites are met:

.NET 8 SDK is installed on your system.

SQL Server is installed and running.

MongoDB is installed and running.

Installation Links:

Download SQL Server

Download MongoDB

Setup Instructions

Follow the steps below to set up the project:

1. Clone the Repository

git clone <repository-url>
cd <repository-folder>

2. Install Dependencies

Restore the required NuGet packages:

dotnet restore

3. Configure the Connection Strings

Open appsettings.json.

Add or update connection strings for both SQL Server and MongoDB under the ConnectionStrings section.

Example:
  "Database": {
    "MongoDatabaseName": "UserDb"
  },
"ConnectionStrings": {
  "SqlServer": "Server=localhost;Database=MyAppDb;Trusted_Connection=True;",
  "MongoDb": "mongodb://localhost:27017/MyAppDb"
}

4. Run Database Migrations for SQL Server

If you select SQL Server from the frontend, you must run the EF Core migration to initialize the database schema.

Open a terminal in the project root.

Run the following command to add a migration:

dotnet ef migrations add AddDbInitiate -context RDBMSDbContext

Apply the migration:

dotnet ef database update -context RDBMSDbContext

5. Start the Application

Run the application using the following command:

dotnet run

Usage

Open the frontend interface in a browser.

Select SQL Server or MongoDB as the database.

Perform actions like adding, updating, or querying data. The backend dynamically switches between the databases based on the selected option.

Notes

MongoDB does not require migrations; collections and documents will be created on the fly.

Ensure both databases are running and accessible to avoid connectivity issues.

Troubleshooting

Connection Errors: Verify the connection strings in appsettings.json.

Migration Errors: Ensure the Microsoft.EntityFrameworkCore.Tools package is installed and use the correct -context parameter.

MongoDB Not Found: Verify that MongoDB is running and accessible at the specified connection string.

License

This project is licensed under the MIT License.

so, i have t# Assignment
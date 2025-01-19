
# Project Title

Show user data from various data sources in a single page application.


## Overview
This project is built using .NET 8 and supports SQL Server and MongoDB as its data sources. Users can select their preferred database type (SQL or NoSQL) from the frontend. Based on the selection, the project dynamically changes the connection string what we set in appsetting.json and executes database-specific logic. The application uses Entity Framework Core for SQL Server with migrations, and MongoDB for NoSQL operations.
## Prerequisites
1. .NET 8 SDK is installed on your system.

2. SQL Server is installed and running.

3. MongoDB is installed and running.
## Installation

Firstly, clone the project-

```bash
  https://github.com/monirseccse/Assignment.git
```
secondly Open the project in Visual Studio by running the Assignment.sln solution file -
```bash
cd Assignment\Assignment
```
upate connectionstring from appsetting.json file
```bash
"Database":
 {
  "MongoDatabaseName": "UserDb" 
 }, 
"ConnectionStrings": {
 "Server=#;Database=#;Trusted_Connection=True;", 
"MongoDb": "mongodb://localhost:27017/MyAppDb" }
 ```
You may manually run the Update Database using the following command in the Project Manager Console in Visual Studio.
```bash
update-database -context RDBMSDbContext
 ```
## Tech Stack

**Server:** ASP.Net Core Web Api, EF Core

**Database:** SQL Server, MongoDb

**Design Pattern:** Repository Pattern, Factory Pattern

**Architecture:** N-Tier Architecture


## Features

Based on datasource like Sql or NoSql selection following operation will done on that datasource:
- Create user
- Update user
- Delete user
- View user


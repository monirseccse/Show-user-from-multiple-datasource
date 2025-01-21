
# Project Title

Show user data from various data sources in a single page application.


## Overview
This project allows users to dynamically select a data source (SQL or NoSQL) and perform CRUD (Create, Read, Update, Delete) operations on user data. The application is built using .NET 8 for the backend and React (with Vite) for the frontend. The backend supports SQL Server and MongoDB, allowing users to toggle between the two data sources, while the frontend interacts with the backend via HTTP headers to specify the desired data source.
## Prerequisites
## Backend
1. .NET 8 SDK

2. SQL Server installed and running.

3. MongoDB installed and running.

## Frontend
1. Node.js (>= 14.x)

2. npm installed.
## Installation
1. Clone the main repository containing both the frontend and backend:

```bash
git clone https://github.com/monirseccse/Show-user-from-multiple-datasource.git

```
2. Navigate to the backend folder and update the appsettings.json file with your connection strings:
```bash
"Database":
 {
  "MongoDatabaseName": "UserDb" 
 }, 
"ConnectionStrings": {
 "Server=#;Database=#;Trusted_Connection=True;", 
"MongoDb": "mongodb://localhost:27017/MyAppDb" }
 ```
3. Run EF Core migrations to update the SQL Server database:
```bash
update-database -context RDBMSDbContext
```
4. Start the backend server:
```bash
dotnet run

```

5. Navigate to the frontend folder, install dependencies
```bash
npm install
```
6. Configure Environment Variables
```
VITE_API_BASE_UR L= https://localhost:7006
```
7. Start the Development Server
```
npm run dev
```
    
## Usage
**Backend**

This project assumes a backend service is available to handle API requests. Example endpoints include:

**Headers:**

The header X-DataSource is required to indicate the data source (SQL or NoSQL).

**API Endpoints:**

POST /api/user/create

GET /api/read?pageNumber=<number>&itemsperPage=<number>&search=<lastname>

PUT /api/user/{id}

DELETE /api/user/delete/{id}

**Frontend**

1. Open the application in your browser.

2. Select the data source (SQL or NoSQL) from the UI.

3. Use the interface to perform CRUD operations, search for users, and navigate paginated lists.
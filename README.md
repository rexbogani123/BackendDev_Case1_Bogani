# Setup Instructions

- Extract the zip file
- Open the solution in Visual Studio Code or your preferred IDE.

# Update Connection String

- In appsettings.json, configure your database:
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EcomProductManagementDB;Trusted_Connection=True;"
  }

# Apply EF Core Migrations

- dotnet ef migrations add InitialCreate
- dotnet ef database update

# Run the Application

- dotnet run
- The API will start on: http://localhost:5000 (or configured port)

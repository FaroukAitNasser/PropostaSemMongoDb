# .NET 6 Web API - In-Memory CRUD

This project is a simple .NET 6 Web API that performs CRUD operations for two entities: `Pessoa` (Person) and `Telefone` (Phone). All data is stored in memory, and no database is required.

## Features

- Built with ASP.NET Core 6
- RESTful endpoints
- In-memory data storage
- Swagger UI for testing

## Project Structure

```
MyApiProject/
├── Controllers/
│   └── PessoaController.cs
├── Data/
│   └── InMemoryDatabase.cs
├── Models/
│   ├── Pessoa.cs
│   └── Telefone.cs
├── Program.cs
├── MyApiProject.csproj
```

## Running the Project

```bash
dotnet run
```

Then open: https://localhost:7091/swagger

## API Endpoints

| Method | Route            | Description       |
| ------ | ---------------- | ----------------- |
| GET    | /api/pessoa      | Get all pessoas   |
| GET    | /api/pessoa/{id} | Get pessoa by ID  |
| POST   | /api/pessoa      | Create new pessoa |
| PUT    | /api/pessoa/{id} | Update pessoa     |
| DELETE | /api/pessoa/{id} | Delete pessoa     |

## Notes

- All data is stored in memory.
- Data will be lost when the app stops.
- No database is used.

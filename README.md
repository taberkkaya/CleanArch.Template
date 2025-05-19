<p align="center">
  <img src="assets/logo.jpg" alt="CleanArch.Template Logo" width="200"/>
</p>

<h1 align="center">CleanArch.Template</h1>

<p align="center">
  🧱 A clean, scalable and modular .NET Web API template built using Clean Architecture principles.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-blue?logo=dotnet" />
  <img src="https://img.shields.io/badge/EF--Core-9.0-green?logo=entity-framework" />
  <img src="https://img.shields.io/badge/Architecture-CleanArch-%23734F96" />
</p>

---

## 📦 Project Structure

This template follows the Clean Architecture structure:

📁 CleanArch.Template <br>
│<br>
├── 📁 CleanArch.Application → Business rules,<br>
├── 📁 CleanArch.Domain → Core entities and value objects<br>
├── 📁 CleanArch.Infrastructure → Data access (EF Core), service implementations<br>
├── 📁 CleanArch.WebApi → API endpoints, OData setup, DI config<br>

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/taberkkaya/CleanArch.Template.git
cd CleanArch.Template
```

### 2. Set your connection string

Edit the appsettings.json file in the CleanArch.WebApi project:

```json
"ConnectionStrings": {
  "ConnectionString": "Your-SQL-Server-Connection-String-Here"
}
```

---

Make sure you have dotnet-ef installed globally.<br>

### Install it using:

```
dotnet tool install --global dotnet-ef
```

---

## 🧰 Technologies Used

This template leverages the following frameworks and libraries:

| Technology                                                                                                  | Description                                               |
| ----------------------------------------------------------------------------------------------------------- | --------------------------------------------------------- |
| [.NET 9](https://dotnet.microsoft.com/)                                                                     | Core framework for the API                                |
| [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)                                         | ORM for database access                                   |
| [Mapster](https://github.com/MapsterMapper/Mapster)                                                         | Lightweight and fast object mapping library               |
| [FluentValidation](https://docs.fluentvalidation.net/)                                                      | Elegant and fluent validation rules                       |
| [Scrutor](https://github.com/khellang/Scrutor)                                                              | Assembly scanning and DI registration                     |
| [OData](https://learn.microsoft.com/en-us/odata/)                                                           | Enables rich querying capabilities                        |
| [System.Threading.RateLimiting](https://learn.microsoft.com/en-us/dotnet/api/system.threading.ratelimiting) | Built-in rate limiting for APIs                           |
| [RepositoryKit](https://github.com/taberkkaya/RepositoryKit)                                                | Implements the repository and unit of work pattern        |
| [ResultKit](https://github.com/taberkkaya/ResultKit)                                                        | Provides consistent result wrapping for service responses |

---

## ✅ Features

✔️ Clean Architecture with layer separation

✔️ Entity Framework Core integration

✔️ Generic Repository & Unit of Work

✔️ OData filtering, sorting, pagination

✔️ Rate Limiting with System.Threading.RateLimiting

✔️ Scalar/OpenAPI support

✔️ Scalable DI setup via Scrutor

## 🧠 Inspired By

This project was implemented by following the tutorial series by _[Taner Saydam](https://www.youtube.com/watch?v=byiN2UZXXJQ&t=6247s)_ on YouTube.

### 📺 Taner Saydam Clean Architecture Series

Credits to Taner for the awesome series that laid the foundation for this template.

---

### ✨ Contribution

Feel free to fork this repository and contribute your improvements.

---

### 🪪 License

This project is open-source and available under the MIT License.

---

<p align="center"> <img src="https://skillicons.dev/icons?i=dotnet,github,visualstudio" /> </p>

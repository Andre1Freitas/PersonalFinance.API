# PersonalFinance.API

A personal finance management REST API built with ASP.NET Core, focused on clean architecture, SOLID principles, and real-world backend patterns.

> Developed as part of a learning journey for career transition to Backend Development.

---

## 📌 About the Project

This API allows users to manage their personal finances by registering income and expenses, organizing transactions by category, and filtering records by period. The project was built with a strong focus on architectural best practices and incremental evolution.

---

## 🗂️ Project Structure

```
PersonalFinance.API/
├── Controllers/
│   ├── UserController.cs
│   ├── CategoryController.cs
│   └── TransactionController.cs
├── DTOs/
│   ├── CreateUserDto.cs / UpdateUserDto.cs
│   ├── CreateCategoryDto.cs / UpdateCategoryDto.cs
│   └── CreateTransactionDto.cs / UpdateTransactionDto.cs
├── Entities/
│   ├── User.cs
│   ├── Category.cs
│   └── Transaction.cs
├── Enums/
│   └── TransactionType.cs
├── Interfaces/
│   ├── IUserRepository.cs / IUserService.cs
│   ├── ICategoryRepository.cs / ICategoryService.cs
│   └── ITransactionRepository.cs / ITransactionService.cs
├── Repositories/
│   ├── UserEFRepository.cs
│   ├── CategoryEFRepository.cs
│   └── TransactionEFRepository.cs
├── Services/
│   ├── UserService.cs
│   ├── CategoryService.cs
│   └── TransactionService.cs
├── Validations/
│   ├── ValidationHelper.cs
│   ├── UserValidation.cs
│   ├── CategoryValidation.cs
│   └── TransactionValidation.cs
├── Common/
│   └── Result.cs
├── Data/
│   └── AppDbContext.cs
├── Migrations/
└── Program.cs
```

---

## ⚙️ Endpoints

### Users
| Method | Route | Description |
|--------|-------|-------------|
| POST | /api/user | Create new user |
| GET | /api/user | List all users |
| GET | /api/user/{id} | Get user by ID |
| PUT | /api/user/{id} | Update user |
| DELETE | /api/user/{id} | Delete user |

### Categories
| Method | Route | Description |
|--------|-------|-------------|
| POST | /api/category | Create new category |
| GET | /api/category | List all categories |
| GET | /api/category/{id} | Get category by ID |
| PUT | /api/category/{id} | Update category |
| DELETE | /api/category/{id} | Delete category |

### Transactions
| Method | Route | Description |
|--------|-------|-------------|
| POST | /api/transaction | Create new transaction |
| GET | /api/transaction/{id} | Get transaction by ID |
| GET | /api/transaction/user/{id} | Get all transactions by user |
| GET | /api/transaction/period | Get transactions by period |
| PUT | /api/transaction/{id} | Update transaction |
| DELETE | /api/transaction/{id} | Delete transaction |

---

## 🧱 Architecture

- **ASP.NET Core Web API (.NET 10)**
- **Repository Pattern** — persistence layer isolated from business logic; swappable without touching Service or Controller layers
- **Service Layer** — business rules and validations decoupled from controllers
- **Result Pattern** — consistent error handling across all layers using a custom `Result<T>` class instead of exceptions
- **DTOs** — separates API input/output from the internal domain model
- **Dependency Injection** — all dependencies injected through interfaces
- **SOLID Principles** — SRP, DIP, and ISP applied throughout
- **Entity Framework Core + SQLite** — real database with migrations
- **Swagger** — interactive API documentation

---

## 🛠️ Technologies Used

- C# (.NET 10)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- LINQ
- GUID — unique identifiers
- Swagger / Swashbuckle
- xUnit *(planned)*
- Docker + PostgreSQL *(planned)*
- JWT Authentication *(in progress)*

---

## ▶️ How to Run

```bash
git clone https://github.com/Andre1Freitas/PersonalFinance.API.git
cd PersonalFinance.API
dotnet ef database update
dotnet run
```

Then open in browser: `http://localhost:5207/swagger`

---

## 🎓 About the Developer

Project developed by **André Freitas** as part of a learning journey for career transition to Backend Developer.

**Goal:** Build a solid portfolio demonstrating technical evolution, clean architecture, and real-world backend patterns.

**Target:** Backend internship by June 2026.

---

## 📝 License

This project is under MIT License. Feel free to use it as a study reference!
using Microsoft.EntityFrameworkCore;
using PersonalFinance.API.Data;
using PersonalFinance.API.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PersonalFinance.API.Interfaces.IUserRepository, PersonalFinance.API.Repositories.UserEFRepository>();
builder.Services.AddScoped<PersonalFinance.API.Interfaces.IUserService, PersonalFinance.API.Services.UserService>();
builder.Services.AddScoped<UserValidation>();

builder.Services.AddScoped<PersonalFinance.API.Interfaces.ITransactionRepository, PersonalFinance.API.Repositories.TransactionEFRepository>();
builder.Services.AddScoped<PersonalFinance.API.Interfaces.ITransactionService, PersonalFinance.API.Services.TransactionService>();
builder.Services.AddScoped<TransactionValidation>();

builder.Services.AddScoped<PersonalFinance.API.Interfaces.ICategoryRepository, PersonalFinance.API.Repositories.CategoryEFRepository>();
builder.Services.AddScoped<PersonalFinance.API.Interfaces.ICategoryService, PersonalFinance.API.Services.CategoryService>();
builder.Services.AddScoped<CategoryValidation>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();

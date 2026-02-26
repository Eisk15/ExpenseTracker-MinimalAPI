using Scalar.AspNetCore;
using ExpenseTrackerMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();


// Default Endpoint
app.MapGet("/", () =>
{
    return "This is the root endpoint for expense tracker!";
});

app.Run();


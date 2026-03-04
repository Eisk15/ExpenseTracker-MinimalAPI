using Scalar.AspNetCore;
using ExpenseTrackerMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Services;
using ExpenseTrackerMinimalAPI.Endpoints;
using ExpenseTrackerMinimalAPI.Validators;
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();



var app = builder.Build();

// Global Error handling
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            error = "An unexpected error occurred"
        });
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}



app.UseHttpsRedirection();
app.MapUserEndpoints();
app.MapExpenseEndpoints();

app.Run();


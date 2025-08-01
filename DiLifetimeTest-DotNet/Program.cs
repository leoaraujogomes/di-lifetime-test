using DiLifetimeTest_DotNet.Interfaces;
using DiLifetimeTest_DotNet.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITransient, TransientService>();
builder.Services.AddScoped<IScoped, ScopedService>();
builder.Services.AddSingleton<ISingleton, SingletonService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Dependency Injection Lifetime Test API",
        Version = "v1.0",
        Description = @"
 **Dependency Injection Lifetime Showcase**

This project aims to showcase each lifetime in .NET's Dependency Injection:

### **Transient**
- Creates a **new instance** for each injection
- Always returns **different IDs**
- Best for lightweight, stateless services

### **Scoped** 
- Creates a **single instance per HTTP request**
- Returns **same IDs** within the same request
- Perfect for Entity Framework DbContext and request-specific operations

### **Singleton**
- Creates a **single instance** for the entire application lifetime
- Always returns the **same ID** across all requests
- Ideal for configuration services, caching, and expensive services

### **How to test:**
1. Make multiple calls to each endpoint and compare the returned IDs
3. See how lifetimes behave in different scopes
5. Use `/api/lifetime/all` to see all lifetimes in one response
        "
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
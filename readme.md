# 🎯 Dependency Injection Lifetime Test API

## 📖 About

This project demonstrates the three main **Dependency Injection lifetime scopes** in .NET through a simple Web API. Each endpoint showcases different behaviors to help developers understand when and how to use each lifetime appropriately.

## 🔄 Lifetime Scopes Explained

### 🟢 **Transient**
```csharp
builder.Services.AddTransient<ITransient, TransientService>();
```
- ✅ **New instance** created for each injection
- ✅ **Different IDs** on every call
- 🎯 **Use case**: Lightweight, stateless services

### 🟡 **Scoped**  
```csharp
builder.Services.AddScoped<IScoped, ScopedService>();
```
- ✅ **One instance** per HTTP request
- ✅ **Same ID** within the same request
- 🎯 **Use case**: Entity Framework DbContext, request-specific operations

### 🔴 **Singleton**
```csharp
builder.Services.AddSingleton<ISingleton, SingletonService>();
```
- ✅ **Single instance** for the entire application lifetime
- ✅ **Same ID** across all requests
- 🎯 **Use case**: Configuration services, caching, expensive-to-create services

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone https://github.com/leoaraujogomes/di-lifetime-test.git
   cd di-lifetime-test
   cd DiLifetimeTest-DotNet
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open Swagger UI**
   ```
   http://localhost:5068/swagger
   ```

## 🔗 API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/lifetime/transient` | GET | Demonstrates **Transient** lifetime |
| `/api/lifetime/scoped` | GET | Demonstrates **Scoped** lifetime |
| `/api/lifetime/singleton` | GET | Demonstrates **Singleton** lifetime |
| `/api/lifetime/compare` | GET | Compares **all lifetimes** in one response |

## 📊 Expected Results

### Transient Example
```json
{
  "service1Id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "service2Id": "z9y8x7w6-v5u4-3210-fedc-ba0987654321",
  "type": "Transient"
}
```
> ⚠️ **Notice**: `service1Id` ≠ `service2Id` (Always different)

### Scoped Example
```json
{
  "service1Id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "service2Id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
  "type": "Scoped"
}
```
> ✅ **Notice**: `service1Id` = `service2Id` (Same within request)

### Singleton Example
```json
{
  "service1Id": "550e8400-e29b-41d4-a716-446655440000",
  "service2Id": "550e8400-e29b-41d4-a716-446655440000",
  "type": "Singleton"
}
```
> 🎯 **Notice**: `service1Id` = `service2Id` (Always same, even across requests)

## 🧪 How to Test

1. **Open Swagger UI** at `http://localhost:5068`
2. **Test each endpoint** multiple times
3. **Compare the returned IDs**:
   - **Transient**: Always different IDs
   - **Scoped**: Same IDs within one request, different across requests
   - **Singleton**: Always the same IDs, even across different requests
4. **Use multiple browser tabs** to simulate different users/requests

## 📚 Learning Resources

- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [ASP.NET Core DI Container](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [Service Lifetimes](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes)

## 🎓 Educational Purpose

This project was created for educational purposes to help developers understand:
- How Dependency Injection works in .NET
- The differences between service lifetimes
- When to use each lifetime appropriately
- Best practices for DI in ASP.NET Core applications

⭐ **If this project helped you understand Dependency Injection better, please give it a star!** ⭐

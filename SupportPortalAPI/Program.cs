using Microsoft.EntityFrameworkCore;
using SupportPortalAPI.Data;
using SupportPortalAPI.Models; // Required for accessing the Customer model

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// In-memory DB (for testing/dev)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SupportDb"));

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS (for frontend-backend communication)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use middleware
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Seed in-memory database with one test customer
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Customers.Any())
    {
        db.Customers.Add(new Customer
        {
            Id = 1,
            Name = "Test User",
            PhoneNumber = "1234567890",
            Email = "test@example.com" // ✅ Required property fixed
        });

        db.SaveChanges();
    }
}

app.Run();

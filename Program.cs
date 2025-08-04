using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
// These config will be passed via YAML files in an encoded secret 
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
var connectionString = $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPass};Encrypt=False;TrustServerCertificate=True;";
builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
 

    context.Database.EnsureCreated();

    if (!context.Employees.Any())
    {
        // adding some static data to be available for get
        context.Employees.AddRange(
            new Employee { FullName = "Aayush Dayal", Department = "IT", Title = "Developer" },
            new Employee { FullName = "Sam Altman", Department = "HR", Title = "CFO" },
            new Employee { FullName = "Mark Zu", Department = "IT", Title = "CTO" },
            new Employee { FullName = "Satya N", Department = "Finance", Title = "Business Head" },
            new Employee { FullName = "Steve J", Department = "CH", Title = "Founder" }
        );
        context.SaveChanges();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => Results.Ok("Healthy"));
app.Run("http://0.0.0.0:80");
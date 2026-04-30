using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Users;
using PayBridge.Infrastructure.Auth;
using PayBridge.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// 
Console.WriteLine($"conection string is {builder.Configuration["ConnectionStrings:DefaultConnection"]}");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<JwtTokenService>();

builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)
.UseSnakeCaseNamingConvention());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

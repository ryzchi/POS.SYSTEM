using Microsoft.EntityFrameworkCore;
using POSWebAPI.Data;
using POSWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB context and service
builder.Services.AddDbContext<POSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("POSConnection")));
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

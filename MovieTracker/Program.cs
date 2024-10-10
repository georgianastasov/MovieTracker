using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieTracker.Add;
using MovieTracker.Options;  // Make sure to include the correct namespace

var builder = WebApplication.CreateBuilder(args);

// Read SwaggerOptions from appsettings.json
var swaggerOptions = builder.Configuration.GetSection("SwaggerOptions").Get<SwaggerOptions>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

if (swaggerOptions?.IsEnabled == true)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Movie Tracker",
            Version = "v1",
            Description = "RESTful web api",
            Contact = new OpenApiContact(),
        });
    });
}

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MoviesDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    if (swaggerOptions?.IsEnabled == true)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Tracker API v1");
        });
    }
}

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

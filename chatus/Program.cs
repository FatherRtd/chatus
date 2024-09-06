using chatus.API.Entities;
using chatus.API.Entities.Repositories;
using chatus.API.Services;
using chatus.API.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ChatDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(ChatDbContext)));
});

// Add services to the container.
builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationUtils(configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiAuthentication(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ChatDbContext>();
    db.Database.Migrate();
}

app.Run();

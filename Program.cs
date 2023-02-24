using DataBaseFirstAPI.Models;
using DataBaseFirstAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get user secret connection string
string connection = builder.Configuration["ConnectioString"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection dbContext
builder.Services.AddDbContext<DiscografiaContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString(connection));
});

// Injection services
builder.Services.AddScoped<IAlbum, AlbumService>();
builder.Services.AddScoped<IArtista, ArtistaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

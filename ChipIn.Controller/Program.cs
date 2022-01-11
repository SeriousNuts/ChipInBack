

using ChipIn.Controller.Controllers;
using ChipIn.Controller.Data;
using ChipIn.Controller.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChipInControllerContext>(options =>

    options.UseNpgsql(builder.Configuration.GetConnectionString("postgreConnect")).UseSnakeCaseNamingConvention().UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));

// Add services to the container.
builder.Services.AddControllers();
var app = builder.Build();




app.MapControllers();
app.Run();


using ChipIn.Controller.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChipIn.Controller.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChipInControllerContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("ChipInControllerContext")));

// Add services to the container.

var app = builder.Build();

app.MapGet("/", () => "Hello world");


app.Run();
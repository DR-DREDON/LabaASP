using Microsoft.EntityFrameworkCore;
using ToolApp.AppBackgroundService;
using ToolApp.BLL.Interfaces;
using ToolApp.BLL.Servises;
using ToolApp.DAL.EF;
using ToolApp.DAL.Interfaces;
using ToolApp.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb;Database = toolstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<ToolDBContext>(options => options.UseSqlServer(connection));


builder.Services.AddScoped<IToolAppService, ToolAppService>();
builder.Services.AddScoped<IToolTypeRepository, ToolTypeRepository>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();

builder.Services.AddHostedService<ToolBackgroundService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();

using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var tasks = new List<TaskItem>();

var app = builder.Build();

app.MapControllers();

app.Run();
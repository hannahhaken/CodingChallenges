using System.Collections.Generic;
using FavouritesFeature;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var users = new List<User>();
builder.Services.AddSingleton<IUserService>(new UserService(users));

var app = builder.Build();

app.MapControllers();

app.Run();
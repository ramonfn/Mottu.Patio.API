using Microsoft.EntityFrameworkCore;
using Mottu.Patio.API.Data;
using Mottu.Patio.API.Repositories.Interfaces;
using Mottu.Patio.API.Repositories;
using Mottu.Patio.API.Services;
using Mottu.Patio.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath)) { c.IncludeXmlComments(xmlPath, true); }
});

// 🔹 Aqui fica só o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Aqui ficam os Repositories
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IFilialRepository, FilialRepository>();
builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// 🔹 Aqui ficam os Services
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IFilialService, FilialService>();
builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

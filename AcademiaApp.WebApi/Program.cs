using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AcademiaApp.Repositorio;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder();


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


builder.Services.AddSwaggerGen();


builder.Services.AddControllers();


var dbPath = "C:\\Users\\Samuel\\Desktop\\TrabalhoP2\\AcademiaApp\\AcademiaApp.Repositorio\\meubanco.db";
Console.WriteLine($"✅ Banco de dados sendo utilizado: {dbPath}"); 

builder.Services.AddDbContext<AcademiaDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AcademiaDbContext>();

    
    var tabelaExiste = dbContext.Database.ExecuteSqlRaw("SELECT name FROM sqlite_master WHERE type='table' AND name='Alunos';");
    if (tabelaExiste == 0)
    {
        Console.WriteLine("❌ A tabela `Alunos` não existe no banco! Verifique as migrations.");
    }

    dbContext.Database.Migrate(); 
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirFrontend");

app.MapControllers();

app.Run();
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AcademiaApp.Repositorio;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Adiciona serviços do Swagger
builder.Services.AddSwaggerGen();

// Adiciona serviços de controllers
builder.Services.AddControllers();

// Configuração correta do banco SQLite (evita criação de banco vazio)
var dbPath = "C:\\Users\\Samuel\\Desktop\\TrabalhoP2\\AcademiaApp\\AcademiaApp.Repositorio\\meubanco.db";
Console.WriteLine($"✅ Banco de dados sendo utilizado: {dbPath}"); // Log de depuração

builder.Services.AddDbContext<AcademiaDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Criar o escopo corretamente sem `BuildServiceProvider()`
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AcademiaDbContext>();

    // Verifica se a tabela `Alunos` existe antes de continuar
    var tabelaExiste = dbContext.Database.ExecuteSqlRaw("SELECT name FROM sqlite_master WHERE type='table' AND name='Alunos';");
    if (tabelaExiste == 0)
    {
        Console.WriteLine("❌ A tabela `Alunos` não existe no banco! Verifique as migrations.");
    }

    dbContext.Database.Migrate(); // Aplica migrations automaticamente
}

// Configuração de middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirFrontend");

app.MapControllers();

app.Run();
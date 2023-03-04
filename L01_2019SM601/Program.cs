using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2019SM601.Models;
using Microsoft.EntityFrameworkCore;
using L01_2019SM601.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Inyeccion por dependencia del string de conexion al contexto
builder.Services.AddDbContext<clientesContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("entidadesDbConnection")
    )

    );
builder.Services.AddControllers();
// Inyeccion por dependencia del string de conexion al contexto
builder.Services.AddDbContext<motoristaContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("entidadesDbConnection")
    )
    );
// Inyeccion por dependencia del string de conexion al contexto
builder.Services.AddDbContext<platoContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("entidadesDbConnection")
    )
    );
// Inyeccion por dependencia del string de conexion al contexto
builder.Services.AddDbContext<pedidoContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("entidadesDbConnection")
    )
    );





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

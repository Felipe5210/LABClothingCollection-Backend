using LabClothingCollection.Data.Repositories;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Domain.Services;
using LabClothingCollection.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClothingCollectionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabClothingCollectionString")));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IColecaoService, ColecaoService>();
builder.Services.AddScoped<IColecaoRepository, ColecaoRepository>();

builder.Services.AddScoped<IModeloService, ModeloService>();
builder.Services.AddScoped<IModeloRepository, ModeloRepository>();


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

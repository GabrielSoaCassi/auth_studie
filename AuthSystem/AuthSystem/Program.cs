using AuthSystem.Context;
using AuthSystem.Repositories.UsuarioRepositoryFolder;
using AuthSystem.Services;
using AuthSystem.Services.TokenServiceFolder;
using AuthSystem.Services.UsuarioServiceFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<IUsuarioDbContext,UsuarioDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

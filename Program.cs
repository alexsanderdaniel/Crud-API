using GerandoAtivo.Data;
using GerandoAtivo.Repositorios;
using GerandoAtivo.Services;
using Microsoft.EntityFrameworkCore;
//imports feitos para a parte de autenticacao
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UsuarioServico>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<AtivoServico>();
builder.Services.AddScoped<AtivoRepositorio>();
builder.Services.AddScoped<PassivosServico>();
builder.Services.AddScoped<PassivoRepositorio>();
builder.Services.AddScoped<MetaServico>();
builder.Services.AddScoped<MetaRepositorio>();
builder.Services.AddScoped<AutenticacaoServico>();

//Adicionando a minha classe de contexto na API
//Tem que acrescentar using Microsoft.EntityFrameworkCore;
//using using GerandoAtivos.Data;
builder.Services.AddDbContext<ContextoBD>(
  options =>
  //Dizendo que vamos usar o MySQL
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);

//Configurações para usar Autenticação com JWT
var JWTChave = Encoding.ASCII.GetBytes(builder.Configuration["JWTChave"]);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(JWTChave),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

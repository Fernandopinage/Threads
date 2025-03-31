using App.Command.UserCommand;
using Infra.Repository.BaseRepository;
using Infra.Repository.Interface;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();

// MediatR configurações...
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserCreateCommand).Assembly));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permite qualquer origem
              .AllowAnyHeader()  // Permite qualquer cabeçalho
              .AllowAnyMethod(); // Permite qualquer método (GET, POST, etc.)
    });
});

// Configuração do banco de dados (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configurando a injeção de dependências
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita o uso de CORS
app.UseCors("AllowAll");

// Configura o redirecionamento para HTTPS e autorização
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

// Inicia a aplicação
app.Run();

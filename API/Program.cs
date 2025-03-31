using App.Command.UserCommand;
using Infra.Repository.BaseRepository;
using Infra.Repository.Interface;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();

// MediatR configura��es...
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserCreateCommand).Assembly));

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a pol�tica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permite qualquer origem
              .AllowAnyHeader()  // Permite qualquer cabe�alho
              .AllowAnyMethod(); // Permite qualquer m�todo (GET, POST, etc.)
    });
});

// Configura��o do banco de dados (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configurando a inje��o de depend�ncias
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita o uso de CORS
app.UseCors("AllowAll");

// Configura o redirecionamento para HTTPS e autoriza��o
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

// Inicia a aplica��o
app.Run();

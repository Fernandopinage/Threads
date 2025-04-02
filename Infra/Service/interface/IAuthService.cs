using System;
using System.Security.Claims;

public interface IAuthService
{
    // Método para gerar o token JWT com nome, email e id
    string GenerateToken(string name, string email, Guid id);

    // Método para validar o token JWT
    ClaimsPrincipal ValidateToken(string token);
}
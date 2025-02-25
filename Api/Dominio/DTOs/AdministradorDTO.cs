using MinimalApi.Dominio.Enuns;

namespace MininalApi.Dominio.DTOs;

public class AdministradorDTO
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Perfil Perfil { get; set; }
}
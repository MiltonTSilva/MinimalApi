using MinimalApi.Dominio.Enuns;

namespace MininalApi.Dominio.ModelViews;

public class AdministradorModelView
{
    public int Id { get; set; } = default!;
    public string Email { get; set; } = string.Empty;
    public Perfil Perfil { get; set; }
    public string Token { get; set; } = string.Empty;
}
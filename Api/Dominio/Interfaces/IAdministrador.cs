using MininalApi.Dominio.Entidades;
using MininalApi.Dominio.DTOs;

namespace MininalApi.Dominio.Interfaces;
public interface IAdministrador
{
    Administrador? Login(LoginDTO loginDto);
    //List<Administrador> Todos(int? pagina);
    List<Administrador> Todos(int? paginas = 1, string? email = null, string? perfil = null);
    Administrador? BuscarPorId(int id);
    Task<List<string>> Adicionar(Administrador administrador);
    Administrador Incluir(Administrador administrador);
    Task<List<string>> Atualizar(Administrador administrador);
    bool Remover(Administrador administrador);

    

}
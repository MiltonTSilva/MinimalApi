using MinimalApi.Dominio.Enuns;
using MininalApi.Dominio.DTOs;
using MininalApi.Dominio.Entidades;
using MininalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class AdministradorServicoMock : IAdministrador
{
    private static List<Administrador> administradores = new List<Administrador>(){
        new Administrador{
            Id = 1,
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = Perfil.Administrador
        },
        new Administrador{
            Id = 2,
            Email = "editor@teste.com",
            Senha = "123456",
            Perfil = Perfil.Editor
        }
    };

    public Task<List<string>> Adicionar(Administrador administrador)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> Atualizar(Administrador administrador)
    {
        throw new NotImplementedException();
    }

    public Administrador? BuscaPorId(int id)
    {
        return administradores.Find(a => a.Id == id);
    }

    public Administrador? BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Administrador Incluir(Administrador administrador)
    {
        administrador.Id = administradores.Count() + 1;
        administradores.Add(administrador);

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public bool Remover(Administrador administrador)
    {
        throw new NotImplementedException();
    }

    public List<Administrador> Todos(int? pagina)
    {
        return administradores;
    }

    public List<Administrador> Todos(int? paginas = 1, string? email = null, string? perfil = null)
    {
        throw new NotImplementedException();
    }
}
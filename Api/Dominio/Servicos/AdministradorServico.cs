using Microsoft.OpenApi.Extensions;
using MinimalApi.Dominio.Enuns;
using MininalApi.Dominio.Entidades;
using MininalApi.Dominio.Interfaces;
using MininalApi.Dominio.DTOs;
using MininalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;

namespace MininalApi.Dominio.Servicos;
public class AdministradorServico : IAdministrador
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        this._contexto = contexto;
    }

    public Administrador? Login(LoginDTO loginDto)
    {
        return _contexto.Administradores.Where(w => w.Email == loginDto.Email && w.Senha == loginDto.Senha).FirstOrDefault();
    }

    public async Task<List<string>> Adicionar(Administrador administrador)
    {
        try
        {
            var erros = ValidarAdministrador(administrador);
            if (erros.Count > 0) return erros;

            _contexto.Administradores.Add(administrador);
            await _contexto.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var teste = ex.Message;
            throw;
        }

        return [];
    }

    public async Task<List<string>> Atualizar(Administrador administrador)
    {

        var erros = ValidarAdministrador(administrador);
        if (erros.Count > 0) return erros;

        _contexto.Administradores.Update(administrador);
        await _contexto.SaveChangesAsync();
        return [];
    }

    public Administrador? BuscarPorId(int id)
    {
        return _contexto.Administradores.Find(id);
    }

    public bool Remover(Administrador administrador)
    {
        _contexto.Administradores.Remove(administrador);
        _contexto.SaveChanges();

        return true;
    }

    public List<Administrador> Todos(int? paginas = 1, string? email = null, string? perfil = null)
    {
        List<Administrador> lista = _contexto.Administradores.ToList();
        int itensPorPagina = 10;

        Perfil perfilEnum = new();
        if (!string.IsNullOrEmpty(perfil))
        {
            if (Enum.IsDefined(typeof(Perfil), perfil!))
            {
                perfilEnum = (Perfil)Enum.Parse(typeof(Perfil), perfil!);
            }
        }

        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(perfil))
        {
            lista = [.. _contexto.Administradores.Where(w => w.Email.ToLower().Contains(email.ToLower())
                                                            && w.Perfil == perfilEnum)];
        }

        if (!string.IsNullOrEmpty(email))
        {
            lista = [.. _contexto.Administradores.Where(w => w.Email.ToLower().Contains(email.ToLower()))];
        }

        if (!string.IsNullOrEmpty(perfil))
        {
            lista = [.. _contexto.Administradores.Where(w => w.Perfil == perfilEnum)];
        }


        if (paginas != null)
            return lista.Skip(((int)paginas - 1) * itensPorPagina).Take(itensPorPagina).ToList();
        else
            return lista;
    }

    public List<string> ValidarAdministrador(Administrador administrador)
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(administrador.Email)) erros.Add("O email não pode ser vazio!");
        if (string.IsNullOrEmpty(administrador.Senha)) erros.Add("A senha não pode ser vazia!");
        if (string.IsNullOrEmpty(administrador.Perfil.GetDisplayName())) erros.Add("Perfil obrigatório!");
        return erros;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }
}
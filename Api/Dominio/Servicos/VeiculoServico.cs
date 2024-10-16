using MininalApi.Dominio.Entidades;
using MininalApi.Dominio.Interfaces;
using MininalApi.Dominio.DTOs;
using MininalApi.Infraestrutura.Db;

namespace MininalApi.Dominio.Servicos;
public class VeiculoServico : IVeiculo
{
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto)
    {
        this._contexto = contexto;
    }

    public async Task<List<string>> Adicionar(Veiculo veiculo)
    {
        var erros = ValidarVeiculo(veiculo);
        if (erros.Count > 0) return erros;

        _contexto.Veiculos.Add(veiculo);
        await _contexto.SaveChangesAsync();
        return [];
    }

    public async Task<List<string>> Atualizar(Veiculo veiculo)
    {

        var erros = ValidarVeiculo(veiculo);
        if (erros.Count > 0) return erros;

        _contexto.Veiculos.Update(veiculo);
        await _contexto.SaveChangesAsync();
        return [];
    }

    public Veiculo? BuscarPorId(int id)
    {
        return _contexto.Veiculos.Find(id);
    }

    public bool Remover(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();

        return true;
    }

    public List<Veiculo> Todos(int? paginas = 1, string? nome = null, string? marca = null)
    {
        List<Veiculo> lista = _contexto.Veiculos.ToList();
        int itensPorPagina = 10;


        if (!string.IsNullOrEmpty(nome))
        {
            lista = [.. _contexto.Veiculos.Where(w => w.Nome.ToLower().Contains(nome.ToLower()))];
        }

        if (!string.IsNullOrEmpty(marca))
        {
            lista = [.. _contexto.Veiculos.Where(w => w.Marca.ToLower().Contains(marca.ToLower()))];
        }

        if (paginas != null)
            return lista.Skip(((int)paginas - 1) * itensPorPagina).Take(itensPorPagina).ToList();
        else
            return lista;
    }

    public List<string> ValidarVeiculo(Veiculo veiculo)
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(veiculo.Nome)) erros.Add("O nome não pode ser vazio!");
        if (string.IsNullOrEmpty(veiculo.Marca)) erros.Add("A marca não pode ser vazia!");

        if (veiculo.Ano < 1950) erros.Add("Veiculo muito antigo, aceito sómente ano acima de 1950!");

        return erros;
    }
}
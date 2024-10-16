using MininalApi.Dominio.Entidades;
using MininalApi.Dominio.DTOs;

namespace MininalApi.Dominio.Interfaces;
public interface IVeiculo
{
    List<Veiculo> Todos(int? paginas = 1, string? nome = null, string? marca = null);
    Veiculo? BuscarPorId(int id);
    Task<List<string>> Adicionar(Veiculo veiculo);
    Task<List<string>> Atualizar(Veiculo veiculo);
    bool Remover(Veiculo veiculo);
}
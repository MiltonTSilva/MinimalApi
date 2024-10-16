using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Enuns;
using MininalApi.Dominio.Entidades;

namespace MininalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuration;

    public DbContexto(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>()
        .HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = Perfil.Administrador
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            string? conection = _configuration.GetConnectionString("Mysql");

            if (!string.IsNullOrEmpty(conection))
            {
                optionsBuilder.UseMySql(conection, ServerVersion.AutoDetect(conection));
            }
        }
    }
}
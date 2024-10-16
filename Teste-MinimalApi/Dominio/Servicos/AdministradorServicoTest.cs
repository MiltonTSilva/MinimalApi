using MininalApi.Dominio.Entidades;
using MinimalApi.Dominio.Enuns;
using MininalApi.Dominio.Servicos;
using Teste_MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;

namespace Teste_MinimalApi.Dominio.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {

        [TestMethod]
        public async Task TestarPostAdministrador()
        {
            //Arrange

            var contexto = BaseDados.CriarContexto();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador
            {
                Id = 1,
                Email = "teste@gmail.com",
                Senha = "123456",
                Perfil = Perfil.Administrador
            };

            var administradorServico = new AdministradorServico(contexto);

            //Action

            await administradorServico.Adicionar(adm);

            //Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
            Assert.AreEqual("teste@gmail.com", adm.Email);
            Assert.AreEqual("123456", adm.Senha);
            Assert.AreEqual(Perfil.Administrador, adm.Perfil);
        }
    }
}
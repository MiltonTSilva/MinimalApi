using MininalApi.Dominio.Entidades;
using MinimalApi.Dominio.Enuns;

namespace Teste_MinimalApi.Dominio.Entidades
{
    [TestClass]
    public class AdministradorTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //Arrange
            var adm = new Administrador
            {
                Id = 1,
                Email = "teste@gmail.com",
                Senha = "123456",
                Perfil = Perfil.Administrador
            };

            //Action


            //Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("teste@gmail.com", adm.Email);
            Assert.AreEqual("123456", adm.Senha);
            Assert.AreEqual(Perfil.Administrador, adm.Perfil);
        }
    }
}
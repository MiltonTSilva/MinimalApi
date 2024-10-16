using MininalApi.Dominio.Entidades;

namespace Teste_MinimalApi.Dominio.Entidades
{


    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //Arrange
            var veiculo = new Veiculo
            {
               
                Id = 1,
                Nome = "Logan",
                Marca = "Renault",
                Ano = 1999
            };

            //Action

            //Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Logan", veiculo.Nome);
            Assert.AreEqual("Renault", veiculo.Marca);
            Assert.AreEqual(1999, veiculo.Ano);
        }
    }
}

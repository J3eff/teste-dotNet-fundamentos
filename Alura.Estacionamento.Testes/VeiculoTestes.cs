using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");
            veiculo = new Veiculo();
        }


        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarTipoDoVeiculo()
        {
            //var veiculo = new Veiculo();

            veiculo.Tipo = TipoVeiculo.Motocicleta;

            Assert.Equal(TipoVeiculo.Motocicleta, veiculo.Tipo);
        }

        [Fact(Skip = "Not implemented yet.")]
        public void ValidarNomeProprietarioDoVeiculo()
        {
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculos()
        {
            //Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veiculo:", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}

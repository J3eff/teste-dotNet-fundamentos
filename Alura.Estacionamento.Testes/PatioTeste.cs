using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Jefferson";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Jetta";
            veiculo.Placa = "abc-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Ack
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Jefferson Brandão", "ABC-9999", "preto", "Jetta")]
        [InlineData("Vanessa Barbosa", "DEF-9999", "Cinza", "Gol")]
        [InlineData("Jefferson Brandão", "GHI-9999", "Azul", "Fusca")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange            
            var veiculo = new Veiculo();
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            veiculo.Tipo = TipoVeiculo.Automovel;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Ack
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,string placa,string cor,string modelo)
        {
            //Arange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa= placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            // Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculoDoProprioVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; //Alterado
            veiculoAlterado.Modelo = "Opala";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }                
    }
}

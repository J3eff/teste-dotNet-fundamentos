using System;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        public Operador()
        {
            this.Matricula = new Guid().ToString().Substring(0, 8);
        }

        private string _matricula;
        private string _nome;

        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public override string ToString()
        {
            return $"Operador: {this.Nome} \n" +
                   $"Matricula: {this.Matricula}";
        }
    }
}

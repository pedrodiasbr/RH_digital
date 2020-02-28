using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_digital
{
    class Funcionario
    {
        public string Nome { get; set; }
        public DateTime Datanasc { get; set; }
        public double Cpf { get; set; }
        public char Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public double Salario { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }

        public Funcionario(string nome, DateTime datanasc, double cpf, char sexo, string nacionalidade, double salario, string cargo, bool ativo)
        {
            Nome = nome;
            Datanasc = datanasc;
            Cpf = cpf;
            Sexo = sexo;
            Nacionalidade = nacionalidade;
            Salario = salario;
            Cargo = cargo;
            Ativo = ativo;
        }

        public Funcionario()
        {

        }

    }
}

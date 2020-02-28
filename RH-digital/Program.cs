using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_digital
{
    class Program
    {
        static void Main()
        {

        }
    }

    public class Empregado
    {
        public string Nome { set; get; }
        public DateTime DataNascimento { set; get; }
        public string CPF { set; get; }
        public string Sexo { set; get; }
        public string Nacionalidade { set; get; }
        public decimal Salario { set; get; }
        public string Cargo { set; get; }
        public string Status { set; get; }
        public int NumeroPessoal { set; get; }
    }

    public class DBContext
    {

    }

    public enum StatusEmpregado
    {
        Ativo = 1,
        Afastado = 2,
        Aposentado = 3,
        Desligado = 4
    }

    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2,
        Outros = 3
    }
}
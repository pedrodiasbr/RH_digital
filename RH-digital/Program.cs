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
            DBContext db = new DBContext();
            string escolha;

            do
            {
                escolha = Menu();

                if (escolha == "1")
                {
                    var empregado = CriarEmpregado();
                }
                else if (escolha == "2")
                {

                }
                else if (escolha == "3")
                {

                }
                else if (escolha == "4")
                {

                }
                else if (escolha == "5")
                {

                }
                else if (escolha == "6")
                {

                }
                else if (escolha == "7")
                {

                }
                else if (escolha == "8")
                {

                }
                else if (escolha == "9")
                {

                }
                else if (escolha == "0")
                {
                    Console.WriteLine("Obrigado por utilizar o RH digital.");
                    Console.WriteLine("Pressione qualquer tecla para finalizar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Opcao invalida. Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                }
            } while (escolha != "0");
        }

        private static Empregado CriarEmpregado(int ultimoNumeroPessoal)
        {
            Console.WriteLine("Digite nome da pessoa:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite data de nascimento da pessoa:");
            DateTime dataNascimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o sexo da pessoa:");
            Console.WriteLine("1 - Feminino");
            Console.WriteLine("2 - Masculino");
            Console.WriteLine("3 - Outro");
            int sexo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite nacionalidade da pessoa:");
            int Nac = int.Parse(Console.ReadLine());


            Nacionalidade nacionalidade;
            if (Nac == 1)
            {
                nacionalidade = Nacionalidade.brasileira;
            }
            else
            {
                nacionalidade = Nacionalidade.Outras;
            }

            int estado = -1;
            string CPF;
            
            if (nacionalidade == Nacionalidade.brasileira)
            {
                Console.WriteLine("Digite estado/provincia em que a pessoa foi registrada:");
                estado = int.Parse(Console.ReadLine());

                //bug aqui como resolver: criar forma de a pessoa ser de outro pais e cadastrar seu estado como int e nao string
                Console.WriteLine("Digite o numero do registro da pessoa (equivalente ao CPF brasileiro):");
                CPF = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Digite estado em que a pessoa foi registrada:");
                estado = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o CPF da pessoa:");
                CPF = Console.ReadLine();
            }


            Console.WriteLine("Digite o salario da pessoa:");
            int salario = int.Parse ( Console.ReadLine() );
            
            Console.WriteLine("Digite o cargo da pessoa:");
            string cargo = Console.ReadLine();

            return new Empregado()
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Nacionalidade = nacionalidade,
                Estado = estado,
                CPF = CPF,
                Sexo = sexo,
                Salario = salario,
                Cargo = cargo,
                Status = 1,
                NumeroPessoal = ultimoNumeroPessoal + 1
            };
        }

        static string Menu()
        {
            Console.Clear();
            string escolha = "-1";
            Console.WriteLine("Escolha uma opcao:") ;
            Console.WriteLine("1 - Cadastrar Empregado");
            Console.WriteLine("2 - Alterar Salario");
            Console.WriteLine("3 - Desligar empregado");
            Console.WriteLine("4 - Ver folha de pagamento");
            Console.WriteLine("5 - Ver Salarios por Sexo");
            Console.WriteLine("6 - Ver Empregado mais velho");
            Console.WriteLine("7 - Ver Empregado mais novo");
            Console.WriteLine("8 - Ver Empregados ordenados por idade");
            Console.WriteLine("9 - Ver Empregado por nacionalidade");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair do programa");
            escolha = Console.ReadLine();

            return escolha;
        }
    }

    public class Empregado
    {
        public string Nome { set; get; }
        public DateTime DataNascimento { set; get; }
        public Nacionalidade Nacionalidade { set; get; }
        public int Estado { set; get; }
        public string CPF { set; get; }
        public int Sexo { set; get; }
        public decimal Salario { set; get; }
        public string Cargo { set; get; }
        public int Status { set; get; }
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
        Feminino = 1,
        Masculino = 2,
        Outros = 3
    }

    public enum Estado
    {
        #region Centro Oeste
        Goiás = 1,
        Mato_Grosso = 2,
        Mato_Grosso_do_Sul = 3,
        Distrito_Federal = 27,
        #endregion

        #region Nordeste
        Bahia = 4,
        Piauí = 5,
        Paraíba = 6,
        Maranhão = 7,
        Pernambuco = 8,
        Ceará = 9,
        Rio_Grande_do_Norte = 10,
        Alagoas = 11,
        Sergipe = 12,
        #endregion

        #region Norte
        Pará = 13,
        Tocantins = 14,
        Amazonas = 15,
        Rondônia = 16,
        Acre = 17,
        Amapá = 18,
        Roraima = 19,
        #endregion

        #region Sudeste
        Minas_Gerais = 20,
        São_Paulo = 21,
        Rio_de_Janeiro = 22,
        Espírito_Santo = 23,
        #endregion

        #region Sul
        Rio_Grande_do_Sul = 24,
        Paraná = 25,
        Santa_Catarina = 26
        #endregion
    }
    public enum Nacionalidade 
    {
        brasileira = 1,
        Outras = 2
    }

}
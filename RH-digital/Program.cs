﻿using System;
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
                    var empregado = CriarEmpregado(1);
                    db.AddEmpregadoNaLista(empregado);
                    //impedir digitar cpf maior que 11 caracteres 
                    //se digitar um cpf menor que 11 preencher com zeros a esquerda ate o length ser 11.
                }
                else if (escolha == "2")
                {
                    db.AlterarSalario();
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
                else if (escolha == "10")
                {
                    //Opção apenas para testes
                    db.MostrarEmpregados();
                    Console.ReadKey();

                    ValidaCPF(Estado.Minas_Gerais, "11786525640");
                }
                else
                {
                    Console.WriteLine("Opção invalida. Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                }
            } while (escolha != "0");
        }

        private static Empregado CriarEmpregado(int ultimoNumeroPessoal)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da pessoa:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite data de nascimento da pessoa:");
            DateTime dataNascimento = new DateTime();
            try
            {
                dataNascimento = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Data inválida, favor tentar novamente.");
                Console.WriteLine("Mensagem para equipe tecnica: " + e.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }
            Console.WriteLine("Digite o sexo da pessoa:");
            Console.WriteLine("1 - Feminino");
            Console.WriteLine("2 - Masculino");
            Console.WriteLine("3 - Outro");
            int sexo = int.Parse(Console.ReadLine());
            while ((sexo > 3) || (sexo <= 0))
            {
                Console.Clear();
                Console.WriteLine("Digite o sexo da pessoa:");
                Console.WriteLine("1 - Feminino");
                Console.WriteLine("2 - Masculino");
                Console.WriteLine("3 - Outro");
                sexo = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Digite nacionalidade da pessoa.\n 1 - Brasileira\n 2 - Outra");
            int Nac = int.Parse(Console.ReadLine());
            while ((Nac > 2) || (Nac <= 0))
            {
                Console.WriteLine("Digite nacionalidade da pessoa.\n 1 - Brasileira\n 2 - Outra");
                Nac = int.Parse(Console.ReadLine());
            }


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


            Console.WriteLine("Digite o salário da pessoa:");
            decimal salario = int.Parse(Console.ReadLine());

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

        private static bool ValidaCPF(Estado estado, string CPF)
        {
            int[] posicao = new int [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int soma = CPF.ToArray().Sum(x => int.Parse(x.ToString()) * posicao[Convert.ToInt32(x)]);


                                 
            if (true)
            {

            }
            return false;
        }

        static string Menu()
        {
            Console.Clear();
            string escolha = "-1";
            Console.WriteLine("Escolha uma opção:");
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
        List<Empregado> ListaEmpregado = new List<Empregado>();
        public void AddEmpregadoNaLista(Empregado empregado)
        {
            ListaEmpregado.Add(empregado);
        }

        //Mostrar Empregados é criado apenas para teste.
        public void MostrarEmpregados()
        {
            for (int i = 0; i < ListaEmpregado.Count; i++)
            {
                Console.WriteLine("Empregados: " + ListaEmpregado[i].Nome);
            }
        }
        public void AlterarSalario()
        {
            string ConfereCpf;
            Console.WriteLine("Digite o CPF do empregado que deseja alterar o salário:");
            ConfereCpf = Console.ReadLine();
            var result = ListaEmpregado.FirstOrDefault(x => ConfereCpf == x.CPF);
            Console.WriteLine("Digite o novo cargo do empregado " + result.Nome);
            result.Cargo = Console.ReadLine();
            Console.WriteLine("Digite o novo salário");
            result.Salario = int.Parse(Console.ReadLine());
        }
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
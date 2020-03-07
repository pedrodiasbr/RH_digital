﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                }
                else if (escolha == "2")
                {
                    db.AlterarSalario();
                }
                else if (escolha == "3")
                {
                    db.DesligarFuncionario();
                }
                else if (escolha == "4")
                {
                    db.FolhaPagamento();
                }
                else if (escolha == "5")
                {
                    db.SalarioSexo();
                }
                else if (escolha == "6")
                {
                    db.EmpregadoMaisVelho();
                }
                else if (escolha == "7")
                {
                    db.EmpregadoMaisNovo();
                }
                else if (escolha == "8")
                {
                    db.OrderByIdade();
                }
                else if (escolha == "9")
                {
                    db.OrderByNacionalidade();
                }
                else if (escolha == "0")
                {
                    Console.WriteLine("Obrigado por utilizar o RH digital.");
                    Console.WriteLine("Pressione qualquer tecla para finalizar");
                    Console.ReadKey();
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
            while (nome == "")
            {
                Console.Clear();
                Console.WriteLine("Nome não pode ser vazio");
                Console.WriteLine("Digite o nome da pessoa:");
                nome = Console.ReadLine();
            }

            Console.WriteLine("Digite data de nascimento da pessoa: ('dd/MM/yyyy')");
            DateTime dataNascimento;
            var datavalida = DateTime
                   .TryParseExact(Console.ReadLine(),
                                   "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dataNascimento);

            while ((datavalida == false))
            {
                Console.Clear();
                Console.WriteLine("Data inválida, favor tentar novamente.");
                Console.WriteLine("Digite data de nascimento da pessoa: ('dd/MM/yyyy')");
                datavalida = DateTime
                   .TryParseExact(Console.ReadLine(),
                                   "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dataNascimento);

            }

            Console.WriteLine("Digite o sexo da pessoa:");
            Console.WriteLine("1 - Feminino");
            Console.WriteLine("2 - Masculino");
            Console.WriteLine("3 - Outro");
            string sexo = Console.ReadLine();
            while (sexo != "1" && sexo != "2" && sexo != "3")
            {
                Console.Clear();
                Console.WriteLine("Valor não econtrado, tente novamente. ");
                Console.WriteLine("Digite o sexo da pessoa:");
                Console.WriteLine("1 - Feminino");
                Console.WriteLine("2 - Masculino");
                Console.WriteLine("3 - Outro");
                sexo = Console.ReadLine();
            }
            Sexo Sexo = (Sexo)Enum.Parse(typeof(Sexo), sexo);

            string Nac;
            Console.WriteLine("Digite nacionalidade da pessoa.\n 1 - Brasileira\n 2 - Outra");

            Nac = Console.ReadLine();
            while (Nac != "1" && Nac != "2")
            {
                Console.Clear();
                Console.WriteLine("Valor não econtrado, tente novamente. ");
                Console.WriteLine("Digite nacionalidade da pessoa.\n 1 - Brasileira\n 2 - Outra");
                Nac = Console.ReadLine();
            }

            Nacionalidade nacionalidade;
            if (Nac == "1")
            {
                nacionalidade = Nacionalidade.Brasileira;
            }
            else
            {
                nacionalidade = Nacionalidade.Outras;
            }

            string CPF;
            Console.WriteLine("Digite o CPF da pessoa:");
            CPF = Console.ReadLine();
            CPF = CPF.Replace(".", "").Replace("-", "").Replace(" ", "");
            ValidandoCpf(CPF);
            while (ValidandoCpf(CPF) == false)
            {
                Console.Clear();
                Console.WriteLine("Erro, CPF não existe. Favor tentar novamente");
                Console.WriteLine("Digite o CPF da pessoa:");
                CPF = Console.ReadLine();
                CPF = CPF.Replace(".", "").Replace("-", "").Replace(" ", "");
                ValidandoCpf(CPF);
            }
            DBContext.VerificaCpfRepetido(CPF);
            while (DBContext.VerificaCpfRepetido(CPF) == true)
            {
                Console.Clear();
                Console.WriteLine("Erro, CPF já cadastrado, Favor tentar novamente");
                Console.WriteLine("Digite o CPF da pessoa:");
                CPF = Console.ReadLine();
                CPF = CPF.Replace(".", "").Replace("-", "").Replace(" ", "");
                DBContext.VerificaCpfRepetido(CPF);
            }

            double salario = 0;
            try
            {
                Console.WriteLine("Digite o salário da pessoa:");
                salario = double.Parse(Console.ReadLine());
                while (salario < 0)
                {
                    Console.ReadKey();
                    Console.WriteLine("Salário não pode ser negativo. Tente novamente.");
                    Console.WriteLine("Digite o salário da pessoa:");
                    salario = double.Parse(Console.ReadLine());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Valor não existente.\n O salário será definido como 0 (zero) e ao retornar ao menu, você pode alterar escolhendo a opção 2 ('dois')");
            }

            Console.WriteLine("Digite o cargo da pessoa:");
            string cargo = Console.ReadLine();
            while (cargo == "")
            {
                Console.Clear();
                Console.WriteLine("Cargo não pode ser vazio");
                Console.WriteLine("Digite o cargo da pessoa:");
                cargo = Console.ReadLine();
            }

            Console.WriteLine("Digite o status do empregado: \nAtivo = 1, \nAfastado = 2, \nAposentado = 3, \nDesligado = 4");
            string Status = Console.ReadLine();
            while (Status != "1" && Status != "2" && Status != "3" && Status != "4")
            {
                Console.Clear();
                Console.WriteLine("Valor não econtrado, tente novamente. ");
                Console.WriteLine("Digite o status do empregado: \nAtivo = 1, \nAfastado = 2, \nAposentado = 3, \nDesligado = 4");
                Status = Console.ReadLine();
            }
            StatusEmpregado StatusEmpregado = (StatusEmpregado)Enum.Parse(typeof(StatusEmpregado), Status);
            if (StatusEmpregado == StatusEmpregado.Desligado)
            {
                Console.WriteLine("O salário foi automaticamente zerado pois o usuário se encontra desligado.");
                salario = 0;
                Console.ReadKey();
            }

            return new Empregado()
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Nacionalidade = nacionalidade,
                CPF = CPF,
                Sexo = Sexo,
                Salario = salario,
                Cargo = cargo,
                Status = StatusEmpregado,
                NumeroPessoal = ultimoNumeroPessoal + 1
            };
        }

        public static bool ValidandoCpf(string CPF)
        {
            int multiplicador1 = 10;
            int multiplicador2 = 11;
            string temCPF;
            string Digito;
            int Soma;
            int Resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            temCPF = CPF.Substring(0, 9);
            Soma = 0;
            for (int i = 0; i < 9; i++)
            {
                Soma += int.Parse(temCPF[i].ToString()) * (multiplicador1 - i);
            }
            Resto = Soma % 11;
            if (Resto < 2)
            {
                Resto = 0;
            }
            else
            {
                Resto = 11 - Resto;
            }
            Digito = Resto.ToString();
            temCPF = temCPF + Digito;
            Soma = 0;
            for (int i = 0; i < 10; i++)
            {
                Soma += int.Parse(temCPF[i].ToString()) * (multiplicador2 - i);
            }
            Resto = Soma % 11;
            if (Resto < 2)
            {
                Resto = 0;
            }
            else
            {
                Resto = 11 - Resto;
            }
            Digito = Digito + Resto.ToString();
            return CPF.EndsWith(Digito);
        }

        static string Menu()
        {
            Console.Clear();
            string Escolha;
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
            Escolha = Console.ReadLine();

            return Escolha;
        }
    }
    public class Empregado
    {
        public string Nome { set; get; }
        public DateTime DataNascimento { set; get; }
        public Nacionalidade Nacionalidade { set; get; }
        public int Estado { set; get; }
        public string CPF { set; get; }
        public Sexo Sexo { set; get; }
        public double Salario { set; get; }
        public string Cargo { set; get; }
        public StatusEmpregado Status { set; get; }
        public int NumeroPessoal { set; get; }
    }

    public class DBContext
    {
        public static List<Empregado> ListaEmpregado = new List<Empregado>();
        public void AddEmpregadoNaLista(Empregado empregado)
        {
            ListaEmpregado.Add(empregado);
        }

        public void AlterarSalario()
        {
            Console.Clear();
            Console.WriteLine("-------Altera Salário-------");
            string ConfereCpf = "";
            Console.WriteLine("Digite o CPF do empregado que deseja alterar o salário:");
            Console.WriteLine("(Obs. Favor digitar o CPF sem '.','-' ou espaçamentos)");
            ConfereCpf = Console.ReadLine();
            try
            {
                var result = ListaEmpregado.FirstOrDefault(x => ConfereCpf == x.CPF);
                if (result.Status == StatusEmpregado.Desligado)
                {
                    Console.WriteLine("Não é possível atribuir um salário para o(a) funcionário(a) " + result.Nome + " pois ele se encontra desligado da empresa.");
                }
                else
                {
                    Console.WriteLine("Digite o novo cargo do empregado " + result.Nome);
                    result.Cargo = Console.ReadLine();
                    Console.WriteLine("Digite o novo salário");
                    result.Salario = double.Parse(Console.ReadLine());
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Cpf não encontrado, tente novamente");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Salário inválido, tente novamente");
                Console.ReadKey();
            }
        }

        public void DesligarFuncionario()
        {
            Console.Clear();
            Console.WriteLine("-------Desligando Funcionário-------");
            string ConfereCpf;
            try
            {
                Console.WriteLine("Digite o CPF do empregado que deseja desligar:");
                Console.WriteLine("(Obs. Favor digitar o CPF sem '.','-' ou espaçamentos)");
                ConfereCpf = Console.ReadLine();
                var result = ListaEmpregado.FirstOrDefault(x => ConfereCpf == x.CPF);
                Console.WriteLine("O funcionário " + result.Nome + " está agora desligado e seu salário foi zerado.");
                StatusEmpregado StatusEmpregado = (StatusEmpregado)Enum.Parse(typeof(StatusEmpregado), "4");
                result.Status = StatusEmpregado;
                result.Salario = 0;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Cpf não encontrado, tente novamente");
            }

            Console.ReadKey();
        }
        public void OrderByIdade()
        {
            Console.Clear();
            Console.WriteLine("-------FUNCIONÁRIOS POR IDADE-------");
            var result = ListaEmpregado.OrderBy(x => DateTime.Now.Year - x.DataNascimento.Year);

            foreach (var item in result)
            {
                var idade = DateTime.Now.Year - item.DataNascimento.Year;
                if (item.DataNascimento.Month > DateTime.Now.Month && item.DataNascimento.Day > DateTime.Now.Day)
                {
                    idade--;
                }
                Console.WriteLine("Nome do empregado: " + item.Nome + "; Idade: " + (idade));
            }

            Console.ReadKey();
        }

        public void OrderByNacionalidade()
        {
            Console.Clear();
            Console.WriteLine("-------FUNCIONÁRIOS POR NACIONALIDADE-------");
            var result = ListaEmpregado.OrderBy(x => x.Nacionalidade);
            foreach (var item in result)
            {
                Console.WriteLine("Nome do empregado: " + item.Nome + "; Nacionalidade: " + item.Nacionalidade);
            }
            Console.ReadKey();
        }
        public void FolhaPagamento()
        {
            Console.Clear();
            Console.WriteLine("-------FOLHA DE PAGAMENTO-------");
            var result = ListaEmpregado.OrderBy(x => x.Salario);
            double Total = 0;
            double TotalComImposto = 0;
            foreach (var item in result)
            {
                double SalarioImposto = (0.55 * item.Salario + item.Salario);
                Console.WriteLine(item.Nome + "; Salário sem imposto: " + item.Salario + "; Salário com imposto: " + SalarioImposto);
                Total += item.Salario;
                TotalComImposto += SalarioImposto;
            }
            Console.WriteLine("Total sem imposto " + Total);
            Console.WriteLine("Total com imposto " + TotalComImposto);
            Console.ReadKey();
        }

        public void EmpregadoMaisVelho()
        {
            Console.Clear();
            Console.WriteLine("-------EMPREGADO MAIS VELHO-------");
            try
            {
                var result = ListaEmpregado.OrderBy(x => x.DataNascimento.Year).FirstOrDefault();
                var idade = DateTime.Now.Year - result.DataNascimento.Year;
                if (result.DataNascimento.Month > DateTime.Now.Month && result.DataNascimento.Day > DateTime.Now.Day)
                {
                    idade--;
                }
                Console.WriteLine("O empregado mais velho é o(a) " + result.Nome + " com " + (idade) + " anos de idade.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Não foi possível encontrar resultados pois não existe empregados cadastrados ainda.");
            }
            Console.ReadKey();
        }

        public void EmpregadoMaisNovo()
        {
            Console.Clear();
            Console.WriteLine("-------EMPREGADO MAIS NOVO-------");
            try
            {
                var result = ListaEmpregado.OrderByDescending(x => x.DataNascimento.Year).FirstOrDefault();
                var idade = DateTime.Now.Year - result.DataNascimento.Year;
                if (result.DataNascimento.Month > DateTime.Now.Month && result.DataNascimento.Day > DateTime.Now.Day)
                {
                    idade--;
                }
                Console.WriteLine("O empregado mais novo é o(a) " + result.Nome + " com " + (idade) + " anos de idade.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Não foi possível encontrar resultados pois não existe empregados cadastrados ainda.");
            }
            Console.ReadKey();
        }

        public void SalarioSexo()
        {
            Console.Clear();
            Console.WriteLine("-------SALÁRIO POR SEXO-------");
            
            double totFeminino = 0;
            Sexo Sexo = (Sexo)Enum.Parse(typeof(Sexo), "1");
            totFeminino = ListaEmpregado.Where(x => x.Sexo == Sexo).Sum(x => x.Salario);

            double totMasculino = 0;
            Sexo Sexo2 = (Sexo)Enum.Parse(typeof(Sexo), "2");
            totMasculino = ListaEmpregado.Where(x => x.Sexo == Sexo2).Sum(x => x.Salario);

            double totOutro = 0;
            Sexo Sexo3 = (Sexo)Enum.Parse(typeof(Sexo), "3");
            totOutro = ListaEmpregado.Where(x => x.Sexo == Sexo3).Sum(x => x.Salario);

            Console.WriteLine("O sexo Masculino da sua empresa recebe: " + totMasculino);
            Console.WriteLine("O sexo Feminino da sua empresa recebe: " + totFeminino);
            Console.WriteLine("O sexo 'outro' da sua empresa recebe: " + totOutro);
            Console.ReadKey();
        }

        public static bool VerificaCpfRepetido(string _cpf)
        {
            if (ListaEmpregado.Any(x => x.CPF == _cpf))
            {
                return true;
            }
            return false;
        }
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

public enum Nacionalidade
{
    Brasileira = 1,
    Outras = 2
}
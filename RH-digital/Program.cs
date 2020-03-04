using System;
using System.Collections.Generic;
using System.Globalization;
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
                else if (escolha == "10")
                {
                    //Opção apenas para testes
                    db.MostrarEmpregados();
                    Console.ReadKey();

                    //ValidaCPF(Estado.Minas_Gerais, "11786525640");
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
            while(nome == "")
            {
                Console.Clear();
                Console.WriteLine("Nome não pode ser vazio");
                Console.WriteLine("Digite o nome da pessoa:");
            }
            Console.WriteLine("Digite data de nascimento da pessoa: ('dd/MM/yyyy')");
            DateTime dataNascimento;
            var datavalida = DateTime
                   .TryParseExact(Console.ReadLine(),
                                   "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dataNascimento);
            while ((datavalida == false) || (dataNascimento > DateTime.Now))
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

            string Nac = "";
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
                nacionalidade = Nacionalidade.brasileira;
            }
            else
            {
                nacionalidade = Nacionalidade.Outras;
            }

            int Estado = -1;
            string CPF;

            if (nacionalidade == Nacionalidade.brasileira)
            {
                Console.WriteLine("Digite estado/provincia em que a pessoa foi registrada:");
                Estado = int.Parse(Console.ReadLine());

                //bug aqui como resolver: criar forma de a pessoa ser de outro pais e cadastrar seu estado como int e nao string
                Console.WriteLine("Digite o numero do registro da pessoa (equivalente ao CPF brasileiro):");
                CPF = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Digite estado em que a pessoa foi registrada:");
                Estado = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o CPF da pessoa:");
                CPF = Console.ReadLine();
            }

            double salario = 0;

            try
            {
                Console.WriteLine("Digite o salário da pessoa:");
                salario = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor não existente.\n O salário será definido como 0 (zero) e ao retornar ao menu, você pode alterar escolhendo a opção 2 ('dois')");
            }

            Console.WriteLine("Digite o cargo da pessoa:");
            string cargo = Console.ReadLine();
            while(cargo == "")
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
                Console.WriteLine("O salário foi automáticamente zerado pois o usuário se encontra desligado.");
                salario = 0;
                Console.ReadKey();
            }


            return new Empregado()
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Nacionalidade = nacionalidade,
                Estado = Estado,
                CPF = CPF,
                Sexo = Sexo,
                Salario = salario,
                Cargo = cargo,
                Status = StatusEmpregado,
                NumeroPessoal = ultimoNumeroPessoal + 1
            };
        }

        //private static bool ValidaCPF(Estado Estado, string CPF)
        //{
        //    int[] posicao = new int [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //    int soma = CPF.ToArray().Sum(x => int.Parse(x.ToString()) * posicao[Convert.ToInt32(x)]);



        //    if (true)
        //    {

        //    }
        //    return false;
        //}

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
        public Sexo Sexo { set; get; }
        public double Salario { set; get; }
        public string Cargo { set; get; }
        public StatusEmpregado Status { set; get; }
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
                Console.WriteLine("Empregados: " + ListaEmpregado[i].Salario);
            }
        }
        public void AlterarSalario()
        {
            Console.Clear();
            Console.WriteLine("-------Altera Salário-------");
            string ConfereCpf = "";
            Console.WriteLine("Digite o CPF do empregado que deseja alterar o salário:");
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
            Console.WriteLine("Total com imposto " + Total);
            Console.WriteLine("Total sem imposto " + TotalComImposto);

            Console.ReadKey();
        }
        public void EmpregadoMaisVelho()
        {
            Console.Clear();
            Console.WriteLine("-------EMPREGADO MAIS VELHO-------");
            var result = ListaEmpregado.OrderBy(x => x.DataNascimento.Year).FirstOrDefault();
            var idade = DateTime.Now.Year - result.DataNascimento.Year;
            if (result.DataNascimento.Month > DateTime.Now.Month && result.DataNascimento.Day > DateTime.Now.Day)
            {
                idade--;
            }
            Console.WriteLine("O empregado mais velho é o(a) " + result.Nome + " com " + (idade) + " anos de idade.");
            Console.ReadKey();
        }
        public void EmpregadoMaisNovo()
        {
            Console.Clear();
            Console.WriteLine("-------EMPREGADO MAIS NOVO-------");
            var result = ListaEmpregado.OrderByDescending(x => x.DataNascimento.Year).FirstOrDefault();
            var idade = DateTime.Now.Year - result.DataNascimento.Year;
            if (result.DataNascimento.Month > DateTime.Now.Month && result.DataNascimento.Day > DateTime.Now.Day)
            {
                idade--;
            }
            Console.WriteLine("O empregado mais novo é o(a) " + result.Nome + " com " + (idade) + " anos de idade.");
            Console.ReadKey();
        }
        public void SalarioSexo()
        {
            Console.Clear();
            Console.WriteLine("-------SALÁRIO POR SEXO-------");
            double totFeminino = 0;
            double totMasculino = 0;
            double totOutro = 0;
            Sexo Sexo = (Sexo)Enum.Parse(typeof(Sexo), "1");
            var result = ListaEmpregado.Where(x => x.Sexo == Sexo);
            foreach (var item in result)
            {
                totFeminino += item.Salario;
            }
            Sexo Sexo2 = (Sexo)Enum.Parse(typeof(Sexo), "2");
            var result2 = ListaEmpregado.Where(x => x.Sexo == Sexo2);
            foreach (var item2 in result2)
            {
                totMasculino += item2.Salario;
            }
            Sexo Sexo3 = (Sexo)Enum.Parse(typeof(Sexo), "3");
            var result3 = ListaEmpregado.Where(x => x.Sexo == Sexo3);
            foreach (var item3 in result3)
            {
                totOutro += item3.Salario;
            }
            Console.WriteLine("O sexo Masculino da sua empresa recebe: " + totMasculino);
            Console.WriteLine("O sexo Feminino da sua empresa recebe: " + totFeminino);
            Console.WriteLine("O sexo 'outro' da sua empresa recebe: " + totOutro);
            Console.ReadKey();

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


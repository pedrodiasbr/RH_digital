using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public enum TipoDeEntrada
    {
        Paciente = 1,
        Vacina = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            DBContext db = new DBContext();
            int escolha = 0;

            do
            {
                escolha = Menu();

                if (escolha == 1)
                {
                    var paciente = CriarPaciente();
                    var pacienteInserido = db.InserirPaciente(paciente);

                    if (pacienteInserido)
                        Console.WriteLine("Paciente inserido com sucesso!");
                    else
                        Console.WriteLine("Não foi possível inserir o paciente!");
                }
                else if (escolha == 2)
                {
                    var vacina = CriarVacina();
                    var vacinaInserida = db.InserirVacina(vacina);

                    if (vacinaInserida)
                        Console.WriteLine("Vacina inserida com sucesso!");
                    else
                        Console.WriteLine("Vacina não foi inserida!");
                }
                else if (escolha == 3)
                {
                    Console.Write("CPF do paciente para vacinar: ");
                    var cpfDoPaciente = int.Parse(Console.ReadLine());

                    Console.Write("Codigo da vacina: ");
                    var codigoDaVacina = int.Parse(Console.ReadLine());

                    var pacienteVacinado = db.VacinarPaciente(cpfDoPaciente, codigoDaVacina);

                    if (pacienteVacinado)
                        Console.WriteLine("Paciente vacinado com sucesso!");
                    else
                        Console.WriteLine("Não vacinamos o paciente! ");
                }
                else if (escolha == 4)
                {
                    db.Imprimir(TipoDeEntrada.Paciente); 
                }
                else if(escolha == 5)
                {
                    db.Imprimir(TipoDeEntrada.Vacina);
                }

                Console.ReadKey();
                Console.Clear();

            } while (escolha != 6);

        }

        private static Paciente CriarPaciente()
        {
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do paciente: ");
            int cpf = int.Parse(Console.ReadLine());

            return new Paciente()
            {
                CPF = cpf,
                Nome = nome,
                QtdeVacinasTomadas = 0
            };
        }

        private static Vacina CriarVacina()
        {
            Console.Write("Digite o nome da Vacina: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o código da vacina: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Quantidade de vacinas disponíveis: ");
            int qtdDisponivel = int.Parse(Console.ReadLine());

            return new Vacina()
            {
                Codigo = codigo,
                Nome = nome,
                QtdDosesDisponiveis = qtdDisponivel
            };
        }

        private static int Menu()
        {
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 Inserir Paciente");
            Console.WriteLine("2 Inserir Vacina");
            Console.WriteLine("3 Vacinar Paciente");
            Console.WriteLine("4 Consultar Paciente");
            Console.WriteLine("5 Consultar Vacinas");
            Console.WriteLine("6 para sair");
            Console.Write("Digite uma opção: ");

            return int.Parse(Console.ReadLine());

        }
    }

    public class DBContext
    {
        public static List<Paciente> lstPaciente = new List<Paciente>();
        public static List<Vacina> lstVacinas = new List<Vacina>();

        #region Métodos de Paciente

        public bool InserirPaciente(Paciente paciente)
        {
            if (!ExisteNaBase(paciente))
            {
                var lstPessoasVacinadas = lstPaciente.Where(x => x.QtdeVacinasTomadas > 0);

                lstPaciente.Add(paciente);
                return lstPaciente.FirstOrDefault(x => x.CPF == paciente.CPF).CPF > 0;
            }

            return false;
        }

        private bool ExisteNaBase(Paciente paciente)
        {
            if (lstPaciente.Any(x => x.CPF == paciente.CPF))
                return true;

            return false;
        }

        #endregion

        #region Métodos de Vacina
        public bool InserirVacina(Vacina vacina)
        {
            if (!ExisteNaBase(vacina))
            {
                lstVacinas.Add(vacina);
                return lstVacinas.FirstOrDefault(x => x.Codigo == vacina.Codigo).Codigo > 0;
            }

            return false;
        }

        public bool ExisteNaBase(Vacina vacina)
        {
            if (lstVacinas.Any(x => x.Codigo == vacina.Codigo))
                return true;

            return false;
        }

        public bool VacinarPaciente(int cpfDoPaciente, int codigoDaVacina)
        {
            var vacina = lstVacinas.FirstOrDefault(x => x.Codigo == codigoDaVacina);
            var paciente = lstPaciente.FirstOrDefault(x => x.CPF == cpfDoPaciente);

            if (vacina != null && paciente != null)
            {
                vacina.QtdDosesDisponiveis--;
                paciente.QtdeVacinasTomadas++;

                return true;
            }

            return false;
        }

        public void Imprimir(TipoDeEntrada entrada)
        {
            if (entrada == TipoDeEntrada.Paciente)
                lstPaciente.ForEach(item => Console.WriteLine($"{item.CPF} ==> {item.Nome} ==> {item.QtdeVacinasTomadas}"));
            else
                lstVacinas.ForEach(item => Console.WriteLine($"{item.Codigo} ==> {item.Nome} ==> {item.QtdDosesDisponiveis}"));
        }

        #endregion
    }

    public class Paciente
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int QtdeVacinasTomadas { get; set; }
    }

    public class Vacina
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int QtdDosesDisponiveis { get; set; }
    }
}
/*
Exercício de lista.


Você vai criar um sistema de RH de uma empresa.

Esse sistema, precisa de alguns dados dos funcionários, como:
   * Nome
   * Data de Nascimento (DateTime)
   * CPF (com validação real de CPF)
   * Sexo
   * Nacionalidade 
   * Salário 
   * Cargo
   * Status do funcionário na empresa (trabalhando ou desligado)

Será possível fazer algumas alterações nos dados do funcionário, como:
   * Alterar Salário (requer também alteração de cargo)
   * Desligar funcionário.

O sistema também permite ver relatórios.
Os relatórios são:
   * Ver folha de pagamento da empresa 
            * Esse relatório mostrará cada funcionário e o salário dele sem imposto e com imposto (imposto é o cálculo de 55% do salário). No final, mostrará o total da folha da empresa com e sem imposto. Ex:
1 ==> Filipi ==> 10000 ==> 15500
2 ==> Lucas ==> 12000 ==> 18600

Total sem imposto ==> 22000
Total com imposto ==> 34100

    * Ver salário por sexo. Ex: O sexo Masculino da sua empresa recebe 7500 e o sexo feminino 8200
    * Buscar o funcionário mais velho da empresa
    * Buscar o funcionário mais novo da empresa
    * Buscar todos os funcionários ordenados pela idade.
     * Buscar todos os funcionários pela nacionalidade 
      
Obs: funcionários desligados não recebem salários mas devem aparecer nas pesquisas.*/
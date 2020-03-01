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
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
                else if(escolha == "2")
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
            } while ( escolha != "0");
        }

        private static Empregado CriarEmpregado(int ultimoNumeroPessoal)
        {
            Console.WriteLine("Digite nome da pessoa:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite data de nascimento da pessoa:");
            DateTime dataNascimento = Convert.ToDateTime( Console.ReadLine() );

            Console.WriteLine("Digite o sexo da pessoa:");
            Console.WriteLine("1 - Feminino");
            Console.WriteLine("2 - Masculino");
            Console.WriteLine("3 - Outro");
            int sexo = int.Parse( Console.ReadLine() );

            int nacionalidade = -1;
            Console.WriteLine("Digite nacionalidade da pessoa:");
            nacionalidade = int.Parse( Console.ReadLine() );

            int estado = -1;
            string CPF;
            if (nacionalidade == 30)
            {
                Console.WriteLine("Digite estado em que a pessoa foi registrada:");
                estado = int.Parse( Console.ReadLine() );

                Console.WriteLine("Digite o CPF da pessoa:");
                CPF = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Digite estado/provincia em que a pessoa foi registrada:");
                estado = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o numero do registro da pessoa (equivalente ao CPF brasileiro):");
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
        public int Nacionalidade { set; get; }
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
        afegà = 1,
        sul_Africana = 2,
        albanesa = 3,
        alemã = 4,
        andorrana = 5,
        angolana = 6,
        anguilana = 7,
        antiguana = 8,
        antilhana = 9,
        arabeSaudita = 10,
        argelina = 11,
        argentina = 12,
        armenia = 13,
        arubana = 14,
        australiana = 15,
        austriaca = 16,
        azeri = 17,
        baamiana = 18,
        barenita = 19,
        bangladechiana = 20,
        barbadense = 21,
        belga = 22,
        belizenha = 23,
        beninesea = 24,
        bermudense = 25,
        bielorrussa = 26,
        boliviana = 27,
        bosnia = 28,
        botsuana = 29,
        brasileira = 30,
        bruneína = 31,
        búlgara = 32,
        burquina = 33,
        burundiana = 34,
        butanesa = 35,
        caboVerdiana = 36,
        camaronesa = 37,
        cambojana = 38,
        canadiana = 39,
        catariana = 40,
        cazaque = 41,
        chadiana = 42,
        tcheca = 43,
        chilena = 44,
        china = 45,
        cipriota = 46,
        colombiana = 47,
        comoriana = 48,
        norteCoreana = 49,
        sulCoreana = 50,
        marfinense = 51,
        costarriquenha = 52,
        croata = 53,
        cubana = 54,
        curaçauense = 55,
        dinamarquesa = 56,
        jibutiana = 57,
        dominiqua = 58,
        egípcia = 59,
        salvadorenha = 60,
        emiradense = 61,
        equatoriana = 62,
        eritreia = 63,
        escocesa = 64,
        eslovaca = 65,
        eslovena = 66,
        suazilandêa = 67,
        micronésia = 68,
        norteAmericana = 69,
        estonia = 70,
        etiope = 71,
        fijiana = 72,
        filipino = 73,
        finlandesa = 74,
        nepalesa = 75,
        espanhola = 76,
        turquense = 77,
        francesa = 78,
        gabonesa = 79,
        gambiana = 80,
        ganesa = 81,
        georgiana = 82,
        granadina = 83,
        grega = 84,
        guadalupense = 85,
        guamesa = 86,
        guatemalteca = 87,
        guianesa = 88,
        guianense = 89,
        guineana = 90,
        guineuEquatoriana = 91,
        guineense = 92,
        haitiana = 93,
        hondurenha = 94,
        honconguesa = 95,
        húngara = 96,
        iemenita = 97,
        caimanesa = 98,
        cookense = 99,
        faroense = 100,
        salomonense = 101,
        virginenseAmericana = 102,
        virginenseBritanica = 103,
        indiana = 104,
        indonésia = 105,
        inglesa = 106,
        iraniana = 107,
        iraquiana = 108,
        irlandesa = 109,
        norteIrlandesa = 110,
        islanda = 111,
        israelense = 112,
        Italiana = 113,
        jamaicana = 114,
        japona = 115,
        jordana = 116,
        quiribatiana = 117,
        kosovar = 118,
        kuwaitiana = 119,
        laociana = 120,
        lesotiana = 121,
        letã = 122,
        libanesa = 123,
        liberiana = 124,
        libia = 125,
        listenstainiana = 126,
        lituana = 127,
        luxemburguesa = 128,
        macaense = 129,
        macedonica = 130,
        malgaxe = 131,
        malaia = 132,
        malauiana = 133,
        maldiva = 134,
        maliano = 135,
        maltesa = 136,
        marroquina = 137,
        martinicana = 138,
        mauriciana = 139,
        mauritana = 140,
        mexicana = 141,
        birmanesa = 142,
        moçambicana = 143,
        moldava = 144,
        monegasca = 145,
        mongol = 146,
        montenegrina = 147,
        monserratense = 148,
        namibiana = 149,
        nauruana = 150,
        nicaraguense = 151,
        nigerina = 152,
        nigeriana = 153,
        norueguesa = 154,
        neocaledónia = 155,
        neozelandesa = 156,
        omanense = 157,
        gala = 158,
        neerlandesa = 159,
        palauana = 160,
        palestiniana = 161,
        panamenha = 162,
        papua = 163,
        paquistanesa = 164,
        paraguaia = 165,
        peruana = 166,
        polinesia = 167,
        Polaca = 168,
        portoRiquenha = 169,
        portuguesa = 170,
        queniana = 171,
        quirguiz = 172,
        britânica = 173,
        centroAfricana = 174,
        congolesaDem = 175,
        congolesa = 176,
        dominicana = 177,
        romena = 178,
        ruandesa = 179,
        russa = 180,
        samoana = 181,
        samoense = 182,
        saoMarinhense = 183,
        santaLuciense = 184,
        saoCristovense = 185,
        saoMartinhenseFranca = 186,
        saoMartinhensePaisesBaixos = 187,
        saoTomense = 188,
        saoVicentina = 189,
        seichelense = 190,
        senegalesa = 191,
        serraLeonesa = 192,
        servia = 193,
        singapurense = 194,
        siria = 195,
        somali = 196,
        cingalesa = 197,
        sudanesa = 198,
        sueca = 199,
        suica = 200,
        surinamesa = 201,
        tailandês = 202,
        taiwanesaTaipe = 203,
        taiwanesa = 204,
        tajique = 205,
        tanzaniana = 206,
        timorense = 207,
        togolesa = 208,
        tonganesa = 209,
        trinitariaTobagense = 210,
        tunisina = 211,
        turquemena = 212,
        turca = 213,
        tuvaluana = 214,
        ucraniana = 215,
        ugandense = 216,
        uruguaia = 217,
        usbeque = 218,
        vanuatuense = 219,
        vaticana = 220,
        venezuelana = 221,
        vietnamita = 222,
        zambiana = 223,
        zimbabuana = 224,
        apatrida = 0
    }

}
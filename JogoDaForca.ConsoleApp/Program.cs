using System.Net.Quic;
using System.Security.Cryptography;

namespace JogoDaForca.ConsoleApp;

/*
Requisitos
1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
assim como as letras erradas.
3. O jogador poderá cometer até cinco erros, caso erre pela quinta vez, ou acerte a palavra a partida acaba.
4. Deve-se apresentar um desenho da forca sendo atualizado a cada erro.
*/

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {

            ExibirCabecalho();

            //1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
            string palavraAleatoria = EscolherPalavraAleatoria();


            //2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
            //assim como as letras erradas.
            char[] letrasAcertadas = PreencherLetrasAcertadas(palavraAleatoria);


            //3. O jogador poderá cometer até cinco erros, caso erre pela quinta vez, ou acerte a palavra a partida acaba.
            ExecutarTentativas(letrasAcertadas, palavraAleatoria);

            //4. Deve-se apresentar um desenho da forca sendo atualizado a cada erro.



            if (!JogadorDesejaContinuar())
                break;
        }
    }

    static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("------------------------");
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("------------------------");
        Console.WriteLine(@" _____        ");
        Console.WriteLine(@" |/        |        ");
        Console.WriteLine(@" |         o        ");
        Console.WriteLine(@" |        /|\       ");
        Console.WriteLine(@" |         |        ");
        Console.WriteLine(@" |        / \       ");
        Console.WriteLine(@" |                  ");
        Console.WriteLine(@" |                  ");
        Console.WriteLine(@"|_              ");
    }

    static string EscolherPalavraAleatoria()
    {
        string[] palavras =
        {
            "ABACATE","ABACAXI","ACEROLA","ACAI","ARACA","BACABA","BACURI",
            "BANANA","CAJA","CAJU","CARAMBOLA","CUPUACU","GRAVIOLA","GOIABA",
            "JABUTICABA","JENIPAPO","MACA","MANGABA","MANGA","MARACUJA",
            "MURICI","PEQUI","PITANGA","PITAYA","SAPOTI","TANGERINA",
            "UMBU","UVA","UVAIA"
        };

        int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);
        return palavras[indiceAleatorio];
    }

    static char[] PreencherLetrasAcertadas(string palavraAleatoria)
    {
        char[] letrasAcertadas = new char[palavraAleatoria.Length];

        for (int i = 0; i < letrasAcertadas.Length; i++)
            letrasAcertadas[i] = '_';

        return letrasAcertadas;
    }

    static void ExecutarTentativas(char[] letrasAcertadas, string palavraAleatoria)
    {


        bool jogadorAcertouPalavra = false;
        bool jogadorPerdeu = false;
        int quantidadeErros = 0;



        while (!jogadorAcertouPalavra && !jogadorPerdeu)
        {
            DesenharForca(quantidadeErros);

            Console.WriteLine("Palavra: " + string.Join(" ", letrasAcertadas));
            Console.WriteLine("Erros cometidos: " + quantidadeErros);

            if (quantidadeErros == 5)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"Voce PERDEU! A palavra era {palavraAleatoria}.");
                Console.WriteLine("--------------------");
                break;
            }

            Console.Write("\nDigite uma letra: ");
            string? strLetra = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(strLetra))
            {
                Console.WriteLine("Digite um caractere válido.");
                Console.ReadLine();
                continue;
            }

            char letraChute = char.ToUpper(strLetra[0]);
            bool letraFoiEncontrada = false;

            for (int contador = 0; contador < palavraAleatoria.Length; contador++)
            {
                if (letraChute == palavraAleatoria[contador])
                {
                    letrasAcertadas[contador] = palavraAleatoria[contador];
                    letraFoiEncontrada = true;
                }
            }

            if (!letraFoiEncontrada)
                quantidadeErros++;

            jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
            jogadorPerdeu = quantidadeErros > 5;



            if (jogadorAcertouPalavra)
            {
                DesenharForca(quantidadeErros);

                Console.WriteLine("Palavra: " + string.Join(" ", letrasAcertadas));
                Console.WriteLine("Erros cometidos: " + quantidadeErros);

                Console.WriteLine("--------------------");
                Console.WriteLine($"Você acertou! A palavra secreta era {palavraAleatoria}.");
                Console.WriteLine("--------------------");
            }


        }
    }

    static void DesenharForca(int quantidadeErros)
    {
        Console.Clear();
        Console.WriteLine("------------------------");
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("------------------------");

        if (quantidadeErros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |       ");
            Console.WriteLine(@" |                 ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        /         ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|    PERDEU!!!!  ");
        }

        Console.WriteLine("------------------------");
    }

    static bool JogadorDesejaContinuar()
    {
        Console.WriteLine("Deseja continuar o jogo? (s/n)");
        string? opcaoContinuar = Console.ReadLine();

        if (opcaoContinuar?.ToUpper() != "S")
            return false;

        return true;
    }
}


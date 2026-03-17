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
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("--------------------");

            //   1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.

            string palavraAleatoria = EscolherPalavraAleatoria();

            //2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
            //assim como as letras erradas.
            char[] letrasAcertadas = new char[palavraAleatoria.Length];

            for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
                letrasAcertadas[caractere] = '_';

            bool jogadorAcertouPalavra = false;
            bool jogadorPerdeu = false;

            int quantidadeErros = 0;

            while (!jogadorAcertouPalavra && !jogadorPerdeu)
            {

                Console.WriteLine("Palavra: " + string.Join(" ", letrasAcertadas));
                Console.WriteLine("Erros cometidos:  " + quantidadeErros);


                Console.Write("Digite uma letra: ");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite um caractere válido.");
                    Console.ReadLine();
                    continue;
                }

                char letraChute = Convert.ToChar(strLetra.ToUpper());

                bool letraFoiEncontrada = false;

                for (int contador = 0; contador < palavraAleatoria.Length; contador++)
                {
                    if (letraChute == palavraAleatoria[contador])
                        letrasAcertadas[contador] = palavraAleatoria[contador];
                    letraFoiEncontrada = true;

                }
                if (letraFoiEncontrada == false)
                    quantidadeErros++;



                jogadorAcertouPalavra = palavraAleatoria == string.Join(" ", letrasAcertadas);
                jogadorPerdeu = quantidadeErros > 5;

                if (jogadorAcertouPalavra)
                {

                    Console.WriteLine("--------------------");
                    Console.WriteLine($"Voce acertou! A palavra secreta era {palavraAleatoria}.");
                    Console.WriteLine("--------------------");
                }
                else if (jogadorPerdeu)
                {

                    Console.WriteLine("--------------------");
                    Console.WriteLine("Que azar! Tente novamente.");
                    Console.WriteLine("--------------------");
                }
                Console.ReadLine();
            }

            Console.WriteLine("Deseja continuar o jogo? (s/n)");
            string? opcaoContinuar = Console.ReadLine();

            if (opcaoContinuar?.ToUpper() != "S")
                break;
        }
    }

    static string EscolherPalavraAleatoria()
    {
        Console.WriteLine("Escolhendo palavra aleatória...");

        string[] palavras =
        {
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "ACAI",
            "ARACA",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJA",
            "CAJU",
            "CARAMBOLA",
            "CUPUACU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MACA",
            "MANGABA",
            "MANGA",
            "MARACUJA",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
        };

        int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);

        return palavras[indiceAleatorio];
    }
}
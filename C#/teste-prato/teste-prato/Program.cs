using System;
using teste_prato.Models;
using teste_prato.Utils;

namespace teste_prato
{
    public class Program
    {
        private static FilaPerguntas fila = new FilaPerguntas();
        public static int finalizar = 0;
        public static string confirmation = "n";
        public static string perguntaNomePrato = "Qual prato você pensou?";
        public static string perguntaCaracPrato = "{0} é _____, mas {1} não.";
        static void Main(string[] args)
        {
            Inicializacao();
            Run();
        }

        private static void Run()
        {
            fila.setCount(0);
            confirmation = "n";
            Console.WriteLine("Pense em um prato que gosta");
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
            PercorrerFila(fila);


            Run();

        }

        private static void Inicializacao()
        {
            Pergunta perguntaMassa = new Pergunta(new Prato("Massa", ""));
            perguntaMassa.filaPerguntas = new FilaPerguntas();
            perguntaMassa.filaPerguntas.push(new Pergunta(new Prato("Lasanha", "")));
            fila.push(new Pergunta(new Prato("Bolo de Chocolate", "")));
            fila.push(perguntaMassa);
        }

        private static void CriarNovaPergunta(FilaPerguntas filaAtual)
        {
            Console.WriteLine(perguntaNomePrato);
            Console.WriteLine();
            String nomePratoNovo = Console.ReadLine();

            Console.WriteLine(string.Format(perguntaCaracPrato, nomePratoNovo, filaAtual.tail().prato.nome));
            Console.WriteLine();
            String caracPratoNovo = Console.ReadLine();

            if (nomePratoNovo != null || caracPratoNovo != null)
            {
                Prato novoPrato = new Prato(nomePratoNovo, caracPratoNovo);

                Pergunta novaPergunta = new Pergunta(novoPrato);

                filaAtual.push(novaPergunta);

                Run();
            }
            else
            {
                Console.WriteLine("Você não digitou o nome ou a caracteristica do Prato.");
            }
        }

        private static void PercorrerFila(FilaPerguntas filaAtual)
        {
            filaAtual.setCount(0);
            while (confirmation != "s")
            {
                confirmation = "n";
                if (filaAtual.size() <= filaAtual.getCount()) break;


                Pergunta pergunta = filaAtual.next();
                Console.WriteLine(pergunta.pergunta + "S(Sim)/N(Não)");
                Console.WriteLine();
                confirmation = Console.ReadLine().ToLower();
                Console.WriteLine();

                if ((confirmation == "n" && filaAtual.size() == filaAtual.getCount()))
                {
                    CriarNovaPergunta(filaAtual);
                    break;
                }
                else if (confirmation == "s" && filaAtual.size() > filaAtual.getCount() && (pergunta.filaPerguntas != null && pergunta.filaPerguntas.size() > 0))
                {
                    confirmation = "n";
                    PercorrerFila(pergunta.filaPerguntas);
                    break;
                }
                else if (confirmation == "s" && (filaAtual.size() == filaAtual.getCount() || pergunta.filaPerguntas.size() == 0))
                {

                    Console.WriteLine("Acertei de novo");
                    break;
                }
                else
                {
                    Console.WriteLine("Você digitou um valor invalido");
                    break;
                }

            }


        }
    }
}

using System;
using teste_prato.Models;
using teste_prato.Utils;

namespace teste_prato
{
    class Program
    {
        private static FilaPerguntas fila = new FilaPerguntas();
        public static int finalizar = 0;
        public static int confirmation = 1;
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
            confirmation = 1;
            Console.WriteLine("Pense em um prato que gosta");
            Console.ReadKey();
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
            String nomePratoNovo = Console.ReadLine();

            Console.WriteLine(string.Format(perguntaCaracPrato, nomePratoNovo, filaAtual.tail().prato.nome));
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
                JOptionPane.showConfirmDialog(null, "Você não digitou o nome ou a caracteristica do Prato.", "Erro", JOptionPane.WARNING_MESSAGE);
            }
        }

        private static void PercorrerFila(FilaPerguntas filaAtual)
        {
            filaAtual.setCount(0);
            while (confirmation != 0)
            {
                confirmation = 1;
                if (filaAtual.size() <= filaAtual.getCount()) break;


                Pergunta pergunta = filaAtual.next();
                confirmation = JOptionPane.showConfirmDialog(null, pergunta.getPergunta(), "Confirm", JOptionPane.YES_NO_OPTION);

                if ((confirmation == 1 && filaAtual.size() == filaAtual.getCount()))
                {
                    CriarNovaPergunta(filaAtual);
                    break;
                }
                else if (confirmation == 0 && filaAtual.size() > filaAtual.getCount() && pergunta.getFilaPerguntas().size() > 0)
                {
                    confirmation = 1;
                    PercorrerFila(pergunta.getFilaPerguntas());
                    break;
                }
                else if (confirmation == 0 && (filaAtual.size() == filaAtual.getCount() || pergunta.getFilaPerguntas().size() == 0))
                {

                    JOptionPane.showMessageDialog(null, "Acertei de novo", "Teste Prato", JOptionPane.QUESTION_MESSAGE);
                    break;
                }

            }


        }
    }
}

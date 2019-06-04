using System.Collections.Generic;
using teste_prato.Models;

namespace teste_prato.Utils
{
    public class FilaPerguntas
    {
        private List<Pergunta> elements { get; set; }
        private int count = 0;


        public int getCount()
        {
            return count;
        }


        public void setCount(int count)
        {
            this.count = count;
        }


        public FilaPerguntas()
        {
            elements = new List<Pergunta>();

        }


        public bool push(Pergunta novaPergunta)
        {
            int indice = elements.Count == 0 ? 0 : elements.Count - 1;
            elements.Insert(indice, novaPergunta);
            return true;
        }


        public Pergunta top()
        {
            if (elements.Count == 0) return null;

            Pergunta pergunta = elements[0];

            return pergunta;
        }

        public Pergunta get(int index)
        {
            if (elements.Count == 0) return null;

            Pergunta pergunta = elements[index];

            return pergunta;
        }

        public Pergunta next()
        {
            if (elements.Count == 0) return null;

            Pergunta pergunta = elements[count];
            count++;
            return pergunta;
        }

        public Pergunta tail()
        {
            if (elements.Count == 0) return null;

            Pergunta pergunta = elements[elements.Count - 1];
            return pergunta;
        }

        public int size()
        {
            return elements.Count;
        }
    }
}

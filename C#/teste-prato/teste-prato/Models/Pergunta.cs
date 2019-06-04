using teste_prato.Utils;

namespace teste_prato.Models
{
    public class Pergunta
    {
        public Pergunta(Prato prato)
        {
            this.prato = prato;
        }

        public string pergunta
        {
            get
            {
                return string.Format("O prato que você pensou é {0}?", prato.nome);
            }
        }
        public Prato prato { get; set; }
        public FilaPerguntas filaPerguntas { get; set; }
    }
}

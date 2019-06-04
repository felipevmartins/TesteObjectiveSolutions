namespace teste_prato.Models
{
    public class Prato
    {
        public string nome { get; set; }
        public string caracteristica { get; set; }

        public Prato(string nome, string caracteristica)
        {
            this.nome = nome;
            this.caracteristica = caracteristica;
        }


    }
}

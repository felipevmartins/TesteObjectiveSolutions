using System;
using System.Collections.Generic;
using System.Text;

namespace teste_prato.Models
{
    public class Prato
    {
        private string v1;
        private string v2;

        public Prato(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string nome { get; set; }
        public string caracteristica { get; set; }
    }
}

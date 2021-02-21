using System;
using System.Collections.Generic;
using System.Text;
namespace Desafio05
{
    class Racao
    {
        public string nome { get; set; }
        public double peso { get; set; }
        public List<Porcao> porcoes { get; set; }
        public Racao()
        {
            porcoes = new List<Porcao>();
        }

    }
    public class Porcao
    {
        public double pesoGato { get; set; }
        public int quantidadeRacao { get; set; }
    }
}

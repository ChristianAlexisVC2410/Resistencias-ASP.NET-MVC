using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Resistencias.Models
{
    public class Resistencia
    {
        public string Banda1 { get; set; }
        public string Banda2 { get; set; }
        public string Banda3 { get; set; }
        public string Tolerancia { get; set; }
        public int ValorBanda1 { get; set; }
        public int ValorBanda2 { get; set; }
        public int ValorBanda3 { get; set; }
        public double ValorTorelancia { get; set; }
        public double Valor { get; set; }
        public double ValorMax { get; set; }
        public double ValorMin { get; set; }

        public Resistencia() { }
        public Resistencia(string b1, string b2, string b3, string t)
        {
            this.Banda1 = b1;
            this.Banda2 = b2;
            this.Banda3 = b3;
            this.Tolerancia = t;
        }
    }

    
}
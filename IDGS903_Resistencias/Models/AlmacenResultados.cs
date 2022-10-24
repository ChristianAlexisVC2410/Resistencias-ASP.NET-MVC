using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Resistencias.Models
{
    public class AlmacenResultados : List<Resistencia>
    {
        public double ValorBanda1 { get; set; }
        public double ValorBanda2 { get; set; }
        public double ValorBanda3 { get; set; }
        public double ValorTorelancia { get; set; }
        public double Valor { get; set; }
        public double ValorMax { get; set; }
        public double ValorMin { get; set; }

        public double Total { get; set; }


        public AlmacenResultados(double b1, double b2, double b3, double t )
        {
            this.ValorBanda1 = b1;
            this.ValorBanda2 = b2;
            this.ValorBanda3 = b3;
            this.ValorTorelancia = t;
 
        }


        public void CalcularValor()
        {
            this.Valor = ((this.ValorBanda1 * 10) + this.ValorBanda2)*this.ValorBanda3;
        }

        public void CalcularMax()
        {
            double por;
            por = this.Valor * this.ValorTorelancia;
            this.ValorMax = this.Valor + por;
        }

        public void CalcularMin()
        {
            double por;
            por = this.Valor * this.ValorTorelancia;
            this.ValorMin = this.Valor - por;
        }
    }
}
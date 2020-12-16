using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Service.Services
{
    public class TaxService
    {
        public decimal taxaJuros()=> 0.01m;


        public decimal calculaJuros(decimal valorInicial, int tempo) {

            decimal juros = valorInicial * (1 + taxaJuros());

            decimal result = (decimal)Math.Pow((double)juros, tempo);

            return result;
        }
    }
}

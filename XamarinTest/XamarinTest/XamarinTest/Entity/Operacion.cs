using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTest.Entity
{
    public class Operacion
    {
        public Operacion()
        {
            TipoOperacion = new TipoOperacion();
        }

        public double num1 { get; set; }
        public double num2 { get; set; }
        public string simbolo { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public double resultado { get; set; }

        public string FullOperacion => $"{TipoOperacion.nombre} de {num1} {simbolo} {num2} = {resultado}";
    }
}

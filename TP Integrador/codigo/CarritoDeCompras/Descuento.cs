using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class Descuento
    {
        public int codDescuento { get; set; }
        public int porsentaje { get; set; }

        public Descuento(int codDescuento, int valorDescuento)
        {
            this.codDescuento = codDescuento;
            this.porsentaje = valorDescuento;
        }
    }
}

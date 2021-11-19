using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class RepositorioDescuentos
    {
        public static List<Descuento> listaDescuentos = new List<Descuento>();

        public static void AgregarDescuentoALaLista(Descuento descuento)
        {
            listaDescuentos.Add(descuento);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class RepositorioProductos
    {
        public static List<Producto> listaProductos = new List<Producto>();

        public static void AgregarProductoALaLista(Producto producto)
        {
            listaProductos.Add(producto);
        }
    }
}

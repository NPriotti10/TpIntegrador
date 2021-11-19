using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class ItemProducto
    {
        public int cantidad { get; set; }
        public Producto producto { get; set; }
        

        public ItemProducto(int cantidad, Producto producto)
        {
            this.cantidad = cantidad;
            this.producto = producto;
        }

    }
}

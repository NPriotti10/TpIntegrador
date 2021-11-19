using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class Carrito
    {
        public int codCarrito { get; set; }
        public DateTime fecha { get; set; }

        public static List<ItemProducto> listaDeProductosEnCarrito = new List<ItemProducto>();
        public decimal precioTotal { get; set; }

        public static void AgregarProductoAlCarrito(ItemProducto producto)
        {
            listaDeProductosEnCarrito.Add(producto);
        }
        public void MostrarCarrito()
        {
            Console.WriteLine("Fecha: " + fecha + "\n");

            Console.WriteLine("Productos Seleccionados: \n");
            foreach(var productoAcutal in listaDeProductosEnCarrito)
            {
                Console.WriteLine(productoAcutal.cantidad + productoAcutal.producto.descripcion + " $" + productoAcutal.producto.precioUnitario);
            }

            Console.WriteLine("Precio Total: " + precioTotal + "\n");


        }
    }
}

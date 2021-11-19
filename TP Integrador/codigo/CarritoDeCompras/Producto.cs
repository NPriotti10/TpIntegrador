using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    class Producto
    {
        public int codProducto { get; set; }
        public string descripcion { get; set; }
        public decimal precioUnitario { get; set; }
        public int stockActual { get; set; }
              
       
        public void MostrarProducto()
        {
            Console.WriteLine("Codigo Producto: " + codProducto + "\n");
            Console.WriteLine("Nombre: " + descripcion + "\n");
            Console.WriteLine("Precio Unitario: " + precioUnitario + "\n");
            Console.WriteLine("Stock: " + stockActual + "\n");
            Console.WriteLine("---------------------------------------\n");
        } 

       
    }
}

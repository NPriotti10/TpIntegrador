using System;
using System.Collections.Generic;
namespace CarritoDeCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanciarValores();
            RegistrarCarro();
            
        }
        
        public static void RegistrarCarro()
        {
            
            Carrito carrito = new Carrito()
            {
                codCarrito = 1,
                fecha = DateTime.Now,
            };

            int opcion, num;
            do
            {
                int codigoIngresado, cantidadDeProductos, cantidadAEliminar;
                Producto productoSeleccionado = new Producto();
                Console.WriteLine("----MENU----");
                Console.WriteLine("Ingrese 1 si desea agregar un producto al carro: \n");                
                Console.WriteLine("Ingrese 2 si desea eliminar un producto del carro: \n");                
                Console.WriteLine("Ingrese 3 si desea ver el carro \n");
                Console.WriteLine("Ingrese 4 si tiene un cupon de descuento\n");
                Console.WriteLine("Ingrese 0 si desea continuar con la compra \n");
                opcion = int.Parse(Console.ReadLine());
                while(opcion < 0 || opcion > 4)
                {
                    Console.WriteLine("Ingrese una opcion valida");
                    opcion = int.Parse(Console.ReadLine());
                }

                if(opcion == 1)
                {

                    Console.WriteLine("Ingrese 1 si desea ver la lista de productos disponibles, de lo contrario " +
                        "precione cualquier tecla: \n");
                    num = int.Parse(Console.ReadLine());
                    if( num == 1)
                    {
                        foreach(var productoActual in RepositorioProductos.listaProductos)
                        {
                            if(productoActual.stockActual > 0)
                            {
                                productoActual.MostrarProducto();
                            }
                            
                        }
                    }
                    

                    Console.WriteLine("Ingrese el codigo del producto: \n");
                    codigoIngresado = int.Parse(Console.ReadLine());
                    foreach (var productoActual in RepositorioProductos.listaProductos)
                    {
                        if (codigoIngresado == productoActual.codProducto)
                        {
                            productoSeleccionado = productoActual;
                        }
                    }
                    Console.WriteLine("Ingrese la cantidad que desea: \n");
                    cantidadDeProductos = int.Parse(Console.ReadLine());

                    if (cantidadDeProductos > productoSeleccionado.stockActual)
                    {
                        Console.WriteLine("No hay disponible esa cantidad de productos. \n");
                        while(cantidadDeProductos > productoSeleccionado.stockActual)
                        {
                            Console.WriteLine("Ingrese nuevamente la cantidad que desea: \n");
                            cantidadDeProductos = int.Parse(Console.ReadLine());
                        }
                    }

                    ItemProducto itemProducto = new ItemProducto(cantidadDeProductos, productoSeleccionado);
                    Carrito.AgregarProductoAlCarrito(itemProducto);
                }
                if(opcion == 2)
                {
                    Console.WriteLine("Ingrese el codigo del producto que desea eliminar: \n");
                    codigoIngresado = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad que desea quitar del carro");
                    cantidadAEliminar = int.Parse(Console.ReadLine());

                    foreach(var itemActual in Carrito.listaDeProductosEnCarrito)
                    {
                        if(codigoIngresado == itemActual.producto.codProducto)
                        {
                            itemActual.cantidad = itemActual.cantidad - cantidadAEliminar;
                        }
                    }

                }
                decimal valorTotal = 0, valorPorProducto = 0;
                int codigoDescuento;
                int opcion2;
                if (opcion == 3)
                {
                    Console.WriteLine("Ingrese 1 si tiene un cupon de descuento: \n");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 1)
                    {
                        decimal descuento = 0;
                        Console.WriteLine("Ingrese el codigo del descuento: \n");
                        codigoDescuento = int.Parse(Console.ReadLine());
                        foreach (var itemActual in Carrito.listaDeProductosEnCarrito)
                        {
                            valorPorProducto = itemActual.producto.precioUnitario * itemActual.cantidad;
                            valorTotal = valorTotal + valorPorProducto;
                        }
                        foreach (var descuentoActual in RepositorioDescuentos.listaDescuentos)
                        {
                            if (codigoDescuento == descuentoActual.codDescuento)
                            {
                                descuento = valorTotal - ((valorTotal * descuentoActual.porsentaje) / 100);
                            }
                        }
                        valorTotal = valorTotal - descuento;
                        carrito.precioTotal = valorTotal;
                    }
                    else
                    {
                        foreach (var itemActual in Carrito.listaDeProductosEnCarrito)
                        {
                            valorPorProducto = itemActual.producto.precioUnitario * itemActual.cantidad;
                            valorTotal = valorTotal + valorPorProducto;
                        }
                        carrito.precioTotal = valorTotal;
                    }
                    carrito.MostrarCarrito();
                }              
                               

  
            } while (opcion != 0);
            RegistrarCarritoDto(carrito);
        }
        public static void RegistrarCarritoDto(Carrito carrito)
        {
            CarritoDto carritoDto = new CarritoDto()
            {
                fecha = carrito.fecha,
                precioTotal = carrito.precioTotal
            };
        }
        public static void AgregarAlCarro(ItemProducto itemProducto)
        {            
            Carrito carrito = new Carrito()
            {
                codCarrito = 1,
                fecha = DateTime.Now,

            }; 

        }
        public static void InstanciarValores()
        {
            //Productos
            Producto producto1 = new Producto()
            {
                codProducto = 1,
                descripcion = "Mate Camionero",
                precioUnitario = 970 ,
                stockActual = 12                             
                
            };
            Producto producto2 = new Producto()
            {
                codProducto = 2,
                descripcion = "Mate Torpedo",
                precioUnitario = 1230,
                stockActual = 8
            };
            Producto producto3 = new Producto()
            {
                codProducto = 3,
                descripcion = "Bombilla Alpaca",
                precioUnitario = 850,
                stockActual = 25
            };
            Producto producto4 = new Producto()
            {
                codProducto = 4,
                descripcion = "Bolso de Cuero",
                precioUnitario = 1950,
                stockActual = 5
            };
            Producto producto5 = new Producto()
            {
                codProducto = 5,
                descripcion = "Yerba Mate 1kg",
                precioUnitario = 720,
                stockActual = 15
            };

            RepositorioProductos.AgregarProductoALaLista(producto1);
            RepositorioProductos.AgregarProductoALaLista(producto2);
            RepositorioProductos.AgregarProductoALaLista(producto3);
            RepositorioProductos.AgregarProductoALaLista(producto4);
            RepositorioProductos.AgregarProductoALaLista(producto5);

            //Descuentos

            Descuento descuento1 = new Descuento(1, 25);
            Descuento descuento2 = new Descuento(2, 50);
            RepositorioDescuentos.AgregarDescuentoALaLista(descuento1);
            RepositorioDescuentos.AgregarDescuentoALaLista(descuento2);




        }
    }
}

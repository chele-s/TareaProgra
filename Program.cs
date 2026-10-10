//Agreguen sus nombres de nuevo a lo que agreguen y modifiquen de sus partes para tener todo organizado


// Owen (union de partes)
using System;
using System.IO;
using System.Globalization;

namespace TiendaMascotas
{
    public struct Producto
    {
        public int Id;
        public string Nombre;
        public float Precio;
        public int Cantidad;
    }

    class Program
    {
        const string RutaArchivo = "inventario.txt";

        static void Main(string[] args)
        {
            Producto[] inventario = new Producto[100];
            int total = 0;

            CargarInventario(inventario, ref total);

            bool salir = false;
            // Ibrahim (do-while y iteraciones)
            do
            {
                MostrarMenu();
                int opcion = LeerOpcionValida();
                switch (opcion)
                {
                    case 1:
                        AgregarProducto(inventario, ref total);
                        break;
                    case 2:
                        VenderProducto(inventario, total);
                        break;
                    case 3:
                        MostrarInventario(inventario, total);
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema... \n");
                        break;
                }
            } while (!salir);
        }

        // Original Gabriel, a cargo del que elija la parte 4 (Menu Principal) remodelar y mejorar esta parte porfasss
        static void MostrarMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("    TIENDA DE MASCOTAS - SISTEMA DE GESTION   ");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Vender Producto");
            Console.WriteLine("3. Mostrar Inventario");
            Console.WriteLine("4. Salir");
            Console.WriteLine("==============================================");
            Console.Write("Seleccione una opcion (1-4): ");
        }

        // Original de pablo, a cargo del que elija la parte 4 (Validaciones Transversales)
        static int LeerOpcionValida()
        {
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opcion invalida. Ingrese un numero entero entre 1 y 4: ");
                Console.ResetColor();
            }
            return opcion;
        }

        static float ValidarPrecio()
        {
            float precio;
            Console.Write("Ingrese el precio del producto: ");
            while (!float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio) || precio < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Precio invalido. Ingrese un valor numerico mayor o igual a 0: ");
                Console.ResetColor();
            }
            return precio;
        }

        static int ValidarCantidad()
        {
            int cantidad;
            Console.Write("Ingrese la cantidad en stock: ");
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Cantidad invalida. Ingrese un entero mayor o igual a 0: ");
                Console.ResetColor();
            }
            return cantidad;
        }

        // Original de cruz, remodelacion acargo del que elija la parte 2 (CRUD - Altas)
        static void AgregarProducto(Producto[] inventario, ref int total)
        {
            Console.WriteLine("\nModulo a cargo de Integrante 2 (Altas)\n");
        }

        // Gabriel (Persistencia - Cargar y Guardar Inventario)
        static void CargarInventario(Producto[] inventario, ref int total)
        {
            total = 0;
            if (!File.Exists(RutaArchivo))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[AVISO] El archivo 'inventario.txt' no existe. Se iniciara con inventario vacio.\n");
                Console.ResetColor();
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(RutaArchivo))
                {
                    string? linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linea))
                        {
                            continue;
                        }

                        if (total >= inventario.Length)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n[AVISO] Se alcanzo la capacidad maxima de 100 productos al cargar.\n");
                            Console.ResetColor();
                            break;
                        }

                        string[] datos = linea.Split(',');
                        if (datos.Length >= 4)
                        {
                            if (int.TryParse(datos[0].Trim(), out int id) &&
                                float.TryParse(datos[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out float precio) &&
                                int.TryParse(datos[3].Trim(), out int cantidad))
                            {
                                inventario[total].Id = id;
                                inventario[total].Nombre = datos[1].Trim();
                                inventario[total].Precio = precio;
                                inventario[total].Cantidad = cantidad;
                                total++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR AL ABRIR ARCHIVO] No se pudo procesar la lectura: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        static void GuardarInventario(Producto[] inventario, int total)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(RutaArchivo, false))
                {
                    for (int i = 0; i < total; i++)
                    {
                        sw.WriteLine($"{inventario[i].Id},{inventario[i].Nombre},{inventario[i].Precio.ToString("0.00", CultureInfo.InvariantCulture)},{inventario[i].Cantidad}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR AL GUARDAR ARCHIVO] No se pudo persistir el inventario: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        // Parte 3 (CRUD - Busqueda por ID)
        static int BuscarProductoPorId(Producto[] inventario, int total, int id)
        {
            for (int i = 0; i < total; i++)
            {
                if (inventario[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // Gabriel (Modulo de Ventas Transaccional)
        static void VenderProducto(Producto[] inventario, int total)
        {
            if (total == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[AVISO] No hay productos registrados en el inventario para vender.\n");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("              MODULO DE VENTAS                ");
            Console.WriteLine("==============================================");

            int idBuscado;
            Console.Write("Ingrese el ID del producto a vender: ");
            while (!int.TryParse(Console.ReadLine(), out idBuscado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID invalido. Ingrese un numero entero: ");
                Console.ResetColor();
            }

            int indice = BuscarProductoPorId(inventario, total, idBuscado);
            if (indice == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR] Producto con ID {idBuscado} no encontrado.\n");
                Console.ResetColor();
                return;
            }

            Producto prod = inventario[indice];
            if (prod.Cantidad <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR] El producto '{prod.Nombre}' no cuenta con stock disponible (Stock: 0).\n");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine($"Producto: {prod.Nombre}");
            Console.WriteLine($"Precio unitario: ${prod.Precio.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Stock disponible: {prod.Cantidad}");
            Console.WriteLine("----------------------------------------------");

            int cantidadVenta;
            Console.Write("Ingrese la cantidad a vender: ");
            while (!int.TryParse(Console.ReadLine(), out cantidadVenta) || cantidadVenta <= 0 || cantidadVenta > prod.Cantidad)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (cantidadVenta <= 0)
                {
                    Console.Write("Cantidad invalida. Debe ser mayor a 0: ");
                }
                else
                {
                    Console.Write($"Stock insuficiente. Solo hay {prod.Cantidad} disponibles. Ingrese una cantidad valida: ");
                }
                Console.ResetColor();
            }

            float totalPagar = prod.Precio * cantidadVenta;

            Console.WriteLine("\n---------------- RESUMEN DE COMPRA ----------------");
            Console.WriteLine($"ID: {prod.Id}");
            Console.WriteLine($"Producto: {prod.Nombre}");
            Console.WriteLine($"Cantidad: {cantidadVenta}");
            Console.WriteLine($"Precio unitario: ${prod.Precio.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Total a pagar: ${totalPagar.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine("---------------------------------------------------");

            Console.Write("¿Desea confirmar la venta? (S/N): ");
            string? respuesta = Console.ReadLine()?.Trim().ToUpper();
            while (respuesta != "S" && respuesta != "N")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opcion invalida. Ingrese 'S' para confirmar o 'N' para cancelar: ");
                Console.ResetColor();
                respuesta = Console.ReadLine()?.Trim().ToUpper();
            }

            if (respuesta == "N")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[VENTA CANCELADA] No se realizaron cambios en el inventario.\n");
                Console.ResetColor();
                return;
            }

            inventario[indice].Cantidad -= cantidadVenta;
            GuardarInventario(inventario, total);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n==================================================");
            Console.WriteLine("               COMPROBANTE DE VENTA               ");
            Console.WriteLine("==================================================");
            Console.WriteLine($"Fecha y Hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            Console.WriteLine($"ID Producto:  {prod.Id}");
            Console.WriteLine($"Descripcion:  {prod.Nombre}");
            Console.WriteLine($"Cantidad:     {cantidadVenta}");
            Console.WriteLine($"Precio Unit.: ${prod.Precio.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"TOTAL PAGADO: ${totalPagar.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Stock restante: {inventario[indice].Cantidad}");
            Console.WriteLine("==================================================");
            Console.WriteLine("          ¡Venta realizada con exito!             ");
            Console.WriteLine("==================================================\n");
            Console.ResetColor();
        }

        // Original de cruz, acargo del que elija la parte 2 (CRUD - Consulta de Inventario)
        static void MostrarInventario(Producto[] inventario, int total)
        {
            Console.WriteLine("\n==========================================================================");
            Console.WriteLine("                        INVENTARIO DE PRODUCTOS                           ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine(string.Format("{0,-8} | {1,-32} | {2,-12} | {3,-10}", "ID", "Nombre del Producto", "Precio ($)", "Cantidad"));
            Console.WriteLine("--------------------------------------------------------------------------");

            if (total == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay productos registrados en el inventario.");
                Console.ResetColor();
            }
            else
            {
                float valorTotalInventario = 0;
                for (int i = 0; i < total; i++)
                {
                    Console.WriteLine(string.Format("{0,-8} | {1,-32} | ${2,-11:F2} | {3,-10}", inventario[i].Id, inventario[i].Nombre, inventario[i].Precio, inventario[i].Cantidad));
                    valorTotalInventario += inventario[i].Precio * inventario[i].Cantidad;
                }

                Console.WriteLine("==========================================================================");
                Console.WriteLine($"Total de productos registrados: {total}");
                Console.WriteLine($"Valor total del inventario: ${valorTotalInventario.ToString("0.00", CultureInfo.InvariantCulture)}");
            }
            Console.WriteLine("==========================================================================\n");
        }
    }
}

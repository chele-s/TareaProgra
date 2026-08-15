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
        static void Main(string[] args)
        {
            bool salir = false;
            do
            {
                MostrarMenu();
                int opcion = LeerOpcionValida();
                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        VenderProducto();
                        break;
                    case 3:
                        MostrarInventario();
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema... \n");
                        break;
                }
            } while (!salir);
        }
        //Gabriel
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
        // Cruz
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

        static void AgregarProducto()
        {
            Console.WriteLine("\nMódulo a cargo de [Nombre del Estudiante - Integrante 4]\n");
        }

        static void VenderProducto()
        {
            Console.WriteLine("\nMódulo a cargo de [Nombre del Estudiante - Integrante 4]\n");
        }

        static void MostrarInventario()
        {
            string rutaArchivo = "inventario.txt";

            if (!File.Exists(rutaArchivo))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[ALERTA] El archivo 'inventario.txt' no se encuentra disponible.");
                Console.WriteLine("Verifique que el archivo exista en el directorio del programa.\n");
                Console.ResetColor();
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    Console.WriteLine("\n==========================================================================");
                    Console.WriteLine("                        INVENTARIO DE PRODUCTOS                           ");
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine(string.Format("{0,-8} | {1,-32} | {2,-12} | {3,-10}", "ID", "Nombre del Producto", "Precio ($)", "Cantidad"));
                    Console.WriteLine("--------------------------------------------------------------------------");

                    string? linea;
                    int totalRegistros = 0;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        string[] datos = linea.Split(',');
                        if (datos.Length >= 4)
                        {
                            if (int.TryParse(datos[0].Trim(), out int id) &&
                                float.TryParse(datos[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out float precio) &&
                                int.TryParse(datos[3].Trim(), out int cantidad))
                            {
                                string nombre = datos[1].Trim();
                                Console.WriteLine(string.Format("{0,-8} | {1,-32} | ${2,-11:F2} | {3,-10}", id, nombre, precio, cantidad));
                                totalRegistros++;
                            }
                        }
                    }

                    Console.WriteLine("==========================================================================");
                    Console.WriteLine($"Total de productos mostrados: {totalRegistros}");
                    Console.WriteLine("==========================================================================\n");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR AL ABRIR ARCHIVO] No se pudo procesar la lectura: {ex.Message}\n");
                Console.ResetColor();
            }
        }
    }
}

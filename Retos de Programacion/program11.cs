//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;

//    class Program11
//    {
//        static void Main(string[] args)
//        {
//            // Ejercicio principal
//            Console.WriteLine("=== Ejercicio Principal ===");
//            CreateAndDeleteFile();

//            // Dificultad extra (Gestión de ventas)
//            Console.WriteLine("\n=== Dificultad Extra (Gestión de Ventas) ===");
//            SalesManager salesManager = new SalesManager();
//            salesManager.Run();
//        }

//        static void CreateAndDeleteFile()
//        {
//            // Nombre del archivo basado en el usuario de GitHub
//            string fileName = "tu_usuario_github.txt";

//            // Crear el archivo y escribir en él
//            using (StreamWriter writer = new StreamWriter(fileName))
//            {
//                writer.WriteLine("Nombre: [Tu Nombre]");
//                writer.WriteLine("Edad: [Tu Edad]");
//                writer.WriteLine("Lenguaje de programación favorito: [Tu Lenguaje Favorito]");
//            }

//            // Leer y imprimir el contenido del archivo
//            using (StreamReader reader = new StreamReader(fileName))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    Console.WriteLine(line);
//                }
//            }

//            // Borrar el archivo
//            File.Delete(fileName);
//            Console.WriteLine("Archivo borrado.");
//        }
//    }

//    class SalesManager
//    {
//        private string fileName = "ventas.txt";

//        public void Run()
//        {
//            while (true)
//            {
//                Console.WriteLine("\n1. Añadir producto");
//                Console.WriteLine("2. Consultar productos");
//                Console.WriteLine("3. Actualizar producto");
//                Console.WriteLine("4. Eliminar producto");
//                Console.WriteLine("5. Calcular venta total");
//                Console.WriteLine("6. Calcular venta por producto");
//                Console.WriteLine("7. Salir");
//                Console.Write("Selecciona una opción: ");
//                string option = Console.ReadLine();

//                switch (option)
//                {
//                    case "1":
//                        AddProduct();
//                        break;
//                    case "2":
//                        ListProducts();
//                        break;
//                    case "3":
//                        UpdateProduct();
//                        break;
//                    case "4":
//                        DeleteProduct();
//                        break;
//                    case "5":
//                        CalculateTotalSales();
//                        break;
//                    case "6":
//                        CalculateSalesByProduct();
//                        break;
//                    case "7":
//                        File.Delete(fileName);
//                        Console.WriteLine("Archivo borrado. Saliendo...");
//                        return;
//                    default:
//                        Console.WriteLine("Opción no válida.");
//                        break;
//                }
//            }
//        }

//        private void AddProduct()
//        {
//            Console.Write("Nombre del producto: ");
//            string name = Console.ReadLine();
//            Console.Write("Cantidad vendida: ");
//            string quantity = Console.ReadLine();
//            Console.Write("Precio: ");
//            string price = Console.ReadLine();

//            using (StreamWriter writer = new StreamWriter(fileName, true))
//            {
//                writer.WriteLine($"{name}, {quantity}, {price}");
//            }
//            Console.WriteLine("Producto añadido.");
//        }

//        private void ListProducts()
//        {
//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("No hay productos registrados.");
//                return;
//            }

//            using (StreamReader reader = new StreamReader(fileName))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    Console.WriteLine(line);
//                }
//            }
//        }

//        private void UpdateProduct()
//        {
//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("No hay productos registrados.");
//                return;
//            }

//            List<string> products = File.ReadAllLines(fileName).ToList();
//            Console.Write("Nombre del producto a actualizar: ");
//            string name = Console.ReadLine();

//            bool found = false;
//            for (int i = 0; i < products.Count; i++)
//            {
//                if (products[i].StartsWith(name + ","))
//                {
//                    Console.Write("Nueva cantidad vendida: ");
//                    string quantity = Console.ReadLine();
//                    Console.Write("Nuevo precio: ");
//                    string price = Console.ReadLine();

//                    products[i] = $"{name}, {quantity}, {price}";
//                    File.WriteAllLines(fileName, products);
//                    Console.WriteLine("Producto actualizado.");
//                    found = true;
//                    break;
//                }
//            }

//            if (!found)
//            {
//                Console.WriteLine("Producto no encontrado.");
//            }
//        }

//        private void DeleteProduct()
//        {
//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("No hay productos registrados.");
//                return;
//            }

//            List<string> products = File.ReadAllLines(fileName).ToList();
//            Console.Write("Nombre del producto a eliminar: ");
//            string name = Console.ReadLine();

//            var productToRemove = products.FirstOrDefault(p => p.StartsWith(name + ","));
//            if (productToRemove != null)
//            {
//                products.Remove(productToRemove);
//                File.WriteAllLines(fileName, products);
//                Console.WriteLine("Producto eliminado.");
//            }
//            else
//            {
//                Console.WriteLine("Producto no encontrado.");
//            }
//        }

//        private void CalculateTotalSales()
//        {
//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("No hay productos registrados.");
//                return;
//            }

//            double total = 0;
//            using (StreamReader reader = new StreamReader(fileName))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    string[] parts = line.Split(',');
//                    double quantity = double.Parse(parts[1].Trim());
//                    double price = double.Parse(parts[2].Trim());
//                    total += quantity * price;
//                }
//            }

//            Console.WriteLine($"Venta total: {total}");
//        }

//        private void CalculateSalesByProduct()
//        {
//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("No hay productos registrados.");
//                return;
//            }

//            Console.Write("Nombre del producto: ");
//            string name = Console.ReadLine();

//            double total = 0;
//            using (StreamReader reader = new StreamReader(fileName))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    if (line.StartsWith(name + ","))
//                    {
//                        string[] parts = line.Split(',');
//                        double quantity = double.Parse(parts[1].Trim());
//                        double price = double.Parse(parts[2].Trim());
//                        total += quantity * price;
//                    }
//                }
//            }

//            if (total > 0)
//            {
//                Console.WriteLine($"Venta total para {name}: {total}");
//            }
//            else
//            {
//                Console.WriteLine($"No se encontraron ventas para {name}.");
//            }
//        }
//    }
//}

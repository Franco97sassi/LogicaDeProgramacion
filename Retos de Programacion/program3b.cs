//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static Dictionary<string, string> agenda = new Dictionary<string, string>();

//    static void Main()
//    {
//        while (true)
//        {
//            Console.WriteLine("\nAgenda de Contactos");
//            Console.WriteLine("1. Buscar contacto");
//            Console.WriteLine("2. Insertar contacto");
//            Console.WriteLine("3. Actualizar contacto");
//            Console.WriteLine("4. Eliminar contacto");
//            Console.WriteLine("5. Mostrar todos los contactos");
//            Console.WriteLine("6. Salir");
//            Console.Write("Seleccione una opción: ");
//            string opcion = Console.ReadLine();

//            switch (opcion)
//            {
//                case "1":
//                    BuscarContacto();
//                    break;
//                case "2":
//                    InsertarContacto();
//                    break;
//                case "3":
//                    ActualizarContacto();
//                    break;
//                case "4":
//                    EliminarContacto();
//                    break;
//                case "5":
//                    MostrarContactos();
//                    break;
//                case "6":
//                    return;
//                default:
//                    Console.WriteLine("Opción no válida.");
//                    break;
//            }
//        }
//    }

//    static void BuscarContacto()
//    {
//        Console.Write("Ingrese el nombre del contacto: ");
//        string nombre = Console.ReadLine();
//        if (agenda.ContainsKey(nombre))
//        {
//            Console.WriteLine($"Teléfono: {agenda[nombre]}");
//        }
//        else
//        {
//            Console.WriteLine("Contacto no encontrado.");
//        }
//    }

//    static void InsertarContacto()
//    {
//        Console.Write("Ingrese el nombre del contacto: ");
//        string nombre = Console.ReadLine();
//        Console.Write("Ingrese el teléfono: ");
//        string telefono = Console.ReadLine();

//        if (EsTelefonoValido(telefono))
//        {
//            agenda[nombre] = telefono;
//            Console.WriteLine("Contacto insertado.");
//        }
//        else
//        {
//            Console.WriteLine("Teléfono no válido.");
//        }
//    }

//    static void ActualizarContacto()
//    {
//        Console.Write("Ingrese el nombre del contacto: ");
//        string nombre = Console.ReadLine();
//        if (agenda.ContainsKey(nombre))
//        {
//            Console.Write("Ingrese el nuevo teléfono: ");
//            string telefono = Console.ReadLine();
//            if (EsTelefonoValido(telefono))
//            {
//                agenda[nombre] = telefono;
//                Console.WriteLine("Contacto actualizado.");
//            }
//            else
//            {
//                Console.WriteLine("Teléfono no válido.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Contacto no encontrado.");
//        }
//    }

//    static void EliminarContacto()
//    {
//        Console.Write("Ingrese el nombre del contacto: ");
//        string nombre = Console.ReadLine();
//        if (agenda.ContainsKey(nombre))
//        {
//            agenda.Remove(nombre);
//            Console.WriteLine("Contacto eliminado.");
//        }
//        else
//        {
//            Console.WriteLine("Contacto no encontrado.");
//        }
//    }

//    static void MostrarContactos()
//    {
//        if (agenda.Count == 0)
//        {
//            Console.WriteLine("No hay contactos en la agenda.");
//        }
//        else
//        {
//            foreach (var contacto in agenda)
//            {
//                Console.WriteLine($"{contacto.Key}: {contacto.Value}");
//            }
//        }
//    }

//    static bool EsTelefonoValido(string telefono)
//    {
//        return telefono.Length <= 11 && telefono.All(char.IsDigit);
//    }
//}
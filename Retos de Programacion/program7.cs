//using System;
//using System.Collections.Generic;
// namespace Retos_de_Programacion
//{



//    class Program7
//    {
//        static void Main()
//        {
//            Console.WriteLine("=== Implementación de Pila (Stack - LIFO) ===");
//            ImplementacionPila();

//            Console.WriteLine("\n=== Implementación de Cola (Queue - FIFO) ===");
//            ImplementacionCola();

//            Console.WriteLine("\n=== Simulación de Navegador Web (usando Pilas) ===");
//            //SimulacionNavegador();

//            Console.WriteLine("\n=== Simulación de Impresora Compartida (usando Colas) ===");
//            SimulacionImpresora();
//        }

//        static void ImplementacionPila()
//        {
//            Stack<string> pila = new Stack<string>();

//            // Introducir elementos (Push)
//            pila.Push("Elemento 1");
//            pila.Push("Elemento 2");
//            pila.Push("Elemento 3");

//            // Recuperar elementos (Pop)
//            Console.WriteLine("Elementos de la pila (LIFO):");
//            while (pila.Count > 0)
//            {
//                string elemento = pila.Pop();
//                Console.WriteLine(elemento);
//            }
//        }

//        static void ImplementacionCola()
//        {
//            Queue<string> cola = new Queue<string>();

//            // Introducir elementos (Enqueue)
//            cola.Enqueue("Elemento 1");
//            cola.Enqueue("Elemento 2");
//            cola.Enqueue("Elemento 3");

//            // Recuperar elementos (Dequeue)
//            Console.WriteLine("Elementos de la cola (FIFO):");
//            while (cola.Count > 0)
//            {
//                string elemento = cola.Dequeue();
//                Console.WriteLine(elemento);
//            }
//        }

//        static void SimulacionNavegador()
//        {
//            Stack<string> historial = new Stack<string>();
//            Stack<string> futuro = new Stack<string>();
//            string paginaActual = "";

//            while (true)
//            {
//                Console.WriteLine("\nPágina actual: " + (paginaActual == "" ? "Ninguna" : paginaActual));
//                Console.Write("Introduce una URL o escribe 'atrás', 'adelante' o 'salir': ");
//                string entrada = Console.ReadLine();

//                if (entrada.ToLower() == "salir")
//                {
//                    break;
//                }
//                else if (entrada.ToLower() == "atrás")
//                {
//                    if (historial.Count > 0)
//                    {
//                        futuro.Push(paginaActual);
//                        paginaActual = historial.Pop();
//                    }
//                    else
//                    {
//                        Console.WriteLine("No hay páginas anteriores.");
//                    }
//                }
//                else if (entrada.ToLower() == "adelante")
//                {
//                    if (futuro.Count > 0)
//                    {
//                        historial.Push(paginaActual);
//                        paginaActual = futuro.Pop();
//                    }
//                    else
//                    {
//                        Console.WriteLine("No hay páginas siguientes.");
//                    }
//                }
//                else
//                {
//                    if (paginaActual != "")
//                    {
//                        historial.Push(paginaActual);
//                    }
//                    paginaActual = entrada;
//                    futuro.Clear(); // Limpiar el futuro al navegar a una nueva página
//                }
//            }
//        }

//        static void SimulacionImpresora()
//        {
//            Queue<string> impresora = new Queue<string>();

//            while (true)
//            {
//                Console.Write("Introduce el nombre de un documento o escribe 'imprimir' o 'salir': ");
//                string entrada = Console.ReadLine();

//                if (entrada.ToLower() == "salir")
//                {
//                    break;
//                }
//                else if (entrada.ToLower() == "imprimir")
//                {
//                    if (impresora.Count > 0)
//                    {
//                        string documento = impresora.Dequeue();
//                        Console.WriteLine("Imprimiendo: " + documento);
//                    }
//                    else
//                    {
//                        Console.WriteLine("No hay documentos en la cola.");
//                    }
//                }
//                else
//                {
//                    impresora.Enqueue(entrada);
//                    Console.WriteLine("Documento añadido: " + entrada);
//                }
//            }
//             }
//        }
//}
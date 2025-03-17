//using System;

//namespace Retos_de_Programacion
//{
//    class Program3
//    {


//        // Creación de un array
//        static int[] numeros = new int[5] { 1, 2, 3, 4, 5 };

//        static void Main(string[] args)
//        {
//            // Inserción (no se puede cambiar el tamaño de un array, pero se puede modificar un elemento)
//            numeros[0] = 10;

//            // Actualización
//            numeros[1] = 20;

//            // Borrado (no se puede borrar un elemento, pero se puede asignar un valor por defecto)
//            numeros[2] = 0;

//            // Ordenación
//            Array.Sort(numeros);

//            // Mostrar el array
//            Console.WriteLine("Array:");
//            foreach (int num in numeros)
//            {
//                Console.WriteLine(num);
//            }





//            // Creación de una lista
//            List<int> numerosLista = new List<int> { 1, 2, 3, 4, 5 };

//            // Manipulación de la lista
//            numerosLista.Add(6); // Inserción
//            numerosLista[0] = 10; // Actualización
//            numerosLista.Remove(3); // Borrado
//            numerosLista.Sort(); // Ordenación

//            // Mostrar la lista
//            Console.WriteLine("Lista:");
//            foreach (int num in numerosLista)
//            {
//                Console.WriteLine(num);
//            }


//            // Creación de un diccionario
//            Dictionary<string, int> edades = new Dictionary<string, int>
//            {
//                { "Juan", 25 },
//                { "Ana", 30 }
//            };

//            // Manipulación del diccionario
//            edades.Add("Carlos", 28); // Inserción
//            edades["Juan"] = 26; // Actualización
//            edades.Remove("Ana"); // Borrado

//            // Mostrar el diccionario
//            Console.WriteLine("Diccionario:");
//            foreach (var kvp in edades)
//            {
//                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
//            }


//            // Creación de una pila
//            Stack<int> pila = new Stack<int>();

//            // Manipulación de la pila
//            pila.Push(1); // Inserción
//            pila.Push(2); // Inserción
//            pila.Push(3); // Inserción
//            int ultimoElemento = pila.Pop(); // Borrado (elimina el último elemento)

//            // Mostrar la pila
//            Console.WriteLine("Pila:");
//            foreach (int num in pila)
//            {
//                Console.WriteLine(num);
//            }

//            // Mostrar el elemento eliminado de la pila
//            Console.WriteLine($"Elemento eliminado de la pila: {ultimoElemento}");


//            // Creación de una cola
//            Queue<int> cola = new Queue<int>();

//            // Manipulación de la cola
//            cola.Enqueue(1); // Inserción
//            cola.Enqueue(2); // Inserción
//            cola.Enqueue(3); // Inserción
//            int primerElemento = cola.Dequeue(); // Borrado (elimina el primer elemento)

//            // Mostrar la cola
//            Console.WriteLine("Cola:");
//            foreach (int num in cola)
//            {
//                Console.WriteLine(num);
//            }

//            // Mostrar el elemento eliminado de la cola
//            Console.WriteLine($"Elemento eliminado de la cola: {primerElemento}");
//        }












//    }
//    }


 
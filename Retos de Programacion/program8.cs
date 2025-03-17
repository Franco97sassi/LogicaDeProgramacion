//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{
//    using System;
//    using System.Collections.Generic;

//    // Ejercicio básico: Clase Persona
//    public class Persona
//    {
//        // Atributos
//        public string Nombre { get; set; }
//        public int Edad { get; set; }

//        // Inicializador (Constructor)
//        public Persona(string nombre, int edad)
//        {
//            Nombre = nombre;
//            Edad = edad;
//        }

//        // Método para imprimir los atributos
//        public void Imprimir()
//        {
//            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
//        }
//    }

//    // Dificultad extra: Clase Pila
//    public class Pila<T>
//    {
//        private List<T> elementos = new List<T>();

//        // Añadir un elemento a la pila
//        public void Push(T elemento)
//        {
//            elementos.Add(elemento);
//        }

//        // Eliminar y retornar el elemento en la cima de la pila
//        public T Pop()
//        {
//            if (elementos.Count == 0)
//            {
//                throw new InvalidOperationException("La pila está vacía.");
//            }

//            T elemento = elementos[elementos.Count - 1];
//            elementos.RemoveAt(elementos.Count - 1);
//            return elemento;
//        }

//        // Retornar el número de elementos en la pila
//        public int Count()
//        {
//            return elementos.Count;
//        }

//        // Imprimir todos los elementos de la pila
//        public void Imprimir()
//        {
//            Console.WriteLine("Elementos en la pila:");
//            for (int i = elementos.Count - 1; i >= 0; i--)
//            {
//                Console.WriteLine(elementos[i]);
//            }
//        }
//    }

//    // Dificultad extra: Clase Cola
//    public class Cola<T>
//    {
//        private List<T> elementos = new List<T>();

//        // Añadir un elemento a la cola
//        public void Enqueue(T elemento)
//        {
//            elementos.Add(elemento);
//        }

//        // Eliminar y retornar el elemento al frente de la cola
//        public T Dequeue()
//        {
//            if (elementos.Count == 0)
//            {
//                throw new InvalidOperationException("La cola está vacía.");
//            }

//            T elemento = elementos[0];
//            elementos.RemoveAt(0);
//            return elemento;
//        }

//        // Retornar el número de elementos en la cola
//        public int Count()
//        {
//            return elementos.Count;
//        }

//        // Imprimir todos los elementos de la cola
//        public void Imprimir()
//        {
//            Console.WriteLine("Elementos en la cola:");
//            foreach (T elemento in elementos)
//            {
//                Console.WriteLine(elemento);
//            }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            // Ejercicio básico: Uso de la clase Persona
//            Console.WriteLine("=== Ejercicio básico ===");
//            Persona persona = new Persona("Juan", 30);
//            persona.Imprimir();

//            persona.Nombre = "Carlos";
//            persona.Edad = 25;
//            persona.Imprimir();

//            // Dificultad extra: Uso de la clase Pila
//            Console.WriteLine("\n=== Dificultad extra: Pila ===");
//            Pila<int> pila = new Pila<int>();
//            pila.Push(1);
//            pila.Push(2);
//            pila.Push(3);
//            pila.Imprimir();
//            Console.WriteLine($"Elemento eliminado de la pila: {pila.Pop()}");
//            pila.Imprimir();
//            Console.WriteLine($"Número de elementos en la pila: {pila.Count()}");

//            // Dificultad extra: Uso de la clase Cola
//            Console.WriteLine("\n=== Dificultad extra: Cola ===");
//            Cola<string> cola = new Cola<string>();
//            cola.Enqueue("A");
//            cola.Enqueue("B");
//            cola.Enqueue("C");
//            cola.Imprimir();
//            Console.WriteLine($"Elemento eliminado de la cola: {cola.Dequeue()}");
//            cola.Imprimir();
//            Console.WriteLine($"Número de elementos en la cola: {cola.Count()}");
//        }
//    }
//}

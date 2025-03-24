//using System;

//public class Singleton
//{
//    // Instancia única de la clase
//    private static Singleton _instance;

//    // Bloqueo para asegurar la creación de la instancia en un entorno multi-hilo
//    private static readonly object _lock = new object();

//    // Constructor privado para evitar la creación de instancias fuera de la clase
//    private Singleton() { }

//    // Propiedad para acceder a la instancia única
//    public static Singleton Instance
//    {
//        get
//        {
//            // Verifica si la instancia ya existe
//            if (_instance == null)
//            {
//                // Bloquea el acceso para evitar que se cree más de una instancia en un entorno multi-hilo
//                lock (_lock)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new Singleton();
//                    }
//                }
//            }
//            return _instance;
//        }
//    }

//    // Método de ejemplo
//    public void DoSomething()
//    {
//        Console.WriteLine("Haciendo algo...");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Acceso a la instancia única de Singleton
//        Singleton singleton = Singleton.Instance;
//        singleton.DoSomething();

//        // Intentar crear otra instancia (no será posible)
//        Singleton anotherSingleton = Singleton.Instance;
//        anotherSingleton.DoSomething();

//        // Ambas variables apuntan a la misma instancia
//        Console.WriteLine(singleton == anotherSingleton); // True
//    }
//}
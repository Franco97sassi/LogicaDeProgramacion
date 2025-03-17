//using System;

//class Program2  // ✅ Renombrado para que el programa arranque desde aquí
//{
//    // Variable global
//    static int globalVar = 100;

//    // Función sin parámetros ni retorno
//    static void Saludar()
//    {
//        Console.WriteLine("¡Hola! Esta es una función sin parámetros ni retorno.");
//    }

//    // Función con un parámetro
//    static void MostrarMensaje(string mensaje)
//    {
//        Console.WriteLine($"Mensaje recibido: {mensaje}");
//    }

//    // Función con múltiples parámetros y retorno
//    static int Sumar(int a, int b)
//    {
//        return a + b;
//    }

//    // Función que usa una variable local y la global
//    static void MostrarVariables()
//    {
//        int localVar = 50;
//        Console.WriteLine($"Variable local: {localVar}, Variable global: {globalVar}");
//    }

//    // Función local dentro de un método
//    static void FuncionPrincipal()
//    {
//        void FuncionLocal()
//        {
//            Console.WriteLine("Esto es una función local dentro de otra función en C#.");
//        }

//        FuncionLocal(); // Llamamos a la función local
//    }

//    // Función que usa una función predefinida del lenguaje
//    static void MostrarFechaActual()
//    {
//        Console.WriteLine($"La fecha y hora actual es: {DateTime.Now}");
//    }

//    // DIFICULTAD EXTRA: Función que imprime números del 1 al 100 según la regla del ejercicio
//    static int JuegoMultiplo(string texto1, string texto2)
//    {
//        int contadorNumeros = 0;

//        for (int i = 1; i <= 100; i++)
//        {
//            bool esMultiploDe3 = (i % 3 == 0);
//            bool esMultiploDe5 = (i % 5 == 0);

//            if (esMultiploDe3 && esMultiploDe5)
//            {
//                Console.WriteLine(texto1 + texto2);
//            }
//            else if (esMultiploDe3)
//            {
//                Console.WriteLine(texto1);
//            }
//            else if (esMultiploDe5)
//            {
//                Console.WriteLine(texto2);
//            }
//            else
//            {
//                Console.WriteLine(i);
//                contadorNumeros++; // Contamos cuántas veces se imprime un número
//            }
//        }

//        return contadorNumeros;
//    }

//    static void Main()
//    {
//        // Llamadas a funciones
//        Saludar();
//        MostrarMensaje("¡Este es un mensaje de prueba!");
//        Console.WriteLine($"La suma de 5 y 7 es: {Sumar(5, 7)}");
//        MostrarVariables();
//        FuncionPrincipal();
//        MostrarFechaActual();

//        // Ejecutando el reto extra
//        int vecesNumerosMostrados = JuegoMultiplo("Fizz", "Buzz");
//        Console.WriteLine($"Cantidad de veces que se imprimió un número: {vecesNumerosMostrados}");
//    }
//}

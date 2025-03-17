//using System;
//namespace Retos_de_Programacion
//{
//    class Program6
//{
//    static void Main()
//    {
//        // Ejercicio: Imprimir números del 100 al 0
//        Console.WriteLine("Números del 100 al 0:");
//        ImprimirNumeros(100);

//        // Dificultad Extra: Factorial
//        int numero = 5;
//        Console.WriteLine($"\nFactorial de {numero}: {Factorial(numero)}");

//        // Dificultad Extra: Fibonacci
//        int posicion = 6;
//        Console.WriteLine($"Fibonacci en posición {posicion}: {Fibonacci(posicion)}");
//    }

//    // Función recursiva para imprimir números del 100 al 0
//    static void ImprimirNumeros(int numero)
//    {
//        if (numero < 0)
//            return;

//        Console.WriteLine(numero);
//        ImprimirNumeros(numero - 1);
//    }

//    // Función recursiva para calcular el factorial
//    static int Factorial(int n)
//    {
//        if (n <= 1)
//            return 1;

//        return n * Factorial(n - 1);
//    }

//    // Función recursiva para calcular Fibonacci
//    static int Fibonacci(int n)
//    {
//        if (n == 0)
//            return 0;
//        if (n == 1)
//            return 1;

//        return Fibonacci(n - 1) + Fibonacci(n - 2);
//    }
//}
//}
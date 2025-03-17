//using System;
//namespace Retos_de_Programacion
//{  
//class Program5
//{
//    static void Main()
//    {
//        // 1. Asignación por valor y por referencia
//        Console.WriteLine("=== Asignación por valor y por referencia ===");

//        // Asignación por valor
//        int a = 10;
//        int b = a; // Asignación por valor
//        b = 20;    // Modificamos b
//        Console.WriteLine($"Asignación por valor: a = {a}, b = {b}"); // a: 10, b: 20

//        // Asignación por referencia
//        int[] arr1 = { 1, 2, 3 };
//        int[] arr2 = arr1; // Asignación por referencia
//        arr2[0] = 99;      // Modificamos arr2
//        Console.WriteLine($"Asignación por referencia: arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}"); // arr1[0]: 99, arr2[0]: 99

//        // 2. Funciones con parámetros por valor y por referencia
//        Console.WriteLine("\n=== Funciones con parámetros por valor y por referencia ===");

//        // Paso por valor
//        int numero = 10;
//        Console.WriteLine($"Antes de ModificarPorValor: numero = {numero}");
//        ModificarPorValor(numero);
//        Console.WriteLine($"Después de ModificarPorValor: numero = {numero}"); // numero sigue siendo 10

//        // Paso por referencia
//        int otroNumero = 10;
//        Console.WriteLine($"Antes de ModificarPorReferencia: otroNumero = {otroNumero}");
//        ModificarPorReferencia(ref otroNumero);
//        Console.WriteLine($"Después de ModificarPorReferencia: otroNumero = {otroNumero}"); // otroNumero cambia a 100



//        // 3. Dificultad Extra: Intercambio de valores
//        Console.WriteLine("\n=== Dificultad Extra: Intercambio de valores ===");

//        // Intercambio por valor
//        int x = 10;
//        int y = 20;
//        Console.WriteLine($"Originales (por valor): x = {x}, y = {y}");
//        var (nuevoX, nuevoY) = IntercambiarPorValor(x, y);
//        Console.WriteLine($"Intercambiados (por valor): nuevoX = {nuevoX}, nuevoY = {nuevoY}");
//        Console.WriteLine($"Originales después del intercambio (por valor): x = {x}, y = {y}");

//        // Intercambio por referencia
//        int m = 10;
//        int n = 20;
//        Console.WriteLine($"Originales (por referencia): m = {m}, n = {n}");
//        IntercambiarPorReferencia(ref m, ref n);
//        Console.WriteLine($"Intercambiados (por referencia): m = {m}, n = {n}");
//    }

//    // Función con parámetro por valor
//    static void ModificarPorValor(int x)
//    {
//        x = 100;
//        Console.WriteLine($"Dentro de ModificarPorValor: x = {x}");
//    }

//    // Función con parámetro por referencia
//    static void ModificarPorReferencia(ref int x)
//    {
//        x = 100;
//        Console.WriteLine($"Dentro de ModificarPorReferencia: x = {x}");
//    }

//    // Función para intercambiar valores por valor
//    static (int, int) IntercambiarPorValor(int a, int b)
//    {
//        int temp = a;
//        a = b;
//        b = temp;
//        return (a, b);
//    }

//    // Función para intercambiar valores por referencia
//    static void IntercambiarPorReferencia(ref int a, ref int b)
//    {
//        int temp = a;
//        a = b;
//        b = temp;
//    }
//}
//}
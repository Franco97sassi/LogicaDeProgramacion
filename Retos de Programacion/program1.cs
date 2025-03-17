//using System;

//class Program1
//{
//    public static void Main()
//    {
//        Console.WriteLine("🚀 Ejecutando program2.cs");

//        // ✅ Operadores Aritméticos
//        int a = 10, b = 5;
//        Console.WriteLine($"Suma: {a + b}, Resta: {a - b}, Multiplicación: {a * b}, División: {a / b}, Módulo: {a % b}");

//        // ✅ Operadores de Comparación
//        Console.WriteLine($"¿10 es mayor que 5? {a > b}");
//        Console.WriteLine($"¿10 es igual a 5? {a == b}");

//        // ✅ Operadores Lógicos
//        bool esMayor = a > b;
//        bool esPar = (a % 2 == 0);
//        Console.WriteLine($"¿10 es mayor que 5 y par? {esMayor && esPar}");

//        // ✅ Operadores de Asignación
//        int x = 20;
//        x += 10;  // Equivalente a x = x + 10
//        Console.WriteLine($"Valor de x después de += 10: {x}");

//        // ✅ Operadores de Bits
//        int bitwiseAnd = a & b;  // AND bit a bit
//        int bitwiseOr = a | b;   // OR bit a bit
//        Console.WriteLine($"AND bit a bit: {bitwiseAnd}, OR bit a bit: {bitwiseOr}");

//        // ✅ Estructuras de Control: Condicionales
//        if (a > b)
//        {
//            Console.WriteLine("A es mayor que B.");
//        }
//        else
//        {
//            Console.WriteLine("A no es mayor que B.");
//        }

//        // ✅ Estructuras de Control: Switch
//        int opcion = 2;
//        switch (opcion)
//        {
//            case 1:
//                Console.WriteLine("Elegiste la opción 1.");
//                break;
//            case 2:
//                Console.WriteLine("Elegiste la opción 2.");
//                break;
//            default:
//                Console.WriteLine("Opción no válida.");
//                break;
//        }

//        // ✅ Estructuras Iterativas: Bucle For
//        Console.WriteLine("Números del 1 al 5:");
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.Write(i + " ");
//        }
//        Console.WriteLine();

//        // ✅ Excepciones (Try-Catch)
//        try
//        {
//            int resultado = a / 0; // Esto generará un error
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Error: División por cero.");
//        }

//        // ✅ Desafío Extra: Imprimir números entre 10 y 55, pares, sin incluir 16 ni múltiplos de 3
//        Console.WriteLine("📌 Números entre 10 y 55 (pares, sin 16 ni múltiplos de 3):");
//        for (int i = 10; i <= 55; i++)
//        {
//            if (i % 2 == 0 && i != 16 && i % 3 != 0)
//            {
//                Console.Write(i + " ");
//            }
//        }
//        Console.WriteLine();
//    }
//}

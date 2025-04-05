//using System;

//class DistribucionAnillos
//{
//    // Función para verificar si un número es primo
//    static bool EsPrimo(int num)
//    {
//        if (num <= 1) return false;
//        if (num == 2) return true;
//        if (num % 2 == 0) return false;

//        for (int i = 3; i * i <= num; i += 2)
//        {
//            if (num % i == 0)
//                return false;
//        }
//        return true;
//    }

//    // Función principal para distribuir los anillos
//    static (int sauron, int elfos, int enanos, int hombres, string mensaje) DistribuirAnillos(int totalAnillos)
//    {
//        // Verificar que hay al menos 1 anillo para Sauron
//        if (totalAnillos < 1)
//        {
//            return (0, 0, 0, 0, "Error: Debe haber al menos 1 anillo para Sauron");
//        }

//        int anillosRestantes = totalAnillos - 1; // Reservamos 1 para Sauron

//        // Buscamos todas las combinaciones posibles
//        for (int e = 1; e <= anillosRestantes; e += 2) // Elfos reciben impar
//        {
//            for (int d = 2; d <= anillosRestantes - e; d++) // Enanos reciben primo
//            {
//                if (EsPrimo(d))
//                {
//                    int h = anillosRestantes - e - d; // Hombres reciben par
//                    if (h >= 0 && h % 2 == 0)
//                    {
//                        return (1, e, d, h, "Distribución exitosa");
//                    }
//                }
//            }
//        }

//        // Si no encontramos combinación válida
//        return (1, 0, 0, 0, "Error: No se encontró una combinación válida");
//    }

//    static void Main()
//    {
//        // Ejemplos de uso
//        var distribucion1 = DistribuirAnillos(10);
//        Console.WriteLine($"10 anillos: Sauron={distribucion1.sauron}, Elfos={distribucion1.elfos}, Enanos={distribucion1.enanos}, Hombres={distribucion1.hombres}, Mensaje={distribucion1.mensaje}");

//        var distribucion2 = DistribuirAnillos(7);
//        Console.WriteLine($"7 anillos: Sauron={distribucion2.sauron}, Elfos={distribucion2.elfos}, Enanos={distribucion2.enanos}, Hombres={distribucion2.hombres}, Mensaje={distribucion2.mensaje}");

//        var distribucion3 = DistribuirAnillos(1);
//        Console.WriteLine($"1 anillo: Sauron={distribucion3.sauron}, Elfos={distribucion3.elfos}, Enanos={distribucion3.enanos}, Hombres={distribucion3.hombres}, Mensaje={distribucion3.mensaje}");

//        var distribucion4 = DistribuirAnillos(0);
//        Console.WriteLine($"0 anillos: Sauron={distribucion4.sauron}, Elfos={distribucion4.elfos}, Enanos={distribucion4.enanos}, Hombres={distribucion4.hombres}, Mensaje={distribucion4.mensaje}");
//    }
//}
//using System;

//namespace Retos_de_Programacion
//{
//    class Program10
//    {
//        static void Main()
//        {
//            // Ejercicio básico
//            Console.WriteLine("=== Ejercicio Básico ===");
//            ManejoExcepcionesBasico();

//            // Dificultad extra
//            Console.WriteLine("\n=== Dificultad Extra ===");
//            ManejoExcepcionesAvanzado();
//        }

//        static void ManejoExcepcionesBasico()
//        {
//            try
//            {
//                // Forzar un error de división por cero usando variables
//                int numerador = 10;
//                int denominador = 0;
//                int resultado = numerador / denominador; // Esto lanzará una excepción en tiempo de ejecución
//            }
//            catch (DivideByZeroException ex)
//            {
//                // Capturar y imprimir el error
//                Console.WriteLine("Error de división por cero: " + ex.Message);
//            }

//            try
//            {
//                // Forzar un error de índice fuera de rango
//                int[] array = { 1, 2, 3 };
//                int valor = array[10]; // Esto lanzará una excepción de índice fuera de rango
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                // Capturar y imprimir el error
//                Console.WriteLine("Error de índice fuera de rango: " + ex.Message);
//            }

//            Console.WriteLine("El programa continúa ejecutándose después del manejo de excepciones básicas.");
//        }

//        static void ManejoExcepcionesAvanzado()
//        {
//            try
//            {
//                // Probar diferentes casos
//                ProcesarParametros(0);  // Lanzará una excepción personalizada
//                ProcesarParametros(10); // Lanzará una excepción de división por cero
//                ProcesarParametros(1);  // Lanzará una excepción de índice fuera de rango
//            }
//            catch (MiExcepcionPersonalizada ex)
//            {
//                Console.WriteLine("Excepción personalizada: " + ex.Message);
//            }
//            catch (DivideByZeroException ex)
//            {
//                Console.WriteLine("Error de división por cero: " + ex.Message);
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                Console.WriteLine("Error de índice fuera de rango: " + ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error inesperado: " + ex.Message);
//            }
//            finally
//            {
//                Console.WriteLine("La ejecución ha finalizado.");
//            }
//        }

//        static void ProcesarParametros(int parametro)
//        {
//            if (parametro == 0)
//            {
//                throw new MiExcepcionPersonalizada("El parámetro no puede ser cero.");
//            }
//            else if (parametro == 10)
//            {
//                // Usar variables para evitar el error de compilación
//                int numerador = 10;
//                int denominador = parametro;
//                int resultado = numerador / denominador; // Esto lanzará una excepción de división por cero
//            }
//            else if (parametro == 1)
//            {
//                int[] array = { 1, 2, 3 };
//                int valor = array[10]; // Esto lanzará una excepción de índice fuera de rango
//            }
//            else
//            {
//                Console.WriteLine("Parámetro procesado correctamente: " + parametro);
//            }
//        }
//    }

//    // Excepción personalizada
//    class MiExcepcionPersonalizada : Exception
//    {
//        public MiExcepcionPersonalizada(string mensaje) : base(mensaje) { }
//    }
//}
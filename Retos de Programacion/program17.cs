 

namespace Retos_de_Programacion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class Program17
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Bucle for:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n2. Bucle while:");
            int j = 1;
            while (j <= 10)
            {
                Console.WriteLine(j);
                j++;
            }

            Console.WriteLine("\n3. Bucle foreach con array:");
            int[] numerosArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int numero in numerosArray)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n4. Bucle do-while:");
            int k = 1;
            do
            {
                Console.WriteLine(k);
                k++;
            } while (k <= 10);

            Console.WriteLine("\n5. Recursión:");
            ImprimirNumeros(1);

            Console.WriteLine("\n6. LINQ con Enumerable.Range:");
            Enumerable.Range(1, 10).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\n7. Bucle for con List<T>:");
            List<int> numerosList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < numerosList.Count; i++)
            {
                Console.WriteLine(numerosList[i]);
            }

            Console.WriteLine("\n8. Bucle foreach con List<T>:");
            foreach (int numero in numerosList)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n9. Bucle for con Array:");
            for (int i = 0; i < numerosArray.Length; i++)
            {
                Console.WriteLine(numerosArray[i]);
            }

            Console.WriteLine("\n10. Bucle foreach con IEnumerable:");
            IEnumerable<int> numerosEnumerable = Enumerable.Range(1, 10);
            foreach (int numero in numerosEnumerable)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n11. Bucle Parallel.For (Iteración paralela):");
            Parallel.For(1, 11, i =>
            {
                Console.WriteLine(i);
            });

            Console.WriteLine("\n12. Bucle for con yield (Generadores):");
            foreach (int numero in GenerarNumeros(1, 10))
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n13. Bucle for con Span<T>:");
            Span<int> numerosSpan = stackalloc int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < numerosSpan.Length; i++)
            {
                Console.WriteLine(numerosSpan[i]);
            }

            Console.WriteLine("\n14. Bucle foreach con Dictionary<TKey, TValue>:");
            Dictionary<int, int> numerosDiccionario = new Dictionary<int, int>
        {
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 },
            { 6, 6 }, { 7, 7 }, { 8, 8 }, { 9, 9 }, { 10, 10 }
        };
            foreach (var kvp in numerosDiccionario)
            {
                Console.WriteLine(kvp.Value);
            }

            Console.WriteLine("\n15. Bucle for con ArraySegment<T>:");
            ArraySegment<int> segmento = new ArraySegment<int>(numerosArray, 0, 10);
            for (int i = 0; i < segmento.Count; i++)
            {
                Console.WriteLine(segmento[i]);
            }
        }

        static void ImprimirNumeros(int n)
        {
            if (n <= 10)
            {
                Console.WriteLine(n);
                ImprimirNumeros(n + 1);
            }
        }

        static IEnumerable<int> GenerarNumeros(int inicio, int fin)
        {
            for (int i = inicio; i <= fin; i++)
            {
                yield return i;
            }
        }
    }
}

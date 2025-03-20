//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{
//    using System;
//    using System.Collections.Generic;

//    class program18
//    {
//        static void Main()
//        {
//            // Crear una lista de enteros
//            List<int> numeros = new List<int> { 1, 2, 3 };

//            // Añadir un elemento al final
//            numeros.Add(4);
//            Console.WriteLine("Después de Add(4): " + string.Join(", ", numeros));

//            // Añadir un elemento al principio
//            numeros.Insert(0, 0);
//            Console.WriteLine("Después de Insert(0, 0): " + string.Join(", ", numeros));

//            // Añadir varios elementos en bloque al final
//            numeros.AddRange(new int[] { 5, 6, 7 });
//            Console.WriteLine("Después de AddRange([5, 6, 7]): " + string.Join(", ", numeros));

//            // Añadir varios elementos en bloque en una posición concreta
//            numeros.InsertRange(2, new int[] { 8, 9 });
//            Console.WriteLine("Después de InsertRange(2, [8, 9]): " + string.Join(", ", numeros));

//            // Eliminar un elemento en una posición concreta
//            numeros.RemoveAt(3);
//            Console.WriteLine("Después de RemoveAt(3): " + string.Join(", ", numeros));

//            // Actualizar el valor de un elemento en una posición concreta
//            numeros[2] = 10;
//            Console.WriteLine("Después de actualizar numeros[2] a 10: " + string.Join(", ", numeros));

//            // Comprobar si un elemento está en el conjunto
//            bool contiene = numeros.Contains(5);
//            Console.WriteLine("¿Contiene el número 5? " + contiene);

//            // Eliminar todo el contenido del conjunto
//            numeros.Clear();
//            Console.WriteLine("Después de Clear: " + string.Join(", ", numeros));

//            // DIFICULTAD EXTRA: Operaciones con conjuntos
//            HashSet<int> conjuntoA = new HashSet<int> { 1, 2, 3, 4 };
//            HashSet<int> conjuntoB = new HashSet<int> { 3, 4, 5, 6 };

//            // Unión
//            conjuntoA.UnionWith(conjuntoB);
//            Console.WriteLine("Unión de A y B: " + string.Join(", ", conjuntoA));

//            // Intersección
//            conjuntoA.IntersectWith(conjuntoB);
//            Console.WriteLine("Intersección de A y B: " + string.Join(", ", conjuntoA));

//            // Diferencia
//            conjuntoA.ExceptWith(conjuntoB);
//            Console.WriteLine("Diferencia de A y B: " + string.Join(", ", conjuntoA));

//            // Diferencia simétrica
//            conjuntoA.SymmetricExceptWith(conjuntoB);
//            Console.WriteLine("Diferencia simétrica de A y B: " + string.Join(", ", conjuntoA));
//        }
//    }
//}

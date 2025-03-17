//using System;
//using System.Linq;


//namespace Retos_de_Programacion
//{
//    class Program4
//    {
//        static void Main()
//        {
//            // Ejemplos de operaciones con cadenas de caracteres
//            string texto = "Hola, Mundo!";

//            // 1. Acceso a caracteres específicos
//            char primerCaracter = texto[0]; // 'H'
//            char ultimoCaracter = texto[texto.Length - 1]; // '!'
//            Console.WriteLine($"Primer carácter: {primerCaracter}");
//            Console.WriteLine($"Último carácter: {ultimoCaracter}");

//            // 2. Subcadenas
//            string subcadena = texto.Substring(0, 4); // "Hola"
//            Console.WriteLine($"Subcadena: {subcadena}");

//            // 3. Longitud de la cadena
//            int longitud = texto.Length; // 12
//            Console.WriteLine($"Longitud de la cadena: {longitud}");

//            // 4. Concatenación
//            string cadena1 = "Hola";
//            string cadena2 = "Mundo";
//            string resultado = cadena1 + ", " + cadena2 + "!"; // "Hola, Mundo!"
//            Console.WriteLine($"Concatenación: {resultado}");

//            // 5. Repetición
//            string repetido = new string('a', 5); // "aaaaa"
//            Console.WriteLine($"Repetición: {repetido}");

//            // 6. Recorrido de la cadena
//            Console.WriteLine("Recorrido de la cadena:");
//            foreach (char c in texto)
//            {
//                Console.WriteLine(c);
//            }

//            // 7. Conversión a mayúsculas y minúsculas
//            string mayusculas = texto.ToUpper(); // "HOLA, MUNDO!"
//            string minusculas = texto.ToLower(); // "hola, mundo!"
//            Console.WriteLine($"Mayúsculas: {mayusculas}");
//            Console.WriteLine($"Minúsculas: {minusculas}");

//            // 8. Reemplazo
//            string reemplazado = texto.Replace("Mundo", "C#"); // "Hola, C#!"
//            Console.WriteLine($"Reemplazo: {reemplazado}");

//            // 9. División
//            string[] partes = texto.Split(','); // ["Hola", " Mundo!"]
//            Console.WriteLine("División:");
//            foreach (string parte in partes)
//            {
//                Console.WriteLine(parte.Trim());
//            }

//            // 10. Unión
//            string[] palabras = { "Hola", "Mundo" };
//            string unido = string.Join(" ", palabras); // "Hola Mundo"
//            Console.WriteLine($"Unión: {unido}");

//            // 11. Interpolación
//            string nombre = "C#";
//            string interpolado = $"Hola, {nombre}!"; // "Hola, C#!"
//            Console.WriteLine($"Interpolación: {interpolado}");

//            // 12. Verificación
//            bool contiene = texto.Contains("Mundo"); // true
//            bool empiezaCon = texto.StartsWith("Hola"); // true
//            bool terminaCon = texto.EndsWith("!"); // true
//            Console.WriteLine($"Contiene 'Mundo': {contiene}");
//            Console.WriteLine($"Empieza con 'Hola': {empiezaCon}");
//            Console.WriteLine($"Termina con '!': {terminaCon}");











//            // DIFICULTAD EXTRA: Programa para analizar dos palabras
//            string palabra1 = "anilina";
//            string palabra2 = "lainani";

//            Console.WriteLine("\nAnálisis de palabras:");
//            Console.WriteLine($"Palabra 1: {palabra1}");
//            Console.WriteLine($"Palabra 2: {palabra2}");

//            if (EsPalindromo(palabra1))
//                Console.WriteLine($"{palabra1} es un palíndromo.");

//            if (EsPalindromo(palabra2))
//                Console.WriteLine($"{palabra2} es un palíndromo.");

//            if (EsAnagrama(palabra1, palabra2))
//                Console.WriteLine($"{palabra1} y {palabra2} son anagramas.");

//            if (EsIsograma(palabra1))
//                Console.WriteLine($"{palabra1} es un isograma.");

//            if (EsIsograma(palabra2))
//                Console.WriteLine($"{palabra2} es un isograma.");
//        }

//        static bool EsPalindromo(string palabra)
//        {
//            string reverso= new string(palabra.Reverse().ToArray()); 
//            return palabra.Equals(reverso,StringComparison.OrdinalIgnoreCase)

//        }
//        static bool EsAnagrama(string palabra1, string palabra2)
//        {
//            var arr1=palabra1.ToLower().ToCharArray();
//            var arr2 = palabra2.ToLower().ToCharArray();
//            Array.Sort(arr1);
//            Array.Sort(arr2);
//            return new string(arr1) == new string(arr2);


//        }

//        static bool EsIsograma(string palabra)
//        {
//return palabra.ToLower().Distinct().Count()==palabra.Length
//        }

//    }
//}
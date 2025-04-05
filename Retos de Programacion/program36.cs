using System;

namespace SombreroSeleccionador
{
    class Program
    {
        // Definición de las casas y sus puntuaciones
        static int frontend = 0;
        static int backend = 0;
        static int mobile = 0;
        static int data = 0;

        // Preguntas y respuestas
        static (string pregunta, (string respuesta, string casa, int puntos)[] respuestas)[] preguntas = new[]
        {
            (
                "1. ¿Qué tipo de proyectos prefieres?",
                new[]
                {
                    ("Interfaces de usuario bonitas", "Frontend", 2),
                    ("Lógica y sistemas complejos", "Backend", 2),
                    ("Aplicaciones para móviles", "Mobile", 2),
                    ("Análisis de datos y estadísticas", "Data", 2)
                }
            ),
            (
                "2. Tu lenguaje favorito es...",
                new[]
                {
                    ("JavaScript/TypeScript", "Frontend", 1),
                    ("Python/Java/C#", "Backend", 1),
                    ("Dart (Flutter) o Swift/Kotlin", "Mobile", 1),
                    ("R o Python (para datos)", "Data", 1)
                }
            ),
            (
                "3. En tu tiempo libre prefieres...",
                new[]
                {
                    ("Diseñar páginas web", "Frontend", 1),
                    ("Resolver problemas lógicos", "Backend", 1),
                    ("Probar nuevas apps en tu móvil", "Mobile", 1),
                    ("Analizar tendencias y patrones", "Data", 1)
                }
            ),
            (
                "4. Tu asignatura favorita sería...",
                new[]
                {
                    ("Diseño de interfaces", "Frontend", 1),
                    ("Arquitectura de sistemas", "Backend", 1),
                    ("Desarrollo de aplicaciones", "Mobile", 1),
                    ("Minería de datos", "Data", 1)
                }
            ),
            (
                "5. ¿Cómo te describes?",
                new[]
                {
                    ("Creativo y detallista", "Frontend", 1),
                    ("Analítico y estructurado", "Backend", 1),
                    ("Innovador y práctico", "Mobile", 1),
                    ("Curioso y metódico", "Data", 1)
                }
            ),
            (
                "6. Tu herramienta favorita es...",
                new[]
                {
                    ("Figma o Adobe XD", "Frontend", 1),
                    ("Postman o Docker", "Backend", 1),
                    ("Android Studio o Xcode", "Mobile", 1),
                    ("Jupyter Notebook o Tableau", "Data", 1)
                }
            ),
            (
                "7. En un equipo de trabajo prefieres...",
                new[]
                {
                    ("Diseñar la experiencia de usuario", "Frontend", 1),
                    ("Construir la arquitectura del sistema", "Backend", 1),
                    ("Desarrollar funcionalidades clave", "Mobile", 1),
                    ("Extraer insights de los datos", "Data", 1)
                }
            ),
            (
                "8. ¿Qué te emociona más?",
                new[]
                {
                    ("Ver una interfaz bonita funcionando", "Frontend", 1),
                    ("Resolver un problema complejo", "Backend", 1),
                    ("Probar tu app en un dispositivo real", "Mobile", 1),
                    ("Descubrir un patrón interesante", "Data", 1)
                }
            ),
            (
                "9. Tu enfoque ante un problema es...",
                new[]
                {
                    ("Cómo se verá y sentirá la solución", "Frontend", 1),
                    ("Cómo funcionará internamente", "Backend", 1),
                    ("Cómo interactuarán los usuarios", "Mobile", 1),
                    ("Qué datos pueden ayudar a resolverlo", "Data", 1)
                }
            ),
            (
                "10. ¿Qué te gustaría aprender más?",
                new[]
                {
                    ("Animaciones y efectos visuales", "Frontend", 1),
                    ("Microservicios y APIs", "Backend", 1),
                    ("Nuevas tecnologías móviles", "Mobile", 1),
                    ("Machine Learning", "Data", 1)
                }
            )
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== Sombrero Seleccionador de Hogwarts para Programadores ===");
            Console.Write("\n¡Bienvenido al Expreso de Hogwarts para Programadores!\n¿Cuál es tu nombre? ");
            string nombre = Console.ReadLine();

            RealizarPreguntas(nombre);
            DeterminarCasa(nombre);
        }

        static void RealizarPreguntas(string nombre)
        {
            foreach (var pregunta in preguntas)
            {
                Console.WriteLine($"\n{pregunta.pregunta}");
                for (int i = 0; i < pregunta.respuestas.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {pregunta.respuestas[i].respuesta}");
                }

                int respuesta;
                while (true)
                {
                    Console.Write("Elige una opción (1-4): ");
                    if (int.TryParse(Console.ReadLine(), out respuesta) && respuesta >= 1 && respuesta <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Por favor, ingresa un número válido entre 1 y 4");
                }

                var respuestaSeleccionada = pregunta.respuestas[respuesta - 1];
                AsignarPuntos(respuestaSeleccionada.casa, respuestaSeleccionada.puntos);
            }
        }

        static void AsignarPuntos(string casa, int puntos)
        {
            switch (casa)
            {
                case "Frontend":
                    frontend += puntos;
                    break;
                case "Backend":
                    backend += puntos;
                    break;
                case "Mobile":
                    mobile += puntos;
                    break;
                case "Data":
                    data += puntos;
                    break;
            }
        }

        static void DeterminarCasa(string nombre)
        {
            var casas = new[]
            {
                ("Frontend", frontend),
                ("Backend", backend),
                ("Mobile", mobile),
                ("Data", data)
            };

            // Ordenar por puntuación descendente
            Array.Sort(casas, (a, b) => b.Item2.CompareTo(a.Item2));

            bool empate = casas[0].Item2 == casas[1].Item2;
            string casaGanadora = casas[0].Item1;

            Console.WriteLine("\n====================================");
            Console.WriteLine($"¡{nombre}, el Sombrero Seleccionador ha decidido!");

            if (empate)
            {
                // Resolver empate aleatoriamente
                Random rnd = new Random();
                casaGanadora = rnd.Next(2) == 0 ? casas[0].Item1 : casas[1].Item1;
                Console.WriteLine("\n¡La decisión ha sido complicada!");
                Console.WriteLine($"Hubo un empate entre {casas[0].Item1} y {casas[1].Item1}.");
            }

            Console.WriteLine($"\nPerteneces a la casa: {casaGanadora.ToUpper()}!\n");
            Console.WriteLine("Puntuación final:");

            foreach (var casa in casas)
            {
                Console.WriteLine($"{casa.Item1}: {casa.Item2} puntos");
            }
            Console.WriteLine("====================================");
        }
    }
}
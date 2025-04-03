//using System;

//namespace DisneyLaberinto
//{
//    class Program
//    {
//        static string[][] laberinto;
//        static int mickeyFila;
//        static int mickeyCol;

//        static void Main(string[] args)
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;
//            InicializarLaberinto();
//            Console.WriteLine("¡Ayuda a Mickey a escapar del laberinto!");
//            Console.WriteLine("Usa las teclas: ↑ (arriba), ↓ (abajo), ← (izquierda), → (derecha)");
//            Console.WriteLine("Presiona ESC para salir del juego");

//            MostrarLaberinto();

//            while (true)
//            {
//                var tecla = Console.ReadKey(true).Key;

//                if (tecla == ConsoleKey.Escape)
//                    break;

//                string direccion = "";
//                switch (tecla)
//                {
//                    case ConsoleKey.UpArrow:
//                        direccion = "arriba";
//                        break;
//                    case ConsoleKey.DownArrow:
//                        direccion = "abajo";
//                        break;
//                    case ConsoleKey.LeftArrow:
//                        direccion = "izquierda";
//                        break;
//                    case ConsoleKey.RightArrow:
//                        direccion = "derecha";
//                        break;
//                    default:
//                        continue;
//                }

//                MoverMickey(direccion);
//                MostrarLaberinto();
//            }
//        }

//        static void InicializarLaberinto()
//        {
//            // Versión con emojis (funciona en consolas modernas)
//            laberinto = new string[6][];
//            laberinto[0] = new string[] { "·", "·", "█", "·", "·", "·" };
//            laberinto[1] = new string[] { "·", "█", "█", "·", "█", "·" };
//            laberinto[2] = new string[] { "·", "·", "M", "·", "█", "·" };
//            laberinto[3] = new string[] { "█", "·", "█", "█", "·", "·" };
//            laberinto[4] = new string[] { "·", "·", "·", "·", "█", "█" };
//            laberinto[5] = new string[] { "·", "█", "·", "·", "·", "S" };

//            mickeyFila = 2;
//            mickeyCol = 2;
//        }

//        static void MostrarLaberinto()
//        {
//            Console.Clear();
//            Console.WriteLine("\nLaberinto de Mickey:\n");

//            for (int fila = 0; fila < 6; fila++)
//            {
//                for (int col = 0; col < 6; col++)
//                {
//                    // Convertir símbolos a colores
//                    switch (laberinto[fila][col])
//                    {
//                        case "M":
//                            Console.ForegroundColor = ConsoleColor.Yellow;
//                            Console.Write("M ");
//                            Console.ResetColor();
//                            break;
//                        case "S":
//                            Console.ForegroundColor = ConsoleColor.Green;
//                            Console.Write("S ");
//                            Console.ResetColor();
//                            break;
//                        case "█":
//                            Console.ForegroundColor = ConsoleColor.Red;
//                            Console.Write("█ ");
//                            Console.ResetColor();
//                            break;
//                        default:
//                            Console.Write(laberinto[fila][col] + " ");
//                            break;
//                    }
//                }
//                Console.WriteLine();
//            }
//            Console.WriteLine();
//        }

//        static void MoverMickey(string direccion)
//        {
//            int nuevaFila = mickeyFila;
//            int nuevaCol = mickeyCol;

//            switch (direccion)
//            {
//                case "arriba":
//                    nuevaFila--;
//                    break;
//                case "abajo":
//                    nuevaFila++;
//                    break;
//                case "izquierda":
//                    nuevaCol--;
//                    break;
//                case "derecha":
//                    nuevaCol++;
//                    break;
//            }

//            // Validar límites del laberinto
//            if (nuevaFila < 0 || nuevaFila >= 6 || nuevaCol < 0 || nuevaCol >= 6)
//            {
//                Console.WriteLine("¡No puedes salir del laberinto!");
//                Console.ReadKey(true);
//                return;
//            }

//            // Validar obstáculos
//            if (laberinto[nuevaFila][nuevaCol] == "█")
//            {
//                Console.WriteLine("¡Hay un obstáculo! No puedes pasar.");
//                Console.ReadKey(true);
//                return;
//            }

//            // Verificar si llegó a la salida
//            if (laberinto[nuevaFila][nuevaCol] == "S")
//            {
//                laberinto[mickeyFila][mickeyCol] = "·";
//                MostrarLaberinto();
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("¡Felicidades! Mickey ha escapado del laberinto. 🎉");
//                Console.ResetColor();
//                Console.WriteLine("Presiona cualquier tecla para salir...");
//                Console.ReadKey();
//                Environment.Exit(0);
//            }

//            // Mover a Mickey
//            laberinto[mickeyFila][mickeyCol] = "·";
//            laberinto[nuevaFila][nuevaCol] = "M";
//            mickeyFila = nuevaFila;
//            mickeyCol = nuevaCol;
//        }
//    }
//}
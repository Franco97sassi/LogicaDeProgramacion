//using System;
//using System.Threading;

//class Personaje
//{
//    public string Nombre { get; set; }
//    public int Vida { get; set; }
//    public int MinDano { get; set; }
//    public int MaxDano { get; set; }
//    public double ProbabilidadEvasion { get; set; }
//    public bool Regenerandose { get; set; }
//    private Random random;

//    public Personaje(string nombre, int vida, int minDano, int maxDano, double probabilidadEvasion)
//    {
//        Nombre = nombre;
//        Vida = vida;
//        MinDano = minDano;
//        MaxDano = maxDano;
//        ProbabilidadEvasion = probabilidadEvasion;
//        Regenerandose = false;
//        random = new Random();
//    }

//    public (int dano, bool esMaximo) Atacar()
//    {
//        if (Regenerandose)
//        {
//            Regenerandose = false;
//            return (0, false);
//        }

//        int dano = random.Next(MinDano, MaxDano + 1);
//        bool esMaximo = dano == MaxDano;
//        return (dano, esMaximo);
//    }

//    public bool Esquivar()
//    {
//        return random.NextDouble() < ProbabilidadEvasion;
//    }

//    public (int danoRecibido, bool fueEsquivado) RecibirDano(int dano, bool esMaximo)
//    {
//        if (Esquivar())
//        {
//            return (0, true);
//        }

//        Vida -= dano;
//        if (esMaximo)
//        {
//            Regenerandose = true;
//        }
//        return (dano, false);
//    }

//    public bool EstaDerrotado()
//    {
//        return Vida <= 0;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("¡Deadpool vs Wolverine - Batalla Épica!");

//        // Solicitar vida inicial para cada personaje
//        Console.Write("Ingrese la vida inicial para Deadpool: ");
//        int vidaDeadpool = int.Parse(Console.ReadLine());

//        Console.Write("Ingrese la vida inicial para Wolverine: ");
//        int vidaWolverine = int.Parse(Console.ReadLine());

//        // Validar entrada
//        if (vidaDeadpool <= 0 || vidaWolverine <= 0)
//        {
//            Console.WriteLine("La vida inicial debe ser mayor que cero.");
//            return;
//        }

//        // Crear personajes
//        Personaje deadpool = new Personaje("Deadpool", vidaDeadpool, 10, 100, 0.25);
//        Personaje wolverine = new Personaje("Wolverine", vidaWolverine, 10, 120, 0.20);

//        int turno = 1;
//        Personaje ganador = null;

//        Console.WriteLine("\n¡Comienza la batalla!");

//        while (ganador == null)
//        {
//            Thread.Sleep(1000); // Pausa de 1 segundo entre turnos
//            Console.WriteLine($"\n=== Turno {turno} ===");

//            // Deadpool ataca primero
//            var ataqueDeadpool = deadpool.Atacar();
//            if (ataqueDeadpool.dano > 0)
//            {
//                var resultado = wolverine.RecibirDano(ataqueDeadpool.dano, ataqueDeadpool.esMaximo);

//                if (resultado.fueEsquivado)
//                {
//                    Console.WriteLine($"{wolverine.Nombre} esquivó el ataque de {deadpool.Nombre}!");
//                }
//                else
//                {
//                    Console.WriteLine($"{deadpool.Nombre} ataca a {wolverine.Nombre} por {ataqueDeadpool.dano} de daño.");
//                    if (ataqueDeadpool.esMaximo)
//                    {
//                        Console.WriteLine($"¡Ataque máximo! {wolverine.Nombre} no podrá atacar en el siguiente turno.");
//                    }
//                }
//            }
//            else
//            {
//                Console.WriteLine($"{deadpool.Nombre} no ataca este turno (regenerándose).");
//            }

//            // Verificar si Wolverine fue derrotado
//            if (wolverine.EstaDerrotado())
//            {
//                ganador = deadpool;
//                break;
//            }

//            // Wolverine ataca (si no está regenerándose)
//            var ataqueWolverine = wolverine.Atacar();
//            if (ataqueWolverine.dano > 0)
//            {
//                var resultado = deadpool.RecibirDano(ataqueWolverine.dano, ataqueWolverine.esMaximo);

//                if (resultado.fueEsquivado)
//                {
//                    Console.WriteLine($"{deadpool.Nombre} esquivó el ataque de {wolverine.Nombre}!");
//                }
//                else
//                {
//                    Console.WriteLine($"{wolverine.Nombre} ataca a {deadpool.Nombre} por {ataqueWolverine.dano} de daño.");
//                    if (ataqueWolverine.esMaximo)
//                    {
//                        Console.WriteLine($"¡Ataque máximo! {deadpool.Nombre} no podrá atacar en el siguiente turno.");
//                    }
//                }
//            }
//            else
//            {
//                Console.WriteLine($"{wolverine.Nombre} no ataca este turno (regenerándose).");
//            }

//            // Verificar si Deadpool fue derrotado
//            if (deadpool.EstaDerrotado())
//            {
//                ganador = wolverine;
//                break;
//            }

//            // Mostrar vida actual
//            Console.WriteLine($"Vida actual - {deadpool.Nombre}: {deadpool.Vida}, {wolverine.Nombre}: {wolverine.Vida}");

//            turno++;
//        }

//        // Mostrar resultado final
//        Console.WriteLine("\n=== RESULTADO FINAL ===");
//        Console.WriteLine($"¡{ganador.Nombre} gana la batalla en el turno {turno}!");
//        Console.WriteLine($"Vida final - Deadpool: {deadpool.Vida}, Wolverine: {wolverine.Vida}");
//    }
//}
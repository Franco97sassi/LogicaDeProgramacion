using System;
using System.Collections.Generic;
using System.Linq;

class SimuladorJJOO
{
    private List<string> eventos;
    private List<Participante> participantes;
    private List<ResultadoEvento> resultados;
    private Dictionary<string, MedallasPais> medallasPaises;

    public SimuladorJJOO()
    {
        eventos = new List<string>();
        participantes = new List<Participante>();
        resultados = new List<ResultadoEvento>();
        medallasPaises = new Dictionary<string, MedallasPais>();
    }

    public void RegistrarEvento()
    {
        Console.Write("Ingrese el nombre del evento deportivo: ");
        string nombre = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            eventos.Add(nombre.Trim());
            Console.WriteLine($"Evento '{nombre.Trim()}' registrado con éxito!");
        }
        else
        {
            Console.WriteLine("El nombre del evento no puede estar vacío.");
        }
    }

    public void RegistrarParticipante()
    {
        Console.Write("Ingrese el nombre del participante: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el país del participante: ");
        string pais = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(pais))
        {
            participantes.Add(new Participante(nombre.Trim(), pais.Trim()));
            Console.WriteLine($"Participante {nombre.Trim()} de {pais.Trim()} registrado con éxito!");
        }
        else
        {
            Console.WriteLine("Nombre y país son campos obligatorios.");
        }
    }

    public void SimularEvento()
    {
        if (eventos.Count == 0)
        {
            Console.WriteLine("No hay eventos registrados.");
            return;
        }

        if (participantes.Count < 3)
        {
            Console.WriteLine("Se necesitan al menos 3 participantes para simular un evento.");
            return;
        }

        Console.WriteLine("\nEventos disponibles:");
        for (int i = 0; i < eventos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {eventos[i]}");
        }

        Console.Write("Seleccione el número del evento a simular: ");
        if (!int.TryParse(Console.ReadLine(), out int seleccion) || seleccion < 1 || seleccion > eventos.Count)
        {
            Console.WriteLine("Selección inválida.");
            return;
        }

        string evento = eventos[seleccion - 1];
        var participantesEvento = participantes.OrderBy(x => Guid.NewGuid()).Take(Math.Min(10, participantes.Count)).ToList();

        if (participantesEvento.Count < 3)
        {
            Console.WriteLine("No hay suficientes participantes para este evento.");
            return;
        }

        var ganadores = participantesEvento.Take(3).ToList();
        var oro = ganadores[0];
        var plata = ganadores[1];
        var bronce = ganadores[2];

        // Registrar resultados
        resultados.Add(new ResultadoEvento(evento, oro, plata, bronce));

        // Actualizar conteo de medallas por país
        ActualizarMedallas(oro.Pais, TipoMedalla.Oro);
        ActualizarMedallas(plata.Pais, TipoMedalla.Plata);
        ActualizarMedallas(bronce.Pais, TipoMedalla.Bronce);

        Console.WriteLine("\nResultados del evento:");
        Console.WriteLine($"🥇 Oro: {oro.Nombre} ({oro.Pais})");
        Console.WriteLine($"🥈 Plata: {plata.Nombre} ({plata.Pais})");
        Console.WriteLine($"🥉 Bronce: {bronce.Nombre} ({bronce.Pais})");
    }

    private void ActualizarMedallas(string pais, TipoMedalla tipoMedalla)
    {
        if (!medallasPaises.ContainsKey(pais))
        {
            medallasPaises[pais] = new MedallasPais();
        }

        switch (tipoMedalla)
        {
            case TipoMedalla.Oro:
                medallasPaises[pais].Oro++;
                break;
            case TipoMedalla.Plata:
                medallasPaises[pais].Plata++;
                break;
            case TipoMedalla.Bronce:
                medallasPaises[pais].Bronce++;
                break;
        }
    }

    public void GenerarInforme()
    {
        if (resultados.Count == 0)
        {
            Console.WriteLine("No hay resultados para generar informe.");
            return;
        }

        Console.WriteLine("\n=== INFORME FINAL ===");

        // Mostrar ganadores por evento
        Console.WriteLine("\n🏆 Ganadores por evento:");
        foreach (var resultado in resultados)
        {
            Console.WriteLine($"\nEvento: {resultado.Evento}");
            Console.WriteLine($"  Oro: {resultado.Oro.Nombre} ({resultado.Oro.Pais})");
            Console.WriteLine($"  Plata: {resultado.Plata.Nombre} ({resultado.Plata.Pais})");
            Console.WriteLine($"  Bronce: {resultado.Bronce.Nombre} ({resultado.Bronce.Pais})");
        }

        // Mostrar ranking de países
        Console.WriteLine("\n🏅 Ranking de países por medallas:");

        var ranking = medallasPaises.Select(kvp => new
        {
            Pais = kvp.Key,
            Oro = kvp.Value.Oro,
            Plata = kvp.Value.Plata,
            Bronce = kvp.Value.Bronce,
            Total = kvp.Value.Oro + kvp.Value.Plata + kvp.Value.Bronce
        })
        .OrderByDescending(x => x.Oro)
        .ThenByDescending(x => x.Plata)
        .ThenByDescending(x => x.Bronce)
        .ToList();

        Console.WriteLine("\nPos | País\t| Oro | Plata | Bronce | Total");
        Console.WriteLine(new string('-', 45));
        for (int i = 0; i < ranking.Count; i++)
        {
            var paisInfo = ranking[i];
            Console.WriteLine($"{i + 1,3} | {paisInfo.Pais,-10} | {paisInfo.Oro,3} | {paisInfo.Plata,5} | {paisInfo.Bronce,6} | {paisInfo.Total,5}");
        }
    }
}

// Clases auxiliares
class Participante
{
    public string Nombre { get; }
    public string Pais { get; }

    public Participante(string nombre, string pais)
    {
        Nombre = nombre;
        Pais = pais;
    }
}

class ResultadoEvento
{
    public string Evento { get; }
    public Participante Oro { get; }
    public Participante Plata { get; }
    public Participante Bronce { get; }

    public ResultadoEvento(string evento, Participante oro, Participante plata, Participante bronce)
    {
        Evento = evento;
        Oro = oro;
        Plata = plata;
        Bronce = bronce;
    }
}

class MedallasPais
{
    public int Oro { get; set; }
    public int Plata { get; set; }
    public int Bronce { get; set; }
}

enum TipoMedalla
{
    Oro,
    Plata,
    Bronce
}

class Program
{
    static void Main(string[] args)
    {
        var simulador = new SimuladorJJOO();
        string opcion;

        do
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Registrar evento deportivo");
            Console.WriteLine("2. Registrar participante");
            Console.WriteLine("3. Simular evento");
            Console.WriteLine("4. Generar informe final");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    simulador.RegistrarEvento();
                    break;
                case "2":
                    simulador.RegistrarParticipante();
                    break;
                case "3":
                    simulador.SimularEvento();
                    break;
                case "4":
                    simulador.GenerarInforme();
                    break;
                case "5":
                    Console.WriteLine("¡Hasta luego! Que disfrutes de los Juegos Olímpicos de París 2024!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
                    break;
            }
        } while (opcion != "5");
    }
}
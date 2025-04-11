//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Program
//{
//    class Suscriptor
//    {
//        public string Id { get; set; }
//        public string Email { get; set; }
//        public string Status { get; set; }
//    }

//    static void Main(string[] args)
//    {
//        SeleccionarGanadores();
//    }

//    static void SeleccionarGanadores()
//    {
//        var suscriptoresActivos = new List<Suscriptor>();
//        var resultados = new Dictionary<string, Suscriptor>
//        {
//            { "suscripcion", null },
//            { "descuento", null },
//            { "libro", null }
//        };

//        try
//        {
//            // Leer el archivo CSV
//            var lineas = File.ReadAllLines("suscriptores.csv");

//            // Procesar cada línea (empezando desde la 1 para saltar el encabezado)
//            foreach (var linea in lineas.Skip(1))
//            {
//                var columnas = linea.Split('|').Select(c => c.Trim()).ToArray();

//                if (columnas.Length >= 3 && !string.IsNullOrEmpty(columnas[0]))
//                {
//                    suscriptoresActivos.Add(new Suscriptor
//                    {
//                        Id = columnas[0],
//                        Email = columnas[1],
//                        Status = columnas[2].ToLower()
//                    });
//                }
//            }

//            // Filtrar solo los activos
//            var activos = suscriptoresActivos.Where(s => s.Status == "activo").ToList();

//            if (activos.Count == 0)
//            {
//                Console.WriteLine("No hay suscriptores activos para realizar el sorteo.");
//                return;
//            }

//            // Crear una copia de la lista para ir eliminando ganadores
//            var candidatos = new List<Suscriptor>(activos);
//            var random = new Random();

//            // Asignar premios solo si hay suficientes candidatos
//            if (candidatos.Count > 0)
//            {
//                var indice = random.Next(candidatos.Count);
//                resultados["suscripcion"] = candidatos[indice];
//                candidatos.RemoveAt(indice);
//            }

//            if (candidatos.Count > 0)
//            {
//                var indice = random.Next(candidatos.Count);
//                resultados["descuento"] = candidatos[indice];
//                candidatos.RemoveAt(indice);
//            }

//            if (candidatos.Count > 0)
//            {
//                var indice = random.Next(candidatos.Count);
//                resultados["libro"] = candidatos[indice];
//            }

//            // Mostrar resultados
//            Console.WriteLine("🎉 Resultados del sorteo 🎉\n");

//            Console.WriteLine(resultados["suscripcion"] != null
//                ? $"🏆 Ganador de suscripción: {resultados["suscripcion"].Email} (ID: {resultados["suscripcion"].Id})"
//                : "No hay ganador para suscripción");

//            Console.WriteLine(resultados["descuento"] != null
//                ? $"🎁 Ganador de descuento: {resultados["descuento"].Email} (ID: {resultados["descuento"].Id})"
//                : "No hay ganador para descuento");

//            Console.WriteLine(resultados["libro"] != null
//                ? $"📚 Ganador de libro: {resultados["libro"].Email} (ID: {resultados["libro"].Id})"
//                : "No hay ganador para libro");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error al leer el archivo CSV: {ex.Message}");
//        }
//    }
//}
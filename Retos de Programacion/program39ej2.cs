//using System;
//using System.Collections.Generic;

//class BatcaveSecuritySystem
//{
//    private const int GridSize = 20;
//    private const int Threshold = 20;
//    private readonly (int x, int y) BatcavePosition = (0, 0);

//    public SecurityAnalysis AnalyzeThreats(List<Sensor> sensors)
//    {
//        int[,] threatGrid = new int[GridSize, GridSize];

//        // Poblar la matriz con datos de sensores
//        foreach (var sensor in sensors)
//        {
//            if (IsValidCoordinate(sensor.X, sensor.Y))
//            {
//                threatGrid[sensor.Y, sensor.X] += sensor.ThreatLevel;
//            }
//        }

//        // Encontrar la zona más crítica
//        int maxSum = 0;
//        (int x, int y) criticalCenter = (0, 0);

//        for (int y = 1; y < GridSize - 1; y++)
//        {
//            for (int x = 1; x < GridSize - 1; x++)
//            {
//                int sum = Calculate3x3Sum(threatGrid, x, y);
//                if (sum > maxSum)
//                {
//                    maxSum = sum;
//                    criticalCenter = (x, y);
//                }
//            }
//        }

//        // Calcular distancia a la Batcueva
//        int distance = Math.Abs(criticalCenter.x - BatcavePosition.x) +
//                      Math.Abs(criticalCenter.y - BatcavePosition.y);

//        // Determinar si activar protocolo
//        bool activateProtocol = maxSum > Threshold;

//        return new SecurityAnalysis
//        {
//            CriticalCenter = criticalCenter,
//            ThreatSum = maxSum,
//            DistanceToBatcave = distance,
//            ShouldActivateProtocol = activateProtocol
//        };
//    }

//    private int Calculate3x3Sum(int[,] grid, int centerX, int centerY)
//    {
//        int sum = 0;
//        for (int y = centerY - 1; y <= centerY + 1; y++)
//        {
//            for (int x = centerX - 1; x <= centerX + 1; x++)
//            {
//                if (IsValidCoordinate(x, y))
//                {
//                    sum += grid[y, x];
//                }
//            }
//        }
//        return sum;
//    }

//    private bool IsValidCoordinate(int x, int y)
//    {
//        return x >= 0 && x < GridSize && y >= 0 && y < GridSize;
//    }
//}

//// Modelos de datos
//class Sensor
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public int ThreatLevel { get; set; }
//}

//class SecurityAnalysis
//{
//    public (int x, int y) CriticalCenter { get; set; }
//    public int ThreatSum { get; set; }
//    public int DistanceToBatcave { get; set; }
//    public bool ShouldActivateProtocol { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        var securitySystem = new BatcaveSecuritySystem();

//        // Datos de ejemplo
//        var sensors = new List<Sensor>
//        {
//            new Sensor { X = 5, Y = 5, ThreatLevel = 3 },
//            new Sensor { X = 6, Y = 5, ThreatLevel = 5 },
//            new Sensor { X = 5, Y = 6, ThreatLevel = 4 },
//            new Sensor { X = 6, Y = 6, ThreatLevel = 7 },
//            new Sensor { X = 15, Y = 15, ThreatLevel = 8 },
//            new Sensor { X = 16, Y = 15, ThreatLevel = 6 },
//            new Sensor { X = 15, Y = 16, ThreatLevel = 9 },
//            new Sensor { X = 10, Y = 10, ThreatLevel = 2 }
//        };

//        var result = securitySystem.AnalyzeThreats(sensors);

//        Console.WriteLine("Resultado del análisis de seguridad:");
//        Console.WriteLine($"- Centro de la zona crítica: ({result.CriticalCenter.x}, {result.CriticalCenter.y})");
//        Console.WriteLine($"- Suma de amenazas: {result.ThreatSum}");
//        Console.WriteLine($"- Distancia a la Batcueva: {result.DistanceToBatcave}");
//        Console.WriteLine($"- Activar protocolo de seguridad: {(result.ShouldActivateProtocol ? "SÍ" : "NO")}");
//    }
//}
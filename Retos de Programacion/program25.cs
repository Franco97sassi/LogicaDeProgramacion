//using Microsoft.Extensions.Logging;
//using System.Diagnostics;

//// Configurar el logger
//var loggerFactory = LoggerFactory.Create(builder =>
//{
//    builder
//        .AddFilter("Microsoft", LogLevel.Warning)
//        .AddFilter("System", LogLevel.Warning)
//        .AddFilter("LoggingExample", LogLevel.Debug)
//        .AddConsole();
//});

//ILogger logger = loggerFactory.CreateLogger<Program>();

//// Ejemplos de logging con diferentes niveles
//logger.LogTrace("Este es un mensaje de nivel Trace - Detalles muy finos");
//logger.LogDebug("Este es un mensaje de nivel Debug - Información para depuración");
//logger.LogInformation("Este es un mensaje de nivel Information - Flujo normal");
//logger.LogWarning("Este es un mensaje de nivel Warning - Evento inesperado");
//logger.LogError("Este es un mensaje de nivel Error - Algo falló pero podemos continuar");
//logger.LogCritical("Este es un mensaje de nivel Critical - Fallo crítico que puede detener la app");
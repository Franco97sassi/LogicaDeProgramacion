//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;

//public class TaskManager
//{
//    private readonly ILogger<TaskManager> _logger;
//    private readonly Dictionary<string, string> _tasks = new Dictionary<string, string>();

//    public TaskManager(ILogger<TaskManager> logger)
//    {
//        _logger = logger;
//    }

//    public void AddTask(string name, string description)
//    {
//        var stopwatch = Stopwatch.StartNew();

//        try
//        {
//            if (_tasks.ContainsKey(name))
//            {
//                _logger.LogWarning($"Intento de añadir tarea existente: {name}");
//                return;
//            }

//            _tasks.Add(name, description);
//            _logger.LogInformation($"Tarea añadida: {name}");
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, $"Error al añadir tarea {name}");
//        }
//        finally
//        {
//            stopwatch.Stop();
//            _logger.LogDebug($"Tiempo de ejecución para AddTask: {stopwatch.ElapsedMilliseconds}ms");
//        }
//    }

//    public void RemoveTask(string name)
//    {
//        var stopwatch = Stopwatch.StartNew();

//        try
//        {
//            if (!_tasks.ContainsKey(name))
//            {
//                _logger.LogWarning($"Intento de eliminar tarea inexistente: {name}");
//                return;
//            }

//            _tasks.Remove(name);
//            _logger.LogInformation($"Tarea eliminada: {name}");
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, $"Error al eliminar tarea {name}");
//        }
//        finally
//        {
//            stopwatch.Stop();
//            _logger.LogDebug($"Tiempo de ejecución para RemoveTask: {stopwatch.ElapsedMilliseconds}ms");
//        }
//    }

//    public void ListTasks()
//    {
//        var stopwatch = Stopwatch.StartNew();

//        _logger.LogInformation("Listando tareas...");
//        foreach (var task in _tasks)
//        {
//            _logger.LogInformation($"Tarea: {task.Key} - Descripción: {task.Value}");
//        }

//        stopwatch.Stop();
//        _logger.LogDebug($"Tiempo de ejecución para ListTasks: {stopwatch.ElapsedMilliseconds}ms");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Configurar el logger
//        var loggerFactory = LoggerFactory.Create(builder =>
//        {
//            builder
//                .AddFilter("Microsoft", LogLevel.Warning)
//                .AddFilter("System", LogLevel.Warning)
//                .AddFilter("TaskManager", LogLevel.Debug)
//                .AddConsole();
//        });

//        var logger = loggerFactory.CreateLogger<TaskManager>();
//        var taskManager = new TaskManager(logger);

//        // Ejemplo de uso
//        taskManager.AddTask("Compras", "Comprar leche y pan");
//        taskManager.AddTask("Estudiar", "Repasar C# y logging");
//        taskManager.AddTask("Compras", "Intentar duplicar tarea"); // Generará warning

//        taskManager.ListTasks();

//        taskManager.RemoveTask("Estudiar");
//        taskManager.RemoveTask("No existe"); // Generará warning

//        taskManager.ListTasks();
//    }
//}
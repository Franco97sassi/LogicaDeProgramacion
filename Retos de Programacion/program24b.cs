using System;
 
// Interfaz para funciones que queremos decorar
public interface IFunction
{
    void Execute();
}

// Implementación concreta de una función
public class MyFunction : IFunction
{
    public void Execute()
    {
        Console.WriteLine("Ejecutando la función principal...");
    }
}

// Decorador que cuenta las ejecuciones
public class CountCallsDecorator : IFunction
{
    private readonly IFunction _decoratedFunction;
    private int _callCount;

    public CountCallsDecorator(IFunction function)
    {
        _decoratedFunction = function;
        _callCount = 0;
    }

    public void Execute()
    {
        _decoratedFunction.Execute();
        _callCount++;
        Console.WriteLine($"Esta función ha sido llamada {_callCount} veces.");
    }

    public int GetCallCount() => _callCount;
}

class Program
{
    static void Main(string[] args)
    {
        // Crear la función original
        IFunction myFunction = new MyFunction();

        // Decorarla con el contador
        var countedFunction = new CountCallsDecorator(myFunction);

        // Llamar varias veces
        countedFunction.Execute();
        countedFunction.Execute();
        countedFunction.Execute();

        // Mostrar el conteo total
        Console.WriteLine($"\nConteo total: {countedFunction.GetCallCount()}");
    }
}
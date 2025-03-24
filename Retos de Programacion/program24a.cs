//using System;

//// Interfaz base
//public interface IComponent
//{
//    void Operation();
//}

//// Componente concreto
//public class ConcreteComponent : IComponent
//{
//    public void Operation()
//    {
//        Console.WriteLine("Operación básica");
//    }
//}

//// Decorador base
//public abstract class Decorator : IComponent
//{
//    protected IComponent _component;

//    public Decorator(IComponent component)
//    {
//        _component = component;
//    }

//    public virtual void Operation()
//    {
//        _component.Operation();
//    }
//}

//// Decorador concreto 1
//public class ConcreteDecoratorA : Decorator
//{
//    public ConcreteDecoratorA(IComponent component) : base(component) { }

//    public override void Operation()
//    {
//        base.Operation();
//        AddedBehavior();
//    }

//    private void AddedBehavior()
//    {
//        Console.WriteLine("Comportamiento añadido por Decorador A");
//    }
//}

//// Decorador concreto 2
//public class ConcreteDecoratorB : Decorator
//{
//    public ConcreteDecoratorB(IComponent component) : base(component) { }

//    public override void Operation()
//    {
//        base.Operation();
//        AddedBehavior();
//    }

//    private void AddedBehavior()
//    {
//        Console.WriteLine("Comportamiento añadido por Decorador B");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Crear componente básico
//        IComponent component = new ConcreteComponent();
        
//        // Decorarlo con A
//        IComponent decoratedA = new ConcreteDecoratorA(component);
        
//        // Decorarlo con A y B
//        IComponent decoratedAB = new ConcreteDecoratorB(new ConcreteDecoratorA(component));
        
//        Console.WriteLine("Componente simple:");
//        component.Operation();
        
//        Console.WriteLine("\nComponente decorado con A:");
//        decoratedA.Operation();
        
//        Console.WriteLine("\nComponente decorado con A y B:");
//        decoratedAB.Operation();
//    }
//}
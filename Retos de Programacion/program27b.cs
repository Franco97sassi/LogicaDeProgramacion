//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{
 

//    // Implementación que sigue OCP
//    public interface IShape
//    {
//        double CalculateArea();
//    }

//    public class Rectangle : IShape
//    {
//        public double Width { get; set; }
//        public double Height { get; set; }

//        public double CalculateArea()
//        {
//            return Width * Height;
//        }
//    }

//    public class Circle : IShape
//    {
//        public double Radius { get; set; }

//        public double CalculateArea()
//        {
//            return Math.PI * Radius * Radius;
//        }
//    }

//    public class AreaCalculator
//    {
//        public double CalculateArea(IShape shape)
//        {
//            return shape.CalculateArea();
//        }
//    }

//    // Podemos añadir nuevas formas sin modificar AreaCalculator
//    public class Triangle : IShape
//    {
//        public double Base { get; set; }
//        public double Height { get; set; }

//        public double CalculateArea()
//        {
//            return 0.5 * Base * Height;
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            var calculator = new AreaCalculator();
//            var rectangle = new Rectangle { Width = 5, Height = 4 };
//            var circle = new Circle { Radius = 3 };
//            var triangle = new Triangle { Base = 6, Height = 4 };

//            Console.WriteLine($"Área del rectángulo: {calculator.CalculateArea(rectangle)}");
//            Console.WriteLine($"Área del círculo: {calculator.CalculateArea(circle)}");
//            Console.WriteLine($"Área del triángulo: {calculator.CalculateArea(triangle)}");
//        }
//    }
//}

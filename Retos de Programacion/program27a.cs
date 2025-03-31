//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{
//    using System;
//    using System.Collections.Generic;

//    // Implementación que viola OCP
//    public class AreaCalculator
//    {
//        public double CalculateArea(object shape)
//        {
//            if (shape is Rectangle rectangle)
//            {
//                return rectangle.Width * rectangle.Height;
//            }
//            else if (shape is Circle circle)
//            {
//                return Math.PI * circle.Radius * circle.Radius;
//            }
//            // Si añadimos una nueva forma, tenemos que modificar esta clase
//            throw new ArgumentException("Forma no soportada");
//        }
//    }

//    public class Rectangle
//    {
//        public double Width { get; set; }
//        public double Height { get; set; }
//    }

//    public class Circle
//    {
//        public double Radius { get; set; }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            var calculator = new AreaCalculator();
//            var rectangle = new Rectangle { Width = 5, Height = 4 };
//            var circle = new Circle { Radius = 3 };

//            Console.WriteLine($"Área del rectángulo: {calculator.CalculateArea(rectangle)}");
//            Console.WriteLine($"Área del círculo: {calculator.CalculateArea(circle)}");
//        }
//    }
//}

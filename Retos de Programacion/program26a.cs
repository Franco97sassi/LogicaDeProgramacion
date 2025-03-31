//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Retos_de_Programacion
//{


//    // Clase que viola el SRP - hace demasiadas cosas
//    public class Report
//    {
//        public string Content { get; set; }

//        public string GenerateReport()
//        {
//            return $"Report content: {Content}";
//        }

//        public void SaveToFile(string filePath)
//        {
//            File.WriteAllText(filePath, GenerateReport());
//        }

//        public void PrintReport()
//        {
//            Console.WriteLine(GenerateReport());
//        }
//    }
//}

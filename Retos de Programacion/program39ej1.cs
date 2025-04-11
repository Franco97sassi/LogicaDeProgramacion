//using System;

//class BatmanDayCalculator
//{
//    static void Main()
//    {
//        Console.WriteLine("Fechas del Batman Day hasta el 100 aniversario:");
//        CalculateBatmanDays();
//    }

//    static void CalculateBatmanDays()
//    {
//        const int batmanAnniversary = 85; // Este año cumple 85
//        const int yearsRemaining = 100 - batmanAnniversary;
//        int currentYear = DateTime.Now.Year;

//        for (int i = 0; i <= yearsRemaining; i++)
//        {
//            int year = currentYear + i;
//            DateTime batmanDay = FindThirdSaturdayInSeptember(year);
//            Console.WriteLine($"{year}: {batmanDay.ToString("dd/MM/yyyy")} (Día {batmanDay.DayOfWeek})");
//        }
//    }

//    static DateTime FindThirdSaturdayInSeptember(int year)
//    {
//        DateTime date = new DateTime(year, 9, 1);
//        int saturdaysFound = 0;

//        while (saturdaysFound < 3)
//        {
//            if (date.DayOfWeek == DayOfWeek.Saturday)
//            {
//                saturdaysFound++;
//                if (saturdaysFound == 3) break;
//            }
//            date = date.AddDays(1);
//        }

//        return date;
//    }
//}
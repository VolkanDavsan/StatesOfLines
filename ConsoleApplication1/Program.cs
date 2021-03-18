using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public class Pair
        {
            public double first, second;

            public Pair(double first, double second)
            {
                this.first = first;
                this.second = second;
            }
        }

      
        static void lineFromPoints(Pair P, Pair Q, Pair P1, Pair Q1)
        {
            bool exit = true;
            //İlk koordinatlar için doğru oluşturma kontrolü.
            if(P.first == Q.first && P.second == Q.second)
            {
                Console.WriteLine("İlk girilen koordinatlar bir doğru oluşturmuyor.");
                exit = false;
                
            }
            //İkinci koordinatlar için doğru oluşturma kontrolü.
            if (exit == true)
            {
                if (P1.first == Q1.first && P1.second == Q1.second)
                {
                    Console.WriteLine("İkinci girilen koordinatlar bir doğru oluşturmuyor.");
                    exit = false;

                }

            }
         
            
            double a = Q.second - P.second;
            double b = P.first - Q.first;
            double c = a * (P.first) + b * (P.second);

            double a1 = Q1.second - P1.second;
            double b1 = P1.first - Q1.first;
            double c1 = a * (P1.first) + b * (P1.second);
            if (exit == true)
            {
                if (a == 0 && a1 == 0 && P.second == P1.second && Q.second == Q1.second)
                {
                    Console.WriteLine("Doğrular çakışıyor...");
                    exit = false;
                }
                else if (a == 0 && a1 == 0 && P.second != P1.second && Q.second != Q1.second)
                {
                    Console.WriteLine("Doğrular birbirine paraleldir...");
                    exit = false;

                }
            }
            if(exit == true)
            {
                if(b == 0 && b1 == 0 &&   P.first == P1.first && Q.first == Q1.first)
                {
                    Console.WriteLine("Doğrular çakışıyor...");
                    exit = false;
                }
                else if (b == 0 && b1 == 0 && P.first != P1.first && Q.first != Q1.first)
                {
                    Console.WriteLine("Doğrular birbirine paraleldir...");
                    exit = false;

                }
            }

            if (exit == true)
            {
                if (a / a1 == b / b1 && a / a1 != -c / -c1)
                {
                    Console.WriteLine("Doğrular birbirine paraleldir...");
                }
                else if (a / a1 != b / b1)
                {
                    Console.WriteLine("Doğrular birbiriyle kesişiyor...");
                }
                else if (a / a1 == b / b1 && a / a1 == -c / -c1)
                {
                    Console.WriteLine("Doğrular çakışıyor...");
                }
            }
            
            
           // if (b < 0)
           // {
           //     Console.WriteLine(
           //         "The line passing through points P and Q is: "
           //         + a + "x - " + b + "y = " + c);
           // }
           // else {
           //     Console.WriteLine(
           //         "The line passing through points P and Q is: "
           //         + a + "x + " + b + "y = " + c);
           //}
           // if (b < 0)
           // {
           //     Console.WriteLine(
           //         "The line passing through points P1 and Q1 is: "
           //         + a1 + "x - " + b1 + "y = " + c1);
           // }
           // else {
           //     Console.WriteLine(
           //         "The line passing through points P1 and Q1 is: "
           //         + a1 + "x + " + b1 + "y = " + c1);
           // }
        }


        static void Main(string[] args)
        {
                int co1, co2, co3, co4, co5, co6, co7, co8;


                //İlk doğru
                Console.Write("İLK DOĞRUYU YARATMAK İÇİN: ");
                Console.WriteLine();

                Console.Write("İlk nokta için X koordinatını girin: ");
                co1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İlk nokta için Y koordinatını girin: ");
                co2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İkinci nokta için X koordinatını girin: ");
                co3 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İkinci nokta için Y koordinatını girin: ");
                co4 = Convert.ToInt32(Console.ReadLine());
                //İkinci doğru
                Console.Write("İKİNCİ DOĞRUYU YARATMAK İÇİN: ");
                Console.WriteLine();
                Console.Write("İlk nokta için X koordinatını girin: ");
                co5 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İlk nokta için Y koordinatını girin: ");
                co6 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İkinci nokta için X koordinatını girin: ");
                co7 = Convert.ToInt32(Console.ReadLine());
                Console.Write("İkinci nokta için Y koordinatını girin: ");
                co8 = Convert.ToInt32(Console.ReadLine());
                


                Pair P1 = new Pair(co1, co2); //ilk nokta
                Pair Q1 = new Pair(co3, co4); //ikinci nokta

                Pair P2 = new Pair(co5, co6); //ilk nokta
                Pair Q2 = new Pair(co7, co8); // ikinci nokta
                lineFromPoints(P1, Q1, P2, Q2);
                Console.Read();

            
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConsoleApplication1
{
    class Program
    {
        public class Pair
        {
            public double first, second;

            public Pair(double first, double second) //Nokta objesi
            {
                this.first = first; //x kord.
                this.second = second; //y kord.
            }
        }
        //public class Pen
        //{
        //    public ConsoleColor color;
        //    public int width;
        //    public Pen(ConsoleColor color, int width)
        //    {
        //        this.color = color;
        //        this.width = width
        //    }
        //}
       


        static void lineFromPoints(Pair P, Pair Q, Pair P1, Pair Q1) //Kontrol yapılan method. P, Q ilk doğru. P1, Q1 ikinci doğru.
        {
            bool exit = true;
            //İlk koordinatlar için doğru oluşturma kontrolü.
            if (P.first == Q.first && P.second == Q.second)
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

            //ax+by+c doğru denklemindeki a b ve c'yi bulma operasyonu.
            double a = Q.second - P.second;
            double b = (P.first - Q.first);
            double c = a * (P.first) + b * (P.second);

            double a1 = Q1.second - P1.second;
            double b1 = (P1.first - Q1.first);
            double c1 = a1 * (P1.first) + b1 * (P1.second);

            //double x = -((c1 - c) / (-a1 + a)); //kesiştikleri x noktası

            double x = ((c/b) - (c1/b1)) / ((a/b)-(a1/ b1)); //kesişimin x noktası.
            double y = ((-a * x) + c) / b; //kesişimin y noktası.
            double cornerc = Math.Sqrt((x - P.first) * (x - P.first) + (y - P.second) * (y - P.second));
            double cornerb = Math.Sqrt((x - Q1.first) * (x - Q1.first) + (y - Q1.second) * (y - Q1.second));
            double cornera = Math.Sqrt((P.first - Q1.first) * (P.first - Q1.first) + (P.second - Q1.second) * (P.second - Q1.second));
             

            //Yatay doğrular için kontrolün yapıldığı yer.
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
            //Dikey doğrular için kontrolün yapıldığı yer.
            if (exit == true)
            {
                if (b == 0 && b1 == 0 && P.first == P1.first && Q.first == Q1.first)
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

            //Diyagonal doğrular için asıl karşılaştırmanın yapıldığı yer.
            if (exit == true)
            {
                if ((a / a1) == (b / b1) && (a / a1) == (-c / -c1))
                {
                    Console.WriteLine("Doğrular çakışıyor...");
                }
                else if (a / a1 != b / b1)
                {
                    Console.WriteLine("Doğrular birbiriyle kesişiyor...");
                    double slope = a / b;
                    double slope1 = a1 / b1;
                    double deneme = Math.Abs((slope1 - slope) / (1 + slope * slope1));
                    double dnm = Math.Atan(deneme) * 180 / Math.PI;
                    
                    Console.WriteLine("İki doğrunun kesiştiği açı :" + dnm);
                    Console.WriteLine();
                    Console.WriteLine(" Kesişme Noktası X Noktası : " + x +  " Kesişme Noktası Y Noktası: " + y);
                    Console.WriteLine("C kenarı: " + cornerc + " B kenarı: " + cornerb + " A kenarı : " + cornera);
                    double angleb = Math.Asin((cornerb * (Math.Sin(dnm*Math.PI/180)) / cornera)) *180/ Math.PI; //bunu dik olmayanlar için kullanalım.
                    double anglec = Math.Asin((cornerc * (Math.Sin(dnm*Math.PI / 180)) / cornera)) *180/Math.PI;

                   
                    Console.WriteLine("sinüs teorimine göre b açısı: " + angleb + " c açısı: " + anglec);
                    Console.WriteLine("Üçgenin Çevresi: " + (cornera + cornerb + cornerc));
                    double yaricevre = (cornera + cornerb + cornerc) / 2;
                    double area = Math.Sqrt(yaricevre * (yaricevre - cornera) * (yaricevre - cornerb) * (yaricevre - cornerc));
                    Console.WriteLine("Üçgenin Alanı: " + area);
                    if (dnm == 90 || angleb == 90 || anglec == 90)
                    {
                        Console.WriteLine("ÜÇGEN TİPİ : Bu bir dik üçgendir.");

                    }
                    else if (dnm < 90 && angleb < 90 && anglec < 90)
                    {
                        Console.WriteLine("ÜÇGEN TİPİ : Bu bir dar üçgendir.");
                    }
                    else if (dnm > 90 || angleb > 90 || anglec > 90)
                    {
                        Console.WriteLine("ÜÇGEN TİPİ : Bu bir geniş  üçgendir.");
                    }
                }
                else if ((a / a1 == b / b1) && (a / a1 != -c / -c1))
                {
                    Console.WriteLine("Doğrular birbirine paraleldir...");


                }
            }

            if (b < 0)
            {
                Console.WriteLine(
                    "The line passing through points P and Q is: "
                    + a + "x - " + b + "y = " + c);
            }
            else {
                Console.WriteLine(
                    "The line passing through points P and Q is: "
                    + a + "x + " + b + "y = " + c);
            }
            if (b < 0)
            {
                Console.WriteLine(
                    "The line passing through points P1 and Q1 is: "
                    + a1 + "x - " + b1 + "y = " + c1);
            }
            else {
                Console.WriteLine(
                    "The line passing through points P1 and Q1 is: "
                    + a1 + "x + " + b1 + "y = " + c1);
            }


        }
        static void Main(string[] args)
        {
            while (true)
            {

                double co1, co2, co3, co4, co5, co6, co7, co8; //koordinat değerleri.


                //İlk doğru
                Console.Write("İLK DOĞRUYU YARATMAK İÇİN: ");
                Console.WriteLine();

                Console.Write("İlk nokta için X koordinatını girin: ");
                co1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İlk nokta için Y koordinatını girin: ");
                co2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İkinci nokta için X koordinatını girin: ");
                co3 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İkinci nokta için Y koordinatını girin: ");
                co4 = Convert.ToDouble(Console.ReadLine());

                //İkinci doğru
                Console.Write("İKİNCİ DOĞRUYU YARATMAK İÇİN: ");
                Console.WriteLine();
                Console.Write("İlk nokta için X koordinatını girin: ");
                co5 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İlk nokta için Y koordinatını girin: ");
                co6 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İkinci nokta için X koordinatını girin: ");
                co7 = Convert.ToDouble(Console.ReadLine());
                Console.Write("İkinci nokta için Y koordinatını girin: ");
                co8 = Convert.ToDouble(Console.ReadLine());



                Pair P1 = new Pair(co1, co2); //ilk doğru için ilk nokta
                Pair Q1 = new Pair(co3, co4); //ilk doğru için ikinci nokta

                Pair P2 = new Pair(co5, co6); //ikinci doğru için ilk nokta
                Pair Q2 = new Pair(co7, co8); //ikinci doğru için ikinci nokta
                lineFromPoints(P1, Q1, P2, Q2);

            }



        }
    }

   
}

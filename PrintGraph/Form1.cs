using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintGraph
{

    public partial class Form1 : Form
    {
        Bitmap bmap;
        

        public Form1()
        {
            bmap = new Bitmap(this.Width, this.Height);
            InitializeComponent();
            

        }
        public class Pair
        {
            public double first, second;

            public Pair(double first, double second) //Nokta objesi
            {
                this.first = first; //x kord.
                this.second = second; //y kord.
            }
        }

        public double[] lineFromPoints(Pair P, Pair Q, Pair P1, Pair Q1) //Kontrol yapılan method. P, Q ilk doğru. P1, Q1 ikinci doğru.
        {
            bool exit = true;
            //İlk koordinatlar için doğru oluşturma kontrolü.
            if (P.first == Q.first && P.second == Q.second)
            {
                label11.Text = "- İlk girilen koordinatlar bir doğru oluşturmuyor. Birbirinden farklı iki nokta seçin.";
                exit = false;
            }
            //İkinci koordinatlar için doğru oluşturma kontrolü.
            if (exit == true)
            {
                if (P1.first == Q1.first && P1.second == Q1.second)
                {
                    label13.Text = "-İkinci girilen koordinatlar bir doğru oluşturmuyor. Birbirinden farklı iki nokta" +
    " seçin.";
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


            double x = ((c / b) - (c1 / b1)) / ((a / b) - (a1 / b1)); //kesişimin x noktası.
            double y = ((-a * x) + c) / b; //kesişimin y noktası.

            double cornerc = Math.Sqrt((x - P.first) * (x - P.first) + (y - P.second) * (y - P.second));  
            double ccorner = Convert.ToDouble(Math.Sqrt((x - P.first) * (x - P.first) + (y - P.second) * (y - P.second)).ToString("0.00"));

            double cornerb = Math.Sqrt((x - Q1.first) * (x - Q1.first) + (y - Q1.second) * (y - Q1.second));
            double bcorner = Convert.ToDouble(Math.Sqrt((x - Q1.first) * (x - Q1.first) + (y - Q1.second) * (y - Q1.second)).ToString("0.00"));

            double cornera = Math.Sqrt((P.first - Q1.first) * (P.first - Q1.first) + (P.second - Q1.second) * (P.second - Q1.second));
            double acorner = Convert.ToDouble(Math.Sqrt((P.first - Q1.first) * (P.first - Q1.first) + (P.second - Q1.second) * (P.second - Q1.second)).ToString("0.00"));


            //Yatay doğrular için kontrolün yapıldığı yer.
            if (exit == true)
            {
                if (a == 0 && a1 == 0 && P.second == P1.second && Q.second == Q1.second)
                {
                    label14.Text = "- Doğrular birbiriyle çakışıyor..";
                    exit = false;
                }
                else if (a == 0 && a1 == 0 && P.second != P1.second && Q.second != Q1.second)
                {
                    label15.Text = "- Doğrular birbirine paraleldir...";
                    exit = false;

                }
            }
            //Dikey doğrular için kontrolün yapıldığı yer.
            if (exit == true)
            {
                if (b == 0 && b1 == 0 && P.first == P1.first && Q.first == Q1.first)
                {
                    label14.Text = "- Doğrular birbiriyle çakışıyor..";
                    exit = false;
                }
                else if (b == 0 && b1 == 0 && P.first != P1.first && Q.first != Q1.first)
                {
                    label15.Text = "- Doğrular birbirine paraleldir...";
                    exit = false;

                }
            }

            //Diyagonal doğrular için asıl karşılaştırmanın yapıldığı yer.
            if (exit == true)
            {
                if ((a / a1) == (b / b1) && (a / a1) == (-c / -c1))
                {
                    label14.Text = "- Doğrular birbiriyle çakışıyor..";
                }
                else if (a / a1 != b / b1)
                {
                    label21.Text = "ÜÇGENİN BİLGİLERİ";
                    label16.Text = "- Doğrular birbiriyle kesişiyor..";
                    label34.Text = "Üçgen Tipi: ";

                    label17.Text = "Kesişme Noktaları: X = ";
                    label18.Text = x.ToString();
                    label19.Text = "Y = ";
                    label20.Text = y.ToString();
                   
                    label22.Text = "A Kenar Uzunluğu";
                    
                    label23.Text = acorner.ToString(); 
                    label24.Text = "B Kenar Uzunluğu";
                    
                    label25.Text = bcorner.ToString();
                    label26.Text = "C Kenar Uzunluğu";
                    label27.Text = ccorner.ToString();
                    double slope = a / b;
                    double slope1 = a1 / b1;
                    double slopeangle = Math.Abs((slope1 - slope) / (1 + slope * slope1));
                    
                    double anglea = Convert.ToDouble(((Math.Atan(slopeangle) * 180 / Math.PI)).ToString("0.00"));
                    
                    double anglea2 = (Math.Atan(slopeangle) * 180 / Math.PI);
                    double angleb2 = (Math.Asin((cornerb * (Math.Sin(anglea2 * Math.PI / 180)) / cornera)) * 180 / Math.PI);
                    double anglec2 = (Math.Asin((cornerc * (Math.Sin(anglea2 * Math.PI / 180)) / cornera)) * 180 / Math.PI);
                    double angleb = Convert.ToDouble((Math.Asin((cornerb * (Math.Sin(anglea2 * Math.PI / 180)) / cornera)) * 180 / Math.PI).ToString("0.00")); // b açısı
                    double anglec = Convert.ToDouble((Math.Asin((cornerc * (Math.Sin(anglea2 * Math.PI / 180)) / cornera)) * 180 / Math.PI).ToString("0.00")); // c açısı
                    if (Math.Round(((180 - anglea2) + angleb2 + anglec2)) == 180 )
                    {
                        anglea = 180 - anglea;
                        anglea2 = 180 - anglea2;
                    }
                    else if(Math.Round((anglea2 + (180 - angleb2) + anglec2)) == 180)
                    {
                        angleb = 180 - angleb;
                        angleb2 = 180 - angleb2;
                    }
                    else if (Math.Round((anglea2 + (180 - anglec2) + angleb2)) == 180)
                    {
                        anglec = 180 - anglec;
                        anglec2 = 180 - anglec2;
                    }
                    label28.Text = "A Açısı"; label29.Text = "B Açısı"; label30.Text = "C Açısı";
                     label31.Text = anglea.ToString(); label32.Text = angleb.ToString(); label33.Text = anglec.ToString();

                    label35.Text = "Üçgenin Çevresi: "; label37.Text = Convert.ToDouble((cornera + cornerb + cornerc).ToString("0.00")).ToString();
                    double yaricevre = (cornera + cornerb + cornerc) / 2; // çevrenin yarısı
                    double area = Convert.ToDouble((Math.Sqrt(yaricevre * (yaricevre - cornera) * (yaricevre - cornerb) * (yaricevre - cornerc))).ToString("0.00")); // alan bulma operasyonu
                    label36.Text = "Üçgenin Alanı: ";
                    label38.Text = area.ToString();
                    if (anglea == 90 || angleb == 90 || anglec == 90) // Üçgen tipi bulmak için yapılan if else.
                    {
                        label39.Text = "Dik Üçgen";
                    }
                    else if (anglea < 90 && angleb < 90 && anglec < 90)
                    {
                        label40.Text = "Dar Üçgen";
                    }
                    else if (anglea > 90 || angleb > 90 || anglec > 90)
                    {
                        label41.Text = "Geniş Üçgen";
                    }
                }
                else if ((a / a1 == b / b1) && (a / a1 != -c / -c1))
                {
                    Console.WriteLine("Doğrular birbirine paraleldir...");
                    label15.Text = "- Doğrular birbirine paraleldir...";

                }
            }
            return new double[] { x,y};

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            mainFunc();
            drawGraph();
            drawTriangle();
        }

        private void drawGraph()
        {
            //label42.Text = "DOĞRU GÖSTERİMİ";
            float[] degerler = mainFunc();
           
                normalizeGraph(degerler); //normalize methodu
           
                
                Graphics g,c;
            c = this.CreateGraphics();
            g = this.CreateGraphics();
                g.TranslateTransform(550, 150); //orijini ortalama.
                g.ScaleTransform(1.0F, -1.0F); // y eksenini çevir.
                Pen redPen = new Pen(Color.Red, 2);
                Pen bluePen = new Pen(Color.Blue, 2);
            Pen origin = new Pen(Color.Red, 3);
                //kullanıcı tarafından girilen değerler.
                float x1 = degerler[0], y1 = degerler[1];
                float x2 = degerler[2], y2 = degerler[3];
                float x3 = degerler[4], y3 = degerler[5];
                float x4 = degerler[6], y4 = degerler[7];
                //Grafiğe çizme operasyonu.
                g.DrawLine(redPen, x1, y1, x2, y2);
                g.DrawLine(bluePen, x3, y3, x4, y4);
            c.TranslateTransform(300,-20);
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if(y == 11 && x == 10 )
                    {
                      
                        c.DrawLine(origin,200, -20, 200, 400);
                        c.DrawLine(origin, 0, 220, 400, 220);
                    }
                    else
                    {
                        c.DrawRectangle(Pens.Black, x * 20, y * 20, 20, 20);
                    }
                    
                }
            }
            redPen.Dispose();
                bluePen.Dispose();
                g.Dispose();
        }
        private void drawTriangle()
        {
            float[] degerler = mainFunc();
            if(degerler.Count() != 8)
            {
                label43.Text = "ÜÇGEN GÖSTERİMİ";

                normalizeGraph(degerler); //normalize methodu
                
                
                Graphics g;
                g = this.CreateGraphics();
                //this.label43.Location = new System.Drawing.Point(431, 396);
                g.TranslateTransform(431, 470); //orijini ortalama.
                g.ScaleTransform(1.0F, -1.0F); // y eksenini çevir.
                
                Pen redPen = new Pen(Color.Red, 2);
                Pen bluePen = new Pen(Color.Blue, 2);
                Pen greenPen = new Pen(Color.Green, 2);
                //kullanıcı tarafından girilen değerler.
                float x1 = degerler[0], y1 = degerler[1];
                float x2 = degerler[6], y2 = degerler[7];
                float x3 = degerler[8], y3 = degerler[9];
                //Grafiğe çizme operasyonu.
                g.DrawLine(greenPen, x1, y1, x2, y2);
                g.DrawLine(redPen, x1, y1, x3, y3);
                g.DrawLine(bluePen, x3, y3, x2, y2);

                //Objelerden kurtulma.

                redPen.Dispose();
                bluePen.Dispose();
                greenPen.Dispose();
                g.Dispose();
            }
         
        }
        public float[] mainFunc()
        {

            float ko1, ko2, ko3, ko4, ko5, ko6, ko7, ko8;
            ko1 = float.Parse(numericUpDown1.Text).ToString()[0]-48;
            ko2 = float.Parse(numericUpDown2.Text).ToString()[0]-48;
            ko3 = float.Parse(numericUpDown3.Text).ToString()[0] - 48;
            ko4 = float.Parse(numericUpDown4.Text).ToString()[0] - 48;
            ko5 = float.Parse(numericUpDown5.Text).ToString()[0] - 48;
            ko6 = float.Parse(numericUpDown6.Text).ToString()[0] - 48;
            ko7 = float.Parse(numericUpDown7.Text).ToString()[0] - 48;
            ko8 = float.Parse(numericUpDown8.Text).ToString()[0] - 48;
            

            Pair P1 = new Pair(ko1, ko2); //ilk doğru için ilk nokta
            Pair Q1 = new Pair(ko3, ko4); //ilk doğru için ikinci nokta
            Pair P2 = new Pair(ko5, ko6); //ikinci doğru için ilk nokta
            Pair Q2 = new Pair(ko7, ko8); //ikinci doğru için ikinci nokta
            double[] intersection = lineFromPoints(P1, Q1, P2, Q2);
            string nanvarx = Convert.ToString(intersection[0]);
            string nanvary = Convert.ToString(intersection[1]);

            float xaxis = Convert.ToSingle(intersection[0]);
            float yaxis = Convert.ToSingle(intersection[1]);

            lineFromPoints(P1, Q1, P2, Q2);
            //if nan ve sonsuzsa kesişme noktalarını döndürmüyoruz.
            if (nanvarx == "NaN" && nanvary == "NaN" )
            {
                float[] coordinates = { ko1, ko2, ko3, ko4, ko5, ko6, ko7, ko8 };
                return coordinates;
            }
            else if (nanvarx == "-∞" && nanvary == "-∞" || nanvarx == "∞" && nanvary == "∞")
            {
                float[] coordinates = { ko1, ko2, ko3, ko4, ko5, ko6, ko7, ko8 };
                return coordinates;
            }
         
            else
            {
                float[] coordinates = { ko1, ko2, ko3, ko4, ko5, ko6, ko7, ko8,xaxis,yaxis };
                return coordinates;
            }


            
        }
        private void normalizeGraph(float[] degerler)
        {

            float scaleMin = -1;
            float scaleMax = 1;
            var max = 5;
            var min = 0;
            var range = (float)(max - min);
            float scaleRange = scaleMax - scaleMin;
            for (int i = 0; i < degerler.Length; i++)
            {
                degerler[i] = (((scaleRange * (degerler[i] - min)) / range) + scaleMin) * 50;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            foreach (Control item in this.Controls)
            {
                if (item.Name.Contains("label"))
                {
                    item.Text = "";
                     //important step
                }
            }
            foreach (var c in this.Controls)
            {
                if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0;
                }
            }


        }
    }
}

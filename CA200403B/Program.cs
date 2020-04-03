using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200403B
{
    struct Pontszerzo
    {
        public int Helyezes;
        public int SportolokSzama;
        public string Sportag;
        public string Versenyszam;

        public int Pontszam
        {
            get
            {
                int op = 0;
                op += (7 - Helyezes);
                if (Helyezes == 1) op++;
                return op;
            }
        }
    }
    class Program
    {
        static List<Pontszerzo> pontszerzok; 
        static void Main()
        {
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            Console.ReadKey();
        }

        private static void F08()
        {
            int maxi = 0;

            for (int i = 0; i < pontszerzok.Count; i++)
            {
                if (pontszerzok[i].SportolokSzama > pontszerzok[maxi].SportolokSzama)
                    maxi = i;
            }

            Console.WriteLine("8. feladat:");
            Console.WriteLine($"Helyezés: {pontszerzok[maxi].Helyezes}");
            Console.WriteLine($"Sportág: {pontszerzok[maxi].Sportag}");
            Console.WriteLine($"Versenyszám: {pontszerzok[maxi].Versenyszam}");
            Console.WriteLine($"Sportolók száma: {pontszerzok[maxi].SportolokSzama}");
        }


        private static void F07()
        {
            var sw = new StreamWriter(@"..\..\Res\helsinki2.txt", false, Encoding.Default);

            //foreach (var p in pontszerzok)
            //{
            //    sw.WriteLine(
            //        $"{p.Helyezes} {p.SportolokSzama} {p.Pontszam} " +
            //        $"{(p.Sportag == "kajakkenu" ? "kajak-kenu" : p.Sportag)} {p.Versenyszam}");
            //}

            foreach (var p in pontszerzok)
            {
                string sp;
                if (p.Sportag == "kajakenu") sp = "kajak-kenu";
                else sp = p.Sportag;

                int op = 0;
                if (p.Helyezes == 1) op = 7;
                if (p.Helyezes == 2) op = 5;
                if (p.Helyezes == 3) op = 4;
                if (p.Helyezes == 4) op = 3;
                if (p.Helyezes == 5) op = 2;
                if (p.Helyezes == 6) op = 1;

                sw.WriteLine(
                    $"{p.Helyezes} {p.SportolokSzama} {op} " +
                    $"{sp} {p.Versenyszam}");
            }


            sw.Close();
        }

        private static void F06()
        {
            int t = 0;
            int u = 0;

            foreach (var p in pontszerzok)
            {
                if (p.Sportag == "torna") t++;
                else if (p.Sportag == "uszas") u++;
            }

            if (t > u) Console.WriteLine("Torna sportágban szereztek több érmet");
            else if (u > t) Console.WriteLine("Úszás sportágban szereztek több érmet");
            else Console.WriteLine("Egyenlő volt az érmeg száma");
        }

        private static void F05()
        {
            //int sum = 0;
            //foreach (var p in pontszerzok)
            //{
            //    sum += p.Pontszam;
            //}
            //Console.WriteLine("5. feladat:");
            //Console.WriteLine($"olimpiai pontok száma: {sum}");

            //int sum = 0;

            //foreach (var p in pontszerzok)
            //{
            //    sum += (7 - p.Helyezes);
            //    if (p.Helyezes == 1) sum++;
            //}

            //Console.WriteLine("5. feladat:");
            //Console.WriteLine($"olimpiai pontok száma: {sum}");

            int sum = 0;

            foreach (var p in pontszerzok)
            {
                if (p.Helyezes == 1) sum += 7;
                if (p.Helyezes == 2) sum += 5;
                if (p.Helyezes == 3) sum += 4;
                if (p.Helyezes == 4) sum += 3;
                if (p.Helyezes == 5) sum += 2;
                if (p.Helyezes == 6) sum += 1;
            }

            Console.WriteLine("5. feladat:");
            Console.WriteLine($"olimpiai pontok száma: {sum}");

        }

        private static void F04()
        {
            int a = 0;
            int e = 0;
            int b = 0;

            foreach (var p in pontszerzok)
            {
                if (p.Helyezes == 1) a++;
                else if (p.Helyezes == 2) e++;
                else if (p.Helyezes == 3) b++;
            }

            Console.WriteLine("4. feladat:");
            Console.WriteLine($"Arany: {a}");
            Console.WriteLine($"Ezüst: {e}");
            Console.WriteLine($"Bronz: {b}");
        }

        private static void F03()
        {
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Pontszerő helyezések száma: {pontszerzok.Count}");
        }

        private static void F02()
        {
            pontszerzok = new List<Pontszerzo>();

            var sr = new StreamReader(@"..\..\Res\helsinki.txt", Encoding.Default);

            while (!sr.EndOfStream)
            {
                var t = sr.ReadLine().Split(' ');

                pontszerzok.Add(new Pontszerzo() 
                {
                    Helyezes = int.Parse(t[0]),
                    SportolokSzama = int.Parse(t[1]),
                    Sportag = t[2],
                    Versenyszam = t[3],
                });
            }

            sr.Close();

        }
    }
}

using System;

namespace _01Punkt {
    class Punkt {
        public double x = 0, y = 0;

        public void Wypisz() {
            Console.WriteLine($"({x}, {y})");
        }

        public double OdlegloscOdPoczatkuUklad()
        {
            return OdlegloscPomiedzyPunktami(new Punkt() {x = 0, y = 0});
        }

        public double OdlegloscPomiedzyPunktami(Punkt target)
        {
            var xDist = Math.Abs(target.x - x);
            var yDist = Math.Abs(target.y - y);

            return Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }

        public bool CzyTworzyTrojkat(Punkt p1, Punkt p2)
        {
            return Math.Abs((p1.x - x) * (p2.y - y) - (p1.y - y) * (p2.x - x)) != 0;
        }
    }
    class Program {
        static void Main(string[] args) {
            Punkt p1 = new Punkt();
            Punkt p2 = new Punkt();

            p1.x = 3;
            p1.y = 4;
            p2.x = 10;
            p2.y = 20;

            p1.Wypisz();
            p2.Wypisz();

        }
    }
}

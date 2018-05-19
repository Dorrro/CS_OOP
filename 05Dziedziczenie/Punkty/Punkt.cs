using System;

namespace Punkty
{
    public class Punkt
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double OdlegloscDoPunktu(Punkt p)
        {
            return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));
        }
    }

    public class Punkt3D : Punkt
    {
        public double Z { get; set; }

        public double OdlegloscDoPunktu(Punkt3D p)
        {
            return Math.Sqrt(Math.Pow(this.OdlegloscDoPunktu((Punkt) p), 2) + Math.Pow(p.Z - Z, 2));
        }
    }
}

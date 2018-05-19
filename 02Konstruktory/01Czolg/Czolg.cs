using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
    class Samochod : ICloneable
    {
        public Samochod(double longitude, double latitude, string marka, string model, double pojenoscSilnika)
        {
            Lokalizacja = new GeoLocalization { Latitude = latitude, Longitude = longitude };
            Marka = marka;
            Model = model;
            Silnik = new Silnik(pojenoscSilnika);
        }

        public Samochod(GeoLocalization lokalizacja, string marka, string model, double pojenoscSilnika)
        {
            Lokalizacja = lokalizacja;
            Marka = marka;
            Model = model;
            Silnik = new Silnik(pojenoscSilnika);
        }

        public Samochod(GeoLocalization lokalizacja, string marka, string model, Silnik silnik)
        {
            Lokalizacja = lokalizacja;
            Marka = marka;
            Model = model;
            Silnik = silnik;
        }

        public Samochod(GeoLocalization lokalizacja, string marka, string model) : this(lokalizacja,marka,model, new Silnik(1.4))
        { }

        public Samochod(string marka, string model, Silnik silnik) : this(new GeoLocalization { Latitude = 0, Longitude = 0}, marka, model, silnik)
        { }

        public Samochod(string marka, string model) : this(marka, model, new Silnik(1.4))
        { }

        public GeoLocalization Lokalizacja { get; }

        public string Marka { get; }

        public string Model { get; }

        public Silnik Silnik { get; }

        public object Clone()
        {
            return new Samochod((GeoLocalization) Lokalizacja.Clone(), Marka, Model, (Silnik) Silnik.Clone());
        }
    }

    internal class Silnik : ICloneable
    {
        public double Pojemnosc { get; private set; }

        public Silnik(double pojemnosc)
        {
            Pojemnosc = pojemnosc;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    internal struct GeoLocalization : ICloneable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    class Czolg {
        private int numerCzolgu;
        private string nazwa;
        private Dzialo dzialo;
        private Punkt pozycja;

        public Czolg(int nrCzolgu, string nazwa, double kaliber, int pozycjaX, int pozycjaY) {
            numerCzolgu = nrCzolgu;
            this.nazwa = nazwa;
            dzialo = new Dzialo(kaliber);
            pozycja = new Punkt(pozycjaX, pozycjaY);
        }

        public Czolg(int nrCzolgu, string nazwa, Dzialo dzialo, Punkt punkt)
            : this(nrCzolgu, nazwa, dzialo.PobierzKaliber(), punkt.PobierzX(), punkt.PobierzY()) {
        }

        public Czolg(int nrCzolgu, string nazwa, double kaliber)
            : this(nrCzolgu, nazwa, kaliber, 0, 0) {
        }

        public Czolg(int nrCzolgu, string nazwa)
            : this(nrCzolgu, nazwa, 76.2) {
        }
        public Czolg(int nrCzolgu)
            : this(nrCzolgu, "Rudy") {
        }
        public Czolg()
            : this(102) {
        }

        public string PobierzInformacje() {
            return string.Format("Czołg\n nr:   {0}\n o nazwie: {1}\n kaliber działa: {2}\n znajduje się w punkcie: ({3}; {4})\n",
                numerCzolgu, nazwa, dzialo.PobierzKaliber(), pozycja.PobierzX(), pozycja.PobierzY());
        }

        #region Zadanie 2
        public void ZmienKaliber(double nowyKaliber) {
            dzialo.ZmienKaliber(nowyKaliber);
        }
        public void ZmienPozycje(int x, int y) {
            pozycja.ZmienX(x);
            pozycja.ZmienY(y);
        }
        public void ZmienNazwe(string nowaNazwa) {
            nazwa = nowaNazwa;
        }
        public Czolg Klonuj() {
            return (Czolg)MemberwiseClone();
        }
        public Czolg(Czolg prototyp) {
            numerCzolgu = prototyp.numerCzolgu;
            nazwa = prototyp.nazwa;
            dzialo = new Dzialo(prototyp.dzialo);
            pozycja = prototyp.pozycja;
        }
        #endregion

    }
}

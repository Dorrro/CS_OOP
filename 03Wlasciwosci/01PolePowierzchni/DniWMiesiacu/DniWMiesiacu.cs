using System;

namespace DniWMiesiacu
{
    public class DniWMiesiacu
    {
        private readonly int[] _iloscDni = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        private readonly string[] _nazwyMiesiecy = {
            "styczen", "luty", "marzec", "kwiecien", "maj", "lipiec", "sierpien", "wrzesien", "pazdziernik", "listopad",
            "grudzien"
        };

        public int this[string nazwaMiesiaca]
        {
            get
            {
                var index = Array.IndexOf(_nazwyMiesiecy, nazwaMiesiaca);
                return _iloscDni[index];
            }
            set
            {
                this[nazwaMiesiaca] = value;
            }
        }
    }
}

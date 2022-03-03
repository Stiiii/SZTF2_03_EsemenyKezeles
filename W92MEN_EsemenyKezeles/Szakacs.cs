using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W92MEN_EsemenyKezeles
{
    class Szakacs
    {
        public string nev { get; }

        public string specialitas;

        public Szakacs(string nev, string specialitas)
        {
            this.nev = nev;
            this.specialitas = specialitas;
        }

        public event Program.HozzavaloElkeszultKezelo HozzavaloElkeszult;

        public void SefKerValamit(string hozzavalo)
        {
            if (hozzavalo == specialitas)
            {
                Foz(hozzavalo);
            }
        }

        public virtual void Foz(string hozzavalo)
        {
            Console.WriteLine(this.nev + " főz '" + specialitas + "'-et");
            HozzavaloElkeszult(hozzavalo);
        }

    }
}

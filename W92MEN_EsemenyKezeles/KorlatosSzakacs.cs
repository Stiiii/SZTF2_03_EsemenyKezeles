using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W92MEN_EsemenyKezeles
{
    internal class KorlatosSzakacs : Szakacs
    {
        int mennyiseg;

        public event Program.HozzavaloElkeszultKezelo HozzavaloNemKeszithetoEl;


        public KorlatosSzakacs(string nev, string specialitas, int mennyiseg) : base(nev, specialitas)
        {
            this.mennyiseg = mennyiseg;
        }

        public override void Foz(string hozzavalo)
        {
            if (mennyiseg > 0)
            {
                base.Foz(hozzavalo);
            }
            else
            {
                HozzavaloNemKeszithetoEl(specialitas);
            }
            mennyiseg--;
        }
    }
}

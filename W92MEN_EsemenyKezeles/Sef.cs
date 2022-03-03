using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W92MEN_EsemenyKezeles
{
    class Sef
    {
        private Etel cel;
        private int szuksegesHozzavaloSzam;

        Etel[] receptek = new Etel[]
        {
            new Etel("poharviz", new string[] { "viz" } ),
            new Etel("leves", new string[] { "repa", "hus", "krumpli", "viz" } ),
            new Etel("rantothus", new string[] { "hus", "krumpli" } ),
            new Etel("fozelek", new string[] { "viz", "repa" } )
        };

        public event Program.RendelesTeljesitesKezelo RendelesTeljesitve;

        public event Program.RendelesTeljesitesKezelo RendelesNemTeljesitheto;

        public event Program.HozzavaloSzuksegesKezelo HozzavaloSzukseges;

        public void Megrendeles(string etelNeve)
        {
            int i = 0;
            Console.WriteLine("Séf: Rendelés beérkezett '" + etelNeve+"'");

            while (i < receptek.Length && receptek[i].megnevezes != etelNeve)
            {
                i++;
            }
            if (i == receptek.Length)
            {
                RendelesNemTeljesitheto(etelNeve);
            }
            else
            {
                Elkeszites(receptek[i]);
            }
        }
        public void Elkeszites(Etel recept)
        {
            cel = recept;
            szuksegesHozzavaloSzam = recept.hozzavalok.Length;
            for (int i = 0; i < cel.hozzavalok.Length; i++)
            {
                HozzavaloSzukseges(recept.hozzavalok[i]);
            }

        }
        public void SzakacsElkeszult(string hozzavalo)
        {
            szuksegesHozzavaloSzam--;
            if (szuksegesHozzavaloSzam == 0)
            {
                RendelesTeljesitve(cel.megnevezes);
            }
        }

        public void Felvesz(Szakacs szakacs)
        {
            HozzavaloSzukseges += szakacs.SefKerValamit;
            szakacs.HozzavaloElkeszult += SzakacsElkeszult;
            if (szakacs is KorlatosSzakacs)
            {
                (szakacs as KorlatosSzakacs).HozzavaloNemKeszithetoEl += SzakacsHibatJelez;
            }
        }

        public void SzakacsHibatJelez(string hozzavalo)
        {
            Console.WriteLine("Séf: Szakács hibát jelzett '" + hozzavalo + "'");
            RendelesNemTeljesitheto(cel.megnevezes);
            
        }

    }
}

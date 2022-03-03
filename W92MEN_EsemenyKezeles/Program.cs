using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W92MEN_EsemenyKezeles
{
    class Program
    {
        static void SikerHozzavalo(string hozzavalo)
        {
            Console.WriteLine("Séf: Elkészült a '" + hozzavalo+"'");
        }
        static void Siker(string etelNeve)
        {
            Console.WriteLine("* Sikeres rendelés '" + etelNeve+"'");
        }
        static void Sikertelen(string etelNeve)
        {
            Console.WriteLine("* Sikertelen rendelés '" + etelNeve+"'");
        }

        public delegate void RendelesTeljesitesKezelo(string etelNeve);

        public delegate void HozzavaloSzuksegesKezelo(string hozzavalo);

        public delegate void HozzavaloElkeszultKezelo(string hozzavalo);

        static void Main(string[] args)
        {
            Sef sef = new Sef();
            Szakacs szakacs = new Szakacs("Bela", "viz");
            KorlatosSzakacs KorlatosSzakacs = new KorlatosSzakacs("Robert", "repa", 2);

            sef.RendelesTeljesitve += Siker;
            sef.RendelesNemTeljesitheto += Sikertelen;
            szakacs.HozzavaloElkeszult += SikerHozzavalo;
            KorlatosSzakacs.HozzavaloElkeszult += SikerHozzavalo;

            sef.Felvesz(szakacs);
            sef.Felvesz(KorlatosSzakacs);
            sef.Megrendeles("poharviz");
            sef.Megrendeles("Kecskesajt");
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            


            Console.ReadKey();
        }


    }
}

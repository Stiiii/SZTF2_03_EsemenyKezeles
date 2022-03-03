using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W92MEN_EsemenyKezeles
{
    class Etel
    {
        public Etel(string megnevezes, string[] hozzavalok)
        {
            this.megnevezes = megnevezes;
            this.hozzavalok = hozzavalok;
        }

        public string megnevezes { get; }
        public string[] hozzavalok { get; }

    }
}

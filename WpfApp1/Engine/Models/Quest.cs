using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public List<ItemQuantity> PotrzebnaIlość { get; set; }

        public int DoświadczenieDoZdobycia { get; set; }
        public int ZłotoDoZdobycia { get; set; }
        public List<ItemQuantity> Nagroda { get; set; }

        public Quest(int id, string nazwa, string opis, List<ItemQuantity> potrzebnaIlość,
                     int doświadczenieDoZdobycia, int złotoDoZdobycia, List<ItemQuantity> nagroda)
        {
            ID = id;
            Nazwa = nazwa;
            Opis = opis;
            PotrzebnaIlość = potrzebnaIlość;
            DoświadczenieDoZdobycia = doświadczenieDoZdobycia;
            ZłotoDoZdobycia = złotoDoZdobycia;
            Nagroda = nagroda;
        }
    }
}
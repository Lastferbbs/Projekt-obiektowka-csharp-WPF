using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public int IdItemka { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public GameItem(int idPrzedmiotu, string nazwa, int cena)
        {
            IdItemka = idPrzedmiotu;
            Nazwa = nazwa;
            Cena = cena;
        }

        public GameItem Clone()
        {
            return new GameItem(IdItemka, Nazwa, Cena);
        }
    }
}

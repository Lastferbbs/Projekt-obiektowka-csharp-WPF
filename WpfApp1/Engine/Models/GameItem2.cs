using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public int IdPrzedmiotu { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public GameItem(int idPrzedmiotu, string nazwa, int cena)
        {
            IdPrzedmiotu = idPrzedmiotu;
            Nazwa = nazwa;
            Cena = cena;
        }

        public GameItem Clone()
        {
            return new GameItem(IdPrzedmiotu, Nazwa, Cena);
        }
    }
}

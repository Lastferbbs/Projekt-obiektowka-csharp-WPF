using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int idPrzedmiotu, string nazwa, int cena, int minDamage, int maxDamage)
            : base(idPrzedmiotu, nazwa, cena)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        public new Weapon Clone()
        {
            return new Weapon(IdPrzedmiotu, Nazwa, Cena, MinimumDamage, MaximumDamage);
        }
    }
}

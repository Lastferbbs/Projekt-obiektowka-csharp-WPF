using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : notificationclass
    {
        private int _obrazenia;

        public string Nazwa { get; private set; }
        public string ImageName { get; set; }
        public int MaxObrazenia { get; private set; }
        public int Obrazenia
        {
            get { return _obrazenia; }
            private set
            {
                _obrazenia = value;
                OnPropertyChanged(nameof(Obrazenia));
            }
        }

        public int PunktyXp { get; private set; }
        public int ZlotoDoZdobycia { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string nazwa, string imageName,
            int maxobrazenia, int obrazenia,
            int punktyxp, int zlotodozdobycia)
        {
            Nazwa = nazwa;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            MaxObrazenia = maxobrazenia;
            Obrazenia = obrazenia;
            PunktyXp = punktyxp;
            ZlotoDoZdobycia = zlotodozdobycia;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}

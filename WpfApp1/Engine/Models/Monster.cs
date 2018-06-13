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
        public int MaxPunktyZycia { get; private set; }
        public int PunktyZycia
        {
            get { return _obrazenia; }
            private set
            {
                _obrazenia = value;
                OnPropertyChanged(nameof(PunktyZycia));
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
            ImageName = string.Format("/Engine;component/Obrazy/Stworki/{0}", imageName);
            MaxPunktyZycia = maxobrazenia;
            PunktyZycia = obrazenia;
            PunktyXp = punktyxp;
            ZlotoDoZdobycia = zlotodozdobycia;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}

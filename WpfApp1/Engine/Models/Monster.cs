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
            set
            {
                _obrazenia = value;
                OnPropertyChanged(nameof(PunktyZycia));
            }
        }

        public int PunktyXp { get; private set; }
        public int ZlotoDoZdobycia { get; private set; }

        public int MinObrazenia { get; set; }
        public int MaxObrazenia { get; set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string nazwa, string imageName,
            int maxpunktyzycia, int punktyzycia,
            int punktyxp, int zlotodozdobycia,
            int minObrazenia, int maxobrazenia)
        {
            Nazwa = nazwa;
            ImageName = string.Format("/Engine;component/Obrazy/Stworki/{0}", imageName);
            MaxPunktyZycia = maxpunktyzycia;
            PunktyZycia = punktyzycia;
            PunktyXp = punktyxp;
            ZlotoDoZdobycia = zlotodozdobycia;
            MaxObrazenia = maxobrazenia;
            MinObrazenia = minObrazenia;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}

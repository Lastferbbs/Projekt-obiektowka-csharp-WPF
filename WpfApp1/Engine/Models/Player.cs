using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Engine.Models
{
    public class Player : notificationclass
    {
        private string _Imię;
        private string _KlasaPostaci;
        private int _PunktyZycia;
        private int _PunktyDoswiadczenia;
        private int _Poziom;
        private int _Złoto;

        public string Imię
        {
            get { return _Imię; }
            set
            {
                _Imię = value;
                OnPropertyChanged(nameof(Imię));
            }
        }
        public string KlasaPostaci
        {
            get { return _KlasaPostaci; }
            set
            {
                _KlasaPostaci = value;
                OnPropertyChanged(nameof(KlasaPostaci));
            }
        }
        public int PunktyZycia
        {
            get { return _PunktyZycia; }
            set
            {
                _PunktyZycia = value;
                OnPropertyChanged(nameof(PunktyZycia));
            }
        }
        public int PunktyDoswiadczenia
        {
            get { return _PunktyDoswiadczenia; }
            set
            {
                _PunktyDoswiadczenia = value;
                OnPropertyChanged(nameof(PunktyDoswiadczenia));
            }
        }
        public int Poziom
        {
            get { return _Poziom; }
            set
            {
                _Poziom = value;
                OnPropertyChanged(nameof(Poziom));
            }
        }
        public int Złoto
        {
            get { return _Złoto; }
            set
            {
                _Złoto = value;
                OnPropertyChanged(nameof(Złoto));
            }
        }

    public ObservableCollection<GameItem> Inwentarz { get; set; }

        public List<GameItem> Weapons =>
            Inwentarz.Where(i => i is Weapon).ToList();

        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Inwentarz = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();

        }

        public void AddItemToInventory(GameItem item)
        {
            Inwentarz.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inwentarz.Remove(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if (Inwentarz.Count(i => i.IdItemka == item.IdPrzedmiotu) < item.Ilość)
                {
                    return false;
                }
            }

            return true;
        }

    }
}

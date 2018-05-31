using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : INotifyPropertyChanged
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
                OnPropertyChanged("Imię");
            }
        }
        public string KlasaPostaci
        {
            get { return _KlasaPostaci; }
            set
            {
                _KlasaPostaci = value;
                OnPropertyChanged("KlasaPostaci");
            }
        }
        public int PunktyZycia
        {
            get { return _PunktyZycia; }
            set
            {
                _PunktyZycia = value;
                OnPropertyChanged("PunktyZycia");
            }
        }
        public int PunktyDoswiadczenia
        {
            get { return _PunktyDoswiadczenia; }
            set
            {
                _PunktyDoswiadczenia = value;
                OnPropertyChanged("PunktyDoswiadczenia");
            }
        }
        public int Poziom
        {
            get { return _Poziom; }
            set
            {
                _Poziom = value;
                OnPropertyChanged("Poziom");
            }
        }
        public  int Złoto
        {
            get { return _Złoto; }
            set
            {
                _Złoto = value;
                OnPropertyChanged("Złoto");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

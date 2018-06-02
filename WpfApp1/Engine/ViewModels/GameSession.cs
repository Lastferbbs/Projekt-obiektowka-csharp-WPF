﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : notificationclass
    {
        private Location _currentLocation;
        public Player CurrentPlayer { get; set; }
        public World CurrentWorld { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(Czyjestdroganapolnoc));
                OnPropertyChanged(nameof(Czyjestdroganawschod));
                OnPropertyChanged(nameof(Czyjestdroganazachod));
                OnPropertyChanged(nameof(Czyjestdroganapoludnie));
            }
        }

        public bool Czyjestdroganapolnoc
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            }
        }

        public bool Czyjestdroganazachod
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool Czyjestdroganawschod
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool Czyjestdroganapoludnie
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }


        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Imię = "Kuba",
                KlasaPostaci = "Wojownik",
                PunktyZycia = 10,
                PunktyDoswiadczenia = 0,
                Złoto = 1000000,
                Poziom = 1
            };




            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

           
        }

        public void IdzNaPolnoc()
        {
            if (Czyjestdroganapolnoc)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }
        public void IdzNaZachod()
        {
            if(Czyjestdroganazachod)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }

        public void IdzNaWschod()
        {
            if(Czyjestdroganawschod)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }
        public void IdzNaPoludnie()
        {
            if(Czyjestdroganapoludnie)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        
    }
}

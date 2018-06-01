using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Imię = "Kuba";
            CurrentPlayer.KlasaPostaci = "Wojownik";
            CurrentPlayer.Złoto = 1000000;
            CurrentPlayer.PunktyZycia = 10;
            CurrentPlayer.PunktyDoswiadczenia = 0;
            CurrentPlayer.Poziom = 1;

         
            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

           
        }

        public void IdzNaPolnoc ()
        {

        }

        public void IdzNaZachod()
        {

        }

        public void IdzNaWschod()
        {

        }

        public void IdzNaPoludnie()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Imię = "Kuba";
            CurrentPlayer.KlasaPostaci = "Wojownik";
            CurrentPlayer.Złoto = 1000000;
            CurrentPlayer.PunktyZycia = 10;
            CurrentPlayer.PunktyDoswiadczenia = 0;
            CurrentPlayer.Poziom = 1;

            CurrentLocation = new Location();
            CurrentLocation.XCoordinate = 0;
            CurrentLocation.YCoordinate = -1;
            CurrentLocation.Nazwa = "Twój dom";
            CurrentLocation.Opis = "Tutaj mieszkasz";
            CurrentLocation.ImageName = "/Engine;component/Obrazy/Lokacje/Dom.png";



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void AddLocation(int XCoordinate, int YCoordinate, string Nazwa, string Opis, string ImageName)
        {
            Location loc = new Location();
            loc.XCoordinate = XCoordinate;
            loc.YCoordinate = YCoordinate;
            loc.Nazwa = Nazwa;
            loc.Opis = Opis;
            loc.ImageName = ImageName;

            _locations.Add(loc);

        }

        public Location LocationAt(int XCoordinate, int YCoordinate)
        {
            foreach (Location loc in _locations)
            {
                if (loc.XCoordinate == XCoordinate && loc.YCoordinate == YCoordinate)
                {
                    return loc;
                }

            }

            return null;
        }

    }
}

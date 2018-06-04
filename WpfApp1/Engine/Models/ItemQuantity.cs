using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public int IdPrzedmiotu { get; set; }
        public int Ilość { get; set; }
        //public int PotrzebnaIlość { get; set; }
        //public int Nagroda { get; set; }

        public ItemQuantity(int idPrzedmiotu, int ilość )
        {
            IdPrzedmiotu = idPrzedmiotu;
            Ilość = ilość;
            //Nagroda = nagroda;
           // PotrzebnaIlość = potrzebnaIlość;


        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Zaostrzony kijek", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Zardzewiały miecz", 5, 2, 3));
            _standardGameItems.Add(new GameItem(9002, "Oko węża", 2));
            _standardGameItems.Add(new GameItem(9003, "Skóra węża", 2));
            _standardGameItems.Add(new GameItem(9004, "Szczurzy ogon", 3));
        }

        public static GameItem CreateGameItem(int idPrzedmiotu)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.IdPrzedmiotu == idPrzedmiotu);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }
    }
}
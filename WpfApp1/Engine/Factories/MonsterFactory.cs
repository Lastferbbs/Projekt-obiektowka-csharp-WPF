using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster waz =
                        new Monster("Wąż", "Wąż.png", 4, 4, 5, 1, 1, 2);

                    AddLootItem(waz, 9001, 25);
                    AddLootItem(waz, 9002, 75);

                    return waz;

                case 2:
                    Monster szczur =
                        new Monster("Szczur", "Szczur.png", 5, 5, 5, 1, 1, 2);

                    AddLootItem(szczur, 9003, 25);
                    AddLootItem(szczur, 9004, 75);

                    return szczur;

                case 3:
                    Monster wielkiPajak =
                        new Monster("Wielki Pająk", "WielkiPająk.png", 10, 10, 10, 3, 2, 5);

                    AddLootItem(wielkiPajak, 9005, 25);
                    AddLootItem(wielkiPajak, 9006, 75);

                    return wielkiPajak;

                default:
                    throw new ArgumentException(string.Format("Taki potwór '{0}' nie istnieje", monsterID));
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
 
namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items need to complete the quest, and its reward items
            List<ItemQuantity> potrzebnaIlość = new List<ItemQuantity>();
            List<ItemQuantity> nagroda = new List<ItemQuantity>();

            potrzebnaIlość.Add(new ItemQuantity(9001, 5));
            nagroda.Add(new ItemQuantity(1002, 1));

            // Create the quest
            _quests.Add(new Quest(1,
                                  "Oczyść mój ogród",
                                  "Pokonaj węże w ogrodzie zielarki",
                                  potrzebnaIlość,
                                  25, 10,
                                  nagroda));
            _quests.Add(new Quest(2,
                                    "Oczyść pole farmera",
                                    "Pokonaj szczury, które podjadają moją pszenicę!",
                                    new List<ItemQuantity> { new ItemQuantity(9004, 5) },
                                    20, 10,
                                    new List<ItemQuantity> { new ItemQuantity(1002, 1) }));
        }

        internal static Quest GetQuestByID(int id)
        {
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
   internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Pole Farmera",
                "Gdzieś wśród tych rzędów kukurydzy, chowa się wielki szczur!",
                "/engine;component/Obrazy/Lokacje/PoleFarmera.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Dom farmerski",
                "Wokół pasą się krówki, a kogut przymierza się do dziobnięcia Cię w stopę.",
                "/engine;component/Obrazy/Lokacje/Domfarmerski.png");

            newWorld.AddLocation(0, -1, "Dom",
                "To twój dom!",
                "/Engine;component/Obrazy/Lokacje/Dom.png");

            newWorld.AddLocation(-1, 0, "Sklep z różnościami",
                "Sklep z prawie 200 letnią historią, aktualnie prowadzony przez panią Elę.",
                "/Engine;component/Obrazy/Lokacje/Sklep.png");

            newWorld.AddLocation(0, 0, "Plac",
                "Wrzuć pieniążka do fontanny, a wszystkie twoje życzenia się spełnią.",
                "/Engine;component/Obrazy/Lokacje/Plac.png");

            newWorld.AddLocation(1, 0, "Brama do miasta",
                "Bez tej bramy, mieszkancy dawno zostaliby pożarci przez Wielkie Pająki.",
                "/Engine;component/Obrazy/Lokacje/Brama.png");

            newWorld.AddLocation(2, 0, "Pajęczy las",
                "Wszystkie rośliny pokrytę są pajęczyną...",
                "/Engine;component/Obrazy/Lokacje/Pajeczylas.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Domek zielarki",
                "Już z kilometra czuć intensywny zapach roślin, na ganku zapach jest nie do wytrzymania!.",
                "/Engine;component/Obrazy/Lokacje/Domekzielarki.png");

            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(2));

            newWorld.AddLocation(0, 2, "Ogród zielarki",
                "Tu też woń kwiatów przyprawia o zawrót głowy, jedynie węże wydają się być odporne.",
                "/Engine;component/Obrazy/Lokacje/ogrodzielarki.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
               

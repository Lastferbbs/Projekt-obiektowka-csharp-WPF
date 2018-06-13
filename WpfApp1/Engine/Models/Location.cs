using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string ImageName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; set; } =
           new List<MonsterEncounter>();

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                // Stworek już został dodany do tej lokacji
                // Więc nadpisz ChanceOfEncountering nową liczbą
                MonstersHere.First(m => m.MonsterID == monsterID)
                            .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                // Nie ma tu takiego stworka, więc go dodaje.
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            // Suma szans na spotkanie stworka w tej lokacji
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Wybierz losowy numer, pod warunkiem, że szansa nie równa się 100%
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            // Kiedy losowy numer jest mniejszy lub równy od runningTotal, który rośnie po każdej pętli
            // to zwróc takiego stworka
            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // Jeśli pojawi się problem, zwróć ostatniego stworka z listy
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}

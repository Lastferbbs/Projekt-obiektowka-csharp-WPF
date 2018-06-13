using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : notificationclass
    {

        public event EventHandler<WiadomosciEventArgs> OnMessageRaised;

        #region Properties

        private Location _currentLocation;
        private Monster _currentMonster;

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

                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
                CompleteQuestsAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"Zbliza się do Ciebie {CurrentMonster.Nazwa}!");
                }
            }

        }

        public Weapon CurrentWeapon { get; set; }
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

        public bool HasMonster => CurrentMonster != null;

        #endregion
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

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }


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

        private void CompleteQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                QuestStatus questToComplete =
                    CurrentPlayer.Quests.FirstOrDefault(q => q.PlayerQuest.ID == quest.ID &&
                                                             !q.IsCompleted);

                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasAllTheseItems(quest.PotrzebnaIlość))
                    {
                        // Zabierz itemy do questa z plecaka gracza
                        foreach (ItemQuantity itemQuantity in quest.PotrzebnaIlość)
                        {
                            for (int i = 0; i < itemQuantity.Ilość; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inwentarz.First(item => item.IdItemka == itemQuantity.IdPrzedmiotu));
                            }
                        }

                        RaiseMessage("");
                        RaiseMessage($"'{quest.Nazwa}' - to zadanie zostało ukończone");

                        // Przydziel nagrodę
                        CurrentPlayer.PunktyDoswiadczenia += quest.DoświadczenieDoZdobycia;
                        RaiseMessage($" {quest.DoświadczenieDoZdobycia} - otrzymane punkty doświadczenia");

                        CurrentPlayer.Złoto += quest.ZłotoDoZdobycia;
                        RaiseMessage($"{quest.ZłotoDoZdobycia} otrzymane złoto");

                        foreach (ItemQuantity itemQuantity in quest.Nagroda)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.IdPrzedmiotu);

                            CurrentPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"{rewardItem.Nazwa} - zdobyto nowy przedmiot");
                        }

                        // Oznacz zadanie jako ukonczone
                        questToComplete.IsCompleted = true;
                    }
                }
            }
        }

        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));

                    RaiseMessage("");
                    RaiseMessage($"'{quest.Nazwa}' - otrzymano nowe zadanie!");
                    RaiseMessage(quest.Opis);

                    RaiseMessage("Wróc z:");
                    foreach (ItemQuantity itemQuantity in quest.PotrzebnaIlość)
                    {
                        RaiseMessage($"   {itemQuantity.Ilość}x{ItemFactory.CreateGameItem(itemQuantity.IdPrzedmiotu).Nazwa}");
                    }

                    RaiseMessage("A otrzymasz:");
                    RaiseMessage($"   {quest.DoświadczenieDoZdobycia} - punkty doświadczzenia");
                    RaiseMessage($"   {quest.ZłotoDoZdobycia} - złoto");
                    foreach (ItemQuantity itemQuantity in quest.Nagroda)
                    {
                        RaiseMessage($"   {itemQuantity.Ilość}x{ItemFactory.CreateGameItem(itemQuantity.IdPrzedmiotu).Nazwa}");
                    }
                }
            }
        }


        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();

       
        }

        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("Najpierw wybierz broń.");
                return;
            }

            // Determinuje obrazenia, ktore zadaje postać
            int damageToMonster = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            if (damageToMonster == 0)
            {
                RaiseMessage($"{CurrentMonster.Nazwa} zrobił unik!");
            }
            else
            {
                CurrentMonster.PunktyZycia -= damageToMonster;
                RaiseMessage($"{CurrentMonster.Nazwa} dostał za {damageToMonster}");
            }

            // Jeśli stworek zginie, zbierz loot
            if (CurrentMonster.PunktyZycia <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"{CurrentMonster.Nazwa} został pokonany!");

                CurrentPlayer.PunktyDoswiadczenia += CurrentMonster.PunktyXp;
                RaiseMessage($"{CurrentMonster.PunktyXp} - zdobyte doświadczenie.");

                CurrentPlayer.Złoto += CurrentMonster.ZlotoDoZdobycia;
                RaiseMessage($"{CurrentMonster.ZlotoDoZdobycia} - zdobyte złoto.");

                foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.IdPrzedmiotu);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMessage($"{itemQuantity.Ilość}x{item.Nazwa} - nowy przedmiot");
                }

                // Nowy stworek do walki
                GetMonsterAtLocation();
            }
            else
            {
                // Jeśli stworek żyje, on atakuje
                int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinObrazenia, CurrentMonster.MaxObrazenia);

                if (damageToPlayer == 0)
                {
                    RaiseMessage("Udalo Ci się uniknąc obrażeń");
                }
                else
                {
                    CurrentPlayer.PunktyZycia -= damageToPlayer;
                    RaiseMessage($"{CurrentMonster.Nazwa} zadał Ci {damageToPlayer} puntków obrażeń.");
                }

                // Gdy gracz zginie, przenieś go do domu i uzdrów
                if (CurrentPlayer.PunktyZycia <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"Zostałeś pokonany, lecz twoja mama Cię wskrzesiła");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1); // Dom
                    CurrentPlayer.PunktyZycia = CurrentPlayer.Poziom * 10; // Wylecz gracza
                }
            }
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new WiadomosciEventArgs(message));
        }
    }
}
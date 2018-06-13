using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine.ViewModels;

namespace TestEngine.ViewModels
{
    [TestClass]
    public class TestGameSession
    {
        [TestMethod]
        public void TestNowejSesji()
        {
            GameSession gameSession = new GameSession();

            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Plac", gameSession.CurrentLocation.Nazwa);
        }

        [TestMethod]
        public void TestStatystykgraczaprzyzaczęciugry()
        {
            GameSession gameSession = new GameSession();

            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Wojownik", gameSession.CurrentPlayer.KlasaPostaci);
            Assert.AreEqual("Kuba", gameSession.CurrentPlayer.Imię);
            Assert.AreEqual(10, gameSession.CurrentPlayer.PunktyZycia);
            Assert.AreEqual(0, gameSession.CurrentPlayer.PunktyDoswiadczenia);
            Assert.AreEqual(1000, gameSession.CurrentPlayer.Złoto);
            Assert.AreEqual(1, gameSession.CurrentPlayer.Poziom);


      

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MensErgerJeNietLogic;

namespace MensErgerJeNietLogic.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestPlayerInitialization()
        {
            // Arrange
            var game = new DontGetAngry();
            var playerName = "TestPlayer";
            var playerId = 0;

            // Act
            var player = new Player(playerName, playerId, game);

            // Assert
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerId, player.ID);
            Assert.AreEqual(4, player.Hand.Count);
        }

        [TestMethod]
        public void TestPlayerCanRoll()
        {
            // Arrange
            var game = new DontGetAngry();
            var playerName = "TestPlayer";
            var playerId = 0;
            var player = new Player(playerName, playerId, game);

            // Act
            player.CanRoll = true;

            // Assert
            Assert.IsTrue(player.CanRoll);
        }

        [TestMethod]
        public void TestPlayerIsUp()
        {
            // Arrange
            var game = new DontGetAngry();
            var playerName = "TestPlayer";
            var playerId = 0;
            var player = new Player(playerName, playerId, game);

            // Act
            player.IsUp = true;

            // Assert
            Assert.IsTrue(player.IsUp);
        }
    }
}

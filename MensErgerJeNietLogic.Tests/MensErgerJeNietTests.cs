using Microsoft.VisualStudio.TestTools.UnitTesting;
using MensErgerJeNietLogic;
using System;

namespace MensErgerJeNietLogic.Tests
{
    [TestClass]
    public class DontGetAngryTests
    {
        [TestMethod]
        public void TestAddNewPlayer()
        {
            // Arrange
            var game = new DontGetAngry();

            // Act
            var player = game.AddNewPlayer("Player1");

            // Assert
            Assert.AreEqual("Player1", player.Name);
            Assert.AreEqual(0, player.ID);
            Assert.AreEqual(4, player.Hand.Count);
        }

        [TestMethod]
        public void TestRollDice()
        {
            // Arrange
            var game = new DontGetAngry();
            game.AddNewPlayer("Player1");
            game.StartGame();

            // Act
            var result = game.RollDice();

            // Assert
            Assert.IsTrue(result >= 1 && result <= 6);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRollDiceWithoutStartingGame()
        {
            // Arrange
            var game = new DontGetAngry();
            game.AddNewPlayer("Player1");

            // Act
            game.RollDice();
        }

        [TestMethod]
        public void TestActionWithPawn()
        {
            // Arrange
            var game = new DontGetAngry();
            var player = game.AddNewPlayer("Player1");
            game.StartGame();
            game.RollDice();
            var pawn = player.Hand[0];
            pawn.IsMovable = true;

            // Act
            game.ActionWithPawn(pawn);

            // Assert
            Assert.AreEqual(10 * player.ID, pawn.Location);
        }

        [TestMethod]
        public void TestStartGame()
        {
            // Arrange
            var game = new DontGetAngry();
            game.AddNewPlayer("Player1");

            // Act
            game.StartGame();

            // Assert
            Assert.IsTrue(game.CurrentPlayer.CanRoll);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddNewPlayerAfterGameStarted()
        {
            // Arrange
            var game = new DontGetAngry();
            game.AddNewPlayer("Player1");
            game.StartGame();

            // Act
            game.AddNewPlayer("Player2");
        }
    }
}

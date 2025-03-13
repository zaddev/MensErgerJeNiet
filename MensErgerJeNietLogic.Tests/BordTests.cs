using Microsoft.VisualStudio.TestTools.UnitTesting;
using MensErgerJeNietLogic;

namespace MensErgerJeNietLogic.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestAddPawns()
        {
            // Arrange
            var game = new DontGetAngry();
            var player = game.AddNewPlayer("Player1");
            var board = new Board(game);

            // Act
            board.AddPawns(player);

            // Assert
            foreach (var pawn in player.Hand)
            {
                Assert.AreEqual((FieldStatus)pawn.Color, board.Fields[pawn.Location]);
            }
        }

        [TestMethod]
        public void TestChangeStatus()
        {
            // Arrange
            var game = new DontGetAngry();
            var board = new Board(game);

            // Act
            board.ChangeStatus(0, FieldStatus.red);

            // Assert
            Assert.AreEqual(FieldStatus.red, board.Fields[0]);
        }

        [TestMethod]
        public void TestPawnMoved()
        {
            // Arrange
            var game = new DontGetAngry();
            var player = game.AddNewPlayer("Player1");
            var board = new Board(game);
            board.AddPawns(player);
            var pawn = player.Hand[0];
            var initialLocation = pawn.Location;

            // Act
            pawn.Move(1);

            // Assert
            Assert.AreEqual(FieldStatus.free, board.Fields[initialLocation]);
            Assert.AreEqual((FieldStatus)pawn.Color, board.Fields[pawn.Location]);
        }
    }
}

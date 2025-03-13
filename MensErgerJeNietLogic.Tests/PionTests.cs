using MensErgerJeNietLogic;
using Xunit;

namespace MensErgerJeNietLogic.Tests
{
    public class PionTests
    {
        [Fact]
        public void TestPionInitialization()
        {
            // Arrange
            var player = new Speler("Player1", Kleur.Rood);
            var pion = new Pion(player);

            // Act & Assert
            Assert.Equal(player, pion.Speler);
            Assert.Equal(0, pion.Positie);
            Assert.False(pion.IsInStartpositie);
            Assert.False(pion.IsInEindpositie);
        }

        [Fact]
        public void TestPionMove()
        {
            // Arrange
            var player = new Speler("Player1", Kleur.Rood);
            var pion = new Pion(player);

            // Act
            pion.Verplaats(5);

            // Assert
            Assert.Equal(5, pion.Positie);
        }

        [Fact]
        public void TestPionMoveToStart()
        {
            // Arrange
            var player = new Speler("Player1", Kleur.Rood);
            var pion = new Pion(player);

            // Act
            pion.ZetInStartpositie();

            // Assert
            Assert.True(pion.IsInStartpositie);
            Assert.Equal(0, pion.Positie);
        }

        [Fact]
        public void TestPionMoveToEnd()
        {
            // Arrange
            var player = new Speler("Player1", Kleur.Rood);
            var pion = new Pion(player);

            // Act
            pion.ZetInEindpositie();

            // Assert
            Assert.True(pion.IsInEindpositie);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MensErgerJeNietLogic;

namespace MensErgerJeNietLogic.Tests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void Roll_ShouldReturnNumberBetweenOneAndSix()
        {
            // Arrange
            var dice = new Dice();

            // Act
            dice.Roll();
            var result = dice.Value;

            // Assert
            Assert.IsTrue(result >= 1 && result <= 6);
        }

        [TestMethod]
        public void Roll_ShouldTriggerRolledEvent()
        {
            // Arrange
            var dice = new Dice();
            var eventTriggered = false;
            dice.Rolled += (sender, e) => eventTriggered = true;

            // Act
            dice.Roll();

            // Assert
            Assert.IsTrue(eventTriggered);
        }
    }
}

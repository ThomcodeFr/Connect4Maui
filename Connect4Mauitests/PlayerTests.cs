using Connect4Maui.Models;

namespace Connect4Mauitests
{
    public class PlayersTests
    {
        [Fact]
        public void Player1_ShouldHaveRedColor()
        {
            // Arrange
            var player1 = new Player1();

            // Act
            var color = player1.Color;

            // Assert
            Assert.Equal(Colors.Red, color);
        }

        [Fact]
        public void Player2_ShouldHaveYellowColor()
        {
            // Arrange
            var player2 = new Player2();

            // Act
            var color = player2.Color;

            // Assert
            Assert.Equal(Colors.Yellow, color);
        }
    }
}

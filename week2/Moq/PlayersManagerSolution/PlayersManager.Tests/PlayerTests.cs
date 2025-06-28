using Moq;
using NUnit.Framework;
using PlayersManagerLib;
using System;

namespace PlayersManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockMapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_ValidName_PlayerIsCreated()
        {
            // Arrange
            string playerName = "Virat";
            _mockMapper.Setup(x => x.IsPlayerNameExistsInDb(playerName)).Returns(false);

            // Act
            Player player = Player.RegisterNewPlayer(playerName, _mockMapper.Object);

            // Assert
            Assert.That(player.Name, Is.EqualTo("Virat"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_EmptyName_ThrowsException()
        {
            // Arrange
            string playerName = "";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(playerName, _mockMapper.Object));
            Assert.That(ex.Message, Is.EqualTo("Player name can’t be empty."));
        }

        [Test]
        public void RegisterNewPlayer_ExistingName_ThrowsException()
        {
            // Arrange
            string playerName = "Dhoni";
            _mockMapper.Setup(x => x.IsPlayerNameExistsInDb(playerName)).Returns(true);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(playerName, _mockMapper.Object));
            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}

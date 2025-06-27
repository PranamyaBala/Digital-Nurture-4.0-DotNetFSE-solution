using NUnit.Framework;
using System;
using AccountsManagerLib;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class AccountsManagerTests
    {
        private AccountsManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new AccountsManager();
        }

        [Test]
        public void ValidateUser_ValidCredentials_ReturnsWelcomeMessage()
        {
            string result1 = _manager.ValidateUser("user_11", "secret@user11");
            string result2 = _manager.ValidateUser("user_22", "secret@user22");

            Assert.That(result1, Is.EqualTo("Welcome user_11!!!"));
            Assert.That(result2, Is.EqualTo("Welcome user_22!!!"));
        }

        [Test]
        public void ValidateUser_InvalidPassword_ReturnsErrorMessage()
        {
            string result = _manager.ValidateUser("user_11", "wrongpass");
            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        [Test]
        public void ValidateUser_InvalidUserId_ReturnsErrorMessage()
        {
            string result = _manager.ValidateUser("wrong_user", "secret@user11");
            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        [Test]
        public void ValidateUser_EmptyUserId_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => _manager.ValidateUser("", "secret@user11"));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }

        [Test]
        public void ValidateUser_EmptyPassword_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => _manager.ValidateUser("user_11", ""));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }

        [Test]
        public void ValidateUser_BothFieldsEmpty_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => _manager.ValidateUser("", ""));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }
    }
}

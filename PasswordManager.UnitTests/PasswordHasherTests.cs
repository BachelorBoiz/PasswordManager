using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.Abstractions;
using PasswordManager.Infrastructure;

namespace PasswordManager.UnitTests
{
    public class PasswordHasherTests
    {
        private readonly PasswordHasher _passwordHasher;

        public PasswordHasherTests() {
            _passwordHasher = new PasswordHasher();
        }
        
        
        [Fact]
        public void PasswordHasher_Hash_NullInput()
        {
            // Arrange
            string inputPassword = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _passwordHasher.Hash(inputPassword));
        }

        [Fact]
        public void PasswordHasher_Hash_EmptyInput()
        {
            // Arrange
            string inputPassword = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _passwordHasher.Hash(inputPassword));
        }

        [Fact]
        public void PasswordHasher_Verify_NullInput()
        {
            // Arrange
            string inputPassword = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _passwordHasher.Verify("Hashed Password inside DB", inputPassword));
        }

        [Fact]
        public void PasswordHasher_Verify_EmptyInput()
        {
            // Arrange
            string inputPassword = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _passwordHasher.Verify("Hashed Password inside DB", inputPassword));
        }


        [Fact]
        public void PasswordHasher_Verify_VerifyWorks() {
            //Arrange
            string password = "ZuckerMusk!9/11";
            string hashedPassword = _passwordHasher.Hash(password);
            //Act
            bool isPasswordValid = _passwordHasher.Verify(hashedPassword, password);
            //Assert
            Assert.True(isPasswordValid);

        }
    }
}

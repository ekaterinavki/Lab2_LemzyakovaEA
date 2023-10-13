using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace MyProject.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        //1. Тест на ввод корректных данных пользователя
        [Test]
        public void RegisterUser_ValidData_ReturnsTrue()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }

        //2. Тест на ввод некорректного логина (короткий логин)
        [Test]
        public void RegisterUser_InvalidLogin_ReturnsErrorMessage()
        {
            // Arrange
            string login = "user";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //3. Тест на ввод некорректного логина (неправильный формат)
        [Test]
        public void RegisterUser_InvalidLoginFormat_ReturnsErrorMessage()
        {
            // Arrange
            string login = "invalidlogin";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //4. Тест на ввод правильного формата логина (телефон)
        [Test]
        public void RegisterUser_ValidPhoneLogin_ReturnsTrue()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }
        //5. Тест на ввод правильного формата логина (электронная почта)
        [Test]
        public void RegisterUser_ValidEmailLogin_ReturnsTrue()
        {
            // Arrange
            string login = "test@example.com";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }
        //6. Тест на ввод некорректного пароля (короткий пароль)
        [Test]
        public void RegisterUser_InvalidPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "123";
            string confirmPassword = "123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //7. Тест на ввод неправильно подтвержденного пароля
        [Test]
        public void RegisterUser_InvalidConfirmPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "password";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //8. Тест на ввод пустого логина
        [Test]
        public void RegisterUser_EmptyLogin_ReturnsErrorMessage()
        {
            // Arrange
            string login = "";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //9. Тест на ввод пустого пароля
        [Test]
        public void RegisterUser_EmptyPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //10. Тест на ввод пустого подтверждения пароля
        [Test]
        public void RegisterUser_EmptyConfirmPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //11. Тест на ввод повторяющегося логина и пароля
        [Test]
        public void RegisterUser_DuplicateLoginAndPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "+1-123-456-7890";
            string confirmPassword = "+1-123-456-7890";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //12. Тест на ввод некорректного формата телефона
        [Test]
        public void RegisterUser_InvalidPhoneFormat_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //13. Тест на ввод некорректного формата электронной почты
        [Test]
        public void RegisterUser_InvalidEmailFormat_ReturnsErrorMessage()
        {
            // Arrange
            string login = "test@";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //14. Тест на ввод длинного логина
        [Test]
        public void RegisterUser_LongLogin_ReturnsTrue()
        {
            // Arrange
            string login = "verylonglogin123";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }
        //15. Тест на ввод длинного пароля
        [Test]
        public void RegisterUser_LongPassword_ReturnsTrue()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "verylongpassword123";
            string confirmPassword = "verylongpassword123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }
        //16. Тест на ввод длинного подтверждения пароля
        [Test]
        public void RegisterUser_LongConfirmPassword_ReturnsTrue()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "verylongpassword123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("True", result);
            Assert.AreEqual("", message);
        }
        //17. Тест на ввод разных паролей и подтверждений пароля
        [Test]
        public void RegisterUser_DifferentPasswordAndConfirmPassword_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = "differentpassword123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //18. Тест на ввод логина с пробелами
        [Test]
        public void RegisterUser_LoginWithSpaces_ReturnsErrorMessage()
        {
            // Arrange
            string login = " test ";
            string password = "password123";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //19. Тест на ввод пароля с пробелами
        [Test]
        public void RegisterUser_PasswordWithSpaces_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = " password123 ";
            string confirmPassword = "password123";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }
        //20. Тест на ввод подтверждения пароля с пробелами
        [Test]
        public void RegisterUser_ConfirmPasswordWithSpaces_ReturnsErrorMessage()
        {
            // Arrange
            string login = "+1-123-456-7890";
            string password = "password123";
            string confirmPassword = " password123 ";

            // Act
            (string result, string message) = Program.RegisterUser(login, password, confirmPassword);

            // Assert
            Assert.AreEqual("False", result);
            Assert.AreEqual("Ошибка при регистрации", message);
        }

    }
}

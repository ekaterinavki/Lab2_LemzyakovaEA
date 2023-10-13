using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace RegisterTests
{
    [TestFixture]
    public class RegTests
    {
        [Test]
        public void CheckLoginLength_EmptyLogin_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если логин - пустая строка,
            // то функция должна вернуть результат "False" и сообщение "Пустая строка в качестве логина"
            var result = Register.CheckLoginLength("");
            Assert.AreEqual(("False", "Пустая строка в качестве логина"), result);
        }

        [Test]
        public void CheckLoginLength_ShortLogin_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если длина логина меньше или равна 5 символам,
            // то функция должна вернуть результат "False" и сообщение "Длина логина меньше 5 символов"
            var result = Register.CheckLoginLength("abcd");
            Assert.AreEqual(("False", "Длина логина меньше 5 символов"), result);
        }

        [Test]
        public void CheckLoginLength_ValidLogin_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если логин удовлетворяет всем требованиям,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckLoginLength("username");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckExistUser_ExistingUser_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если логин уже существует в системе,
            // то функция должна вернуть результат "False" и сообщение "Логин уже используется"
            var result = Register.CheckExistUser("existingUser");
            Assert.AreEqual(("False", "Логин уже используется"), result);
        }

        [Test]
        public void CheckExistUser_NewUser_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если логин является новым и не существует в системе,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckExistUser("newUser");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckLoginContent_InvalidCharacters_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если логин содержит недопустимые символы,
            // то функция должна вернуть результат "False" и сообщение "Логин содержит недопустимые символы"
            var result = Register.CheckLoginContent("user@name");
            Assert.AreEqual(("False", "Логин содержит недопустимые символы"), result);
        }

        [Test]
        public void CheckLoginContent_ValidCharacters_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если логин содержит только допустимые символы,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckLoginContent("username");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckPasswordLength_ShortPassword_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если длина пароля меньше или равна 0,
            // то функция должна вернуть результат "False" и сообщение "Пустая строка в качестве пароля"
            var result = Register.CheckPasswordLength("");
            Assert.AreEqual(("False", "Пустая строка в качестве пароля"), result);
        }

        [Test]
        public void CheckPasswordLength_ValidPassword_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если длина пароля больше 0,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckPasswordLength("password");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckPasswordEquality_MatchingPasswords_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если пароли не совпадают,
            // то функция должна вернуть результат "False" и сообщение "Пароли не совпадают"
            var result = Register.CheckPasswordEquality("password1", "password2");
            Assert.AreEqual(("False", "Пароли не совпадают"), result);
        }

        [Test]
        public void CheckPasswordEquality_MatchingPasswords_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если пароли совпадают,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckPasswordEquality("password", "password");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckPasswordContent_InvalidCharacters_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если пароль содержит недопустимые символы,
            // то функция должна вернуть результат "False" и сообщение "Пароль содержит недопустимые символы"
            var result = Register.CheckPasswordContent("pass@word");
            Assert.AreEqual(("False", "Пароль содержит недопустимые символы"), result);
        }

        [Test]
        public void CheckPasswordContent_ValidCharacters_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если пароль содержит только допустимые символы,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckPasswordContent("password");
            Assert.AreEqual(("True", ""), result);
        }

        [Test]
        public void CheckRegister_InvalidLogin_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если первая проверка на длину логина не пройдена,
            // то функция должна вернуть результат первой непрошедшей проверки,
            // в данном случае - результат функции CheckLoginLength
            var result = Register.CheckRegister("", "password", "password");
            Assert.AreEqual(("False", "Пустая строка в качестве логина"), result);
        }

        [Test]
        public void CheckRegister_ExistingLogin_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если вторая проверка на существование пользователя не пройдена,
            // то функция должна вернуть результат второй непрошедшей проверки,
            // в данном случае - результат функции CheckExistUser
            var result = Register.CheckRegister("existingUser", "password", "password");
            Assert.AreEqual(("False", "Логин уже используется"), result);
        }

        [Test]
        public void CheckRegister_InvalidLoginContent_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если третья проверка на контент логина не пройдена,
            // то функция должна вернуть результат третьей непрошедшей проверки,
            // в данном случае - результат функции CheckLoginContent
            var result = Register.CheckRegister("user@name", "password", "password");
            Assert.AreEqual(("False", "Логин содержит недопустимые символы"), result);
        }

        [Test]
        public void CheckRegister_InvalidPasswordLength_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если четвёртая проверка на длину пароля не пройдена,
            // то функция должна вернуть результат четвёртой непрошедшей проверки,
            // в данном случае - результат функции CheckPasswordLength
            var result = Register.CheckRegister("username", "", "password");
            Assert.AreEqual(("False", "Пустая строка в качестве пароля"), result);
        }

        [Test]
        public void CheckRegister_PasswordsNotMatching_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если пятая проверка на совпадение паролей не пройдена,
            // то функция должна вернуть результат пятой непрошедшей проверки,
            // в данном случае - результат функции CheckPasswordEquality
            var result = Register.CheckRegister("username", "password1", "password2");
            Assert.AreEqual(("False", "Пароли не совпадают"), result);
        }

        [Test]
        public void CheckRegister_InvalidPasswordContent_ReturnsFalseAndErrorMessage()
        {
            // Проверяем, что если шестая проверка на контент пароля не пройдена,
            // то функция должна вернуть результат шестой непрошедшей проверки,
            // в данном случае - результат функции CheckPasswordContent
            var result = Register.CheckRegister("username", "pass@word", "pass@word");
            Assert.AreEqual(("False", "Пароль содержит недопустимые символы"), result);
        }

        [Test]
        public void CheckRegister_ValidData_ReturnsTrueAndEmptyMessage()
        {
            // Проверяем, что если все проверки прошли успешно,
            // то функция должна вернуть результат "True" и пустое сообщение
            var result = Register.CheckRegister("username", "password", "password");
            Assert.AreEqual(("True", ""), result);
        }
    }
}


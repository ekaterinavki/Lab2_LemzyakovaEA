using System;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using NUnit.Framework;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите логин:");
        string login = Console.ReadLine();

        Console.WriteLine("Введите пароль:");
        string password = Console.ReadLine();

        Console.WriteLine("Подтвердите пароль:");
        string confirmPassword = Console.ReadLine();

        (string result, string message) = RegisterUser(login, password, confirmPassword);

        Console.WriteLine(result);
        Console.WriteLine(message);

        Console.ReadKey();
    }

    public static (string, string) RegisterUser(string login, string password, string confirmPassword)
    {
        // Выходные данные
        bool result = false;
        string message = "";

        // Проверка данных пользователя
        if (IsLoginValid(login) && IsPasswordValid(password) && IsConfirmPasswordValid(password, confirmPassword))
        {
            result = true;
        }
        else
        {
            message = "Ошибка при регистрации";
        }

        // Запись результатов в лог
        string logText = GetFormattedLogText(login, password, confirmPassword, result, message);
        LogToFile(logText);
        LogToConsole(logText);

        return (result.ToString(), message);
    }

    public static bool IsLoginValid(string login)
    {
        try
        {
            // Проверка формата логина
            Regex phoneRegex = new Regex(@"^\+\d{1}-\d{3}-\d{3}-\d{4}$");
            Regex emailRegex = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");

            if (phoneRegex.IsMatch(login) || emailRegex.IsMatch(login) || login.Length >= 5)
            {
                // Проверка логина на уникальность
                string[] predefinedLogins = { "admin", "user1", "user2" };
                foreach (string predefinedLogin in predefinedLogins)
                {
                    if (predefinedLogin.ToLower() == login.ToLower())
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                throw new Exception("Неверный формат логина");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return false;
        }
    }

    public static bool IsPasswordValid(string password)
    {
        // Проверка формата пароля
        Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{7,}$");

        return passwordRegex.IsMatch(password);
    }

    //проверка паролей на совпадение
    public static bool IsConfirmPasswordValid(string password, string confirmPassword)
    {
        return password == confirmPassword;
    }

    public static string GetFormattedLogText(string login, string password, string confirmPassword, bool result, string message)
    {
        string logText = DateTime.Now.ToString() + " - ";
        logText += "Login: " + MaskPassword(login) + ", ";
        logText += "Password: " + MaskPassword(password) + ", ";
        logText += "Confirm Password: " + MaskPassword(confirmPassword) + ", ";

        if (result)
        {
            logText += "Результат: Успешная регистрация";
        }
        else
        {
            logText += "Результат: " + message;
        }

        return logText;
    }

    //маскирование пароля
    public static string MaskPassword(string password)
    {
        return new string('*', password.Length);
    }

    //записывает лог в файл "log.txt"
    public static void LogToFile(string logText)
    {
        using (StreamWriter sw = File.AppendText("log.txt"))
        {
            sw.WriteLine(logText);
        }
    }

    //выводит лог в консоль
    public static void LogToConsole(string logText)
    {
        Console.WriteLine(logText);
    }
}

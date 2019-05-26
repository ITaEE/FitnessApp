using System;
using System.Runtime.InteropServices;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System.Resources;
using System.Globalization;


namespace FitnessApp.CMD
{
    class Program
    {
        private static double value;

        static void Main(string[] args)
        {
            Console.WriteLine("Привет дружище, Я приложение для фитнесса !");
            Console.WriteLine("Пожалуйста, введите имя пользователя: ");
            var name = Console.ReadLine();

           var userController = new UserController(name);
           if (userController.IsNewUser)
           {
               Console.Write("Введите пол: ");
               var gender = Console.ReadLine();
               var birthDate = ParseDateTime("дата рождения");
               var weight = ParseDouble("вес");
               var height = ParseDouble("рост");
            
                userController.SetNewUserData(gender, birthDate, weight, height);
           }
           Console.WriteLine(userController.CurrentUser);

           Console.WriteLine("Что вы хотите сделать ? ");
           Console.WriteLine("E - ввести приём пищи ");
           var key = Console.ReadKey();
           if (key.Key == ConsoleKey.E)
           {
               //EnterEating();
           }
               
           Console.ReadLine();

        }

        //private static (Food, double) EnterEating()
        //{
        //    Console.WriteLine("Введите имя продукта: ");
        //    var food = Console.ReadLine();
    
        //    var weight = ParseDouble("вес порции");

        //}

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value}(dd.MM.yyy): ");
               
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value} ");
                }
                
            }

            return birthDate;

        }

        private static double ParseDouble(string name)
        {


            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}а ");
                }

            }
        }
    }
}

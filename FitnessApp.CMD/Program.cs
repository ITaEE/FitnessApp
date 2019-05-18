using System;
using System.Runtime.InteropServices;
using FitnessApp.BL.Controller;


namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет дружище, Я приложение для фитнесса");
            Console.WriteLine("Пожалуйста, введите ваше имя: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения: ");
            var birthday = DateTime.Parse(Console.ReadLine());//TODO: переписать

            Console.WriteLine("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}

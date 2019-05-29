﻿using System;
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
            var culture = CultureInfo.CreateSpecificCulture("de-de");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Message", typeof(Program).Assembly); 
            Console.WriteLine(resourceManager.GetString("HelloFriend", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
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
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);
            return (Food: product, Weight: weight);

        }

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
                    Console.WriteLine($"Неверный формат поля {name} ");
                }

            }
        }
    }
}

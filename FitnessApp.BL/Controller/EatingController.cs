using System;
using System.Collections.Generic;
using FitnessApp.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class EatingController:ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            }

            this.user = user;
            Foods = GetAllFoods();
            Eating = GetEating();
        }

      

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            if (Load<Eating>(EATINGS_FILE_NAME) == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new Eating(user);
            }
        }

        private List<Food> GetAllFoods()
        {
            if (Load<List<Food>>(FOODS_FILE_NAME) == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new List<Food>();
            }
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}

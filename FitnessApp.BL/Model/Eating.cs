﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;


namespace FitnessApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Приём пищи
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; set; }

        public Dictionary<Food, double> Foods { get; set; }

        public User User { get; }

        public Eating() { }

        public Eating(User user)
        {


            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment=DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
 }
  
using System;
using System.Globalization;


namespace FitnessApp.BL.Model
{
    [Serializable]
   
    public class Food
    {
        public const double GR = 100.0;
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; set; }

        public Food() { }

        public Food(string name):this(name, 0, 0, 0, 0) { }
        
           public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: Проверка
            Name = name;
            Calories = calories / GR;
            Proteins = proteins / GR;
            Fats = fats / GR;
            Carbohydrates = carbohydrates / GR ;
        }

           public override string ToString()
           {
               return Name;
           }
    }

}

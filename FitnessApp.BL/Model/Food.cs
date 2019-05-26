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
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; }

     

        public Food(string name):this(name, 0, 0, 0, 0) { }
        
           public Food(string name, double proteins, double fats, double carbohydrates, double calories)
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

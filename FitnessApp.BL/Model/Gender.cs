using System;


namespace FitnessApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Можно выбрать пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Выбрать имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создаем новый пол
        /// </summary>
        /// <param name="name">Имя пола</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        

        
    }
}


using FitnessApp.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового пользовательского контроллера
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthday, double weight, double height)
        {
            //TODO: Проверка.
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthday, weight, height);

        }
        public UserController()
        {

            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                User user = null;
                if (formatter.Deserialize(fs) is User)
                {
                    User = user;
                }
                else
                {
                    throw new ArgumentNullException();
                }

                //TODO: Что делать, если пользователя не прочитали ?
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>


    }
}

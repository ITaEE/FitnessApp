﻿
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController: ControllerBase
    {
        private const string USER_FILE_NAME = "users.dat";
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового пользовательского контроллера
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName) 
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

           
            //Users = GetUsersData();
        
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                //Save();
            }
        }
        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns>Пользователей.</returns>
        //private List<User> GetUsersData()
        //{
        //    return Load<User>() ?? new List<User>;                                    
        //}

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }
        


    }
}

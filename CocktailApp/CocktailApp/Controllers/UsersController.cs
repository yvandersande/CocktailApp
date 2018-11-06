using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CocktailApp.Models;
using SQLite;

namespace CocktailApp.Controllers
{
    class UsersController
    {
        private static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CocktailApp.db3");
        private static SQLiteConnection db = new SQLiteConnection(dbPath);

        public static Boolean SaveUser(Models.User user)
        {   
            db.CreateTable<User>();
            var maxPk = db.Table<User>().OrderByDescending(u => u.Id).FirstOrDefault();
            User userExcists = db.Table<User>().Where(u => u.Username == user.Username).FirstOrDefault();

            if (userExcists != null)
            {
                return false;
            }

            user.Id = (maxPk == null ? 1 : maxPk.Id + 1);

            db.Insert(user);
            return true;
        }

        public static Boolean LoginUser(string username, string password)
        {
            User userExcists = db.Table<User>().Where(u => u.Username == username).Where(u => u.Password == password).FirstOrDefault();

            if (userExcists == null)
            {
                return false;
            }

            return true;
        }
    }
}

using PetitBear.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetitBear.DB
{
    public class UserController
    {

        static object locker = new object();
        SQLiteAsyncConnection database;

        public UserController()
        {
            database = DependencyService.Get<ISQLiteDB>().GetConnection();
            database.CreateTableAsync<User>();
        }


        public Task<User> GetUser()
        {
            lock (locker)
            {
                if (database.Table<User>().CountAsync().ToString() == "0") 
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().FirstAsync();
                }
            }
        }

        public Task<int> SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0) //                 
                    return database.UpdateAsync(user);
                else
                    return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUser(int id)
        {
            lock (locker)
                return database.DeleteAsync(id);
        }


    }
}

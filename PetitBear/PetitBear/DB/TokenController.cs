using PetitBear.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetitBear.DB
{
    public class TokenController
    {

        static object locker = new object();
        SQLiteAsyncConnection database;

        public TokenController()
        {
            database = DependencyService.Get<ISQLiteDB>().GetConnection();
            database.CreateTableAsync<Token>();
        }


        public Task<Token> GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().CountAsync().ToString() == "0")
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().FirstAsync();
                }
            }
        }

        public Task<int> SaveToken(Token token)
        {
            lock (locker)
            {
                if (token.ID != 0) //                 
                    return database.UpdateAsync(token);
                else
                    return database.InsertAsync(token);
            }
        }

        public Task<int> DeleteToken(int id)
        {
            lock (locker)
                return database.DeleteAsync(id);
        }




    }
}

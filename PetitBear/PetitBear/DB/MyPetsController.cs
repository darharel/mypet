using PetitBear.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
namespace PetitBear.DB
{
    public class MyPetsController
    {
        static readonly object locker = new object();
        public static SQLiteAsyncConnection database;

        public MyPetsController()
        {
            database = DependencyService.Get<ISQLiteDB>().GetConnection();
            database.CreateTableAsync<PetDetailsModel>();
        }   


        public Task<List<PetDetailsModel>> GetMyPets()
        {
            lock (locker)
            {
                var list = database.Table<PetDetailsModel>().ToListAsync();
                if (list.Result.Count == 0)                
                    return null;
                
                else
                {
                    return list;
                }
            }
        }

        public Task<int> SavePet(PetDetailsModel item)
        {
            lock (locker)
            {
                if (item.ID != 0) //                 
                    return database.UpdateAsync(item);
                else
                    return database.InsertAsync(item);
            }
        }
        
        public Task<int> DeletePet(PetDetailsModel pet)
        {
            lock (locker)
                return database.DeleteAsync(pet);
        }

    }
}

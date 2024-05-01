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
    public class MyVetController
    {
        static readonly object locker = new object();
        public static SQLiteAsyncConnection database;

        public MyVetController()
        {
            database = DependencyService.Get<ISQLiteDB>().GetConnection();
            //database.DropTableAsync<VetDetailModel>();
            database.CreateTableAsync<VetDetailModel>();
        }

        public Task<VetDetailModel> GetMyVet()
        {
            lock (locker)
            {

                if (database.Table<VetDetailModel>().ToListAsync().Result.Count == 0)
                    database.InsertAsync(new VetDetailModel() { Name = "Set Your Vet's Name", Address = " And Your vet's Address" });

                return database.Table<VetDetailModel>().FirstAsync();
            }
        }

        public Task<int> SaveMyVet(VetDetailModel item)
        {
            lock (locker)
            {
                return database.UpdateAsync(item);
            }
        }

        public Task<int> DeletePet(VetDetailModel item)
        {
            lock (locker)
                return database.DeleteAsync(item);
        }


    }
}

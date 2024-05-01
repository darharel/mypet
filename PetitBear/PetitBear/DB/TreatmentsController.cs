using PetitBear.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetitBear.DB
{
    public class TreatmentsController
    {
        static readonly object locker = new object();
        public static SQLiteAsyncConnection database;

        public TreatmentsController()
        {
            database = DependencyService.Get<ISQLiteDB>().GetConnection();
            database.CreateTableAsync<TreatmentModel>();
        }

        public Task<List<TreatmentModel>> GetTreatmentsList()
        {
            lock (locker)
            {
                if (database.Table<TreatmentModel>().ToListAsync().Result.Count == 0)
                    database.InsertAsync(new TreatmentModel() { Name = "Set Your Treatment's Name" });

                return database.Table<TreatmentModel>().ToListAsync();
            }
        }

        public Task<int> SaveTreatment(TreatmentModel item)
        {
            lock (locker)
            {
                return database.UpdateAsync(item);
            }
        }

        public Task<int> DeleteTreatment(TreatmentModel item)
        {
            lock (locker)
                return database.DeleteAsync(item);
        }
    }
}

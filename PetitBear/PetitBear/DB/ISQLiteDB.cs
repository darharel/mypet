using SQLite;

namespace PetitBear.DB
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
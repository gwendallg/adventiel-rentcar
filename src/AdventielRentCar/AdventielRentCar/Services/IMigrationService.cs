using SQLite;

namespace AdventielRentCar.Services
{
    /// <summary>
    /// interface de gestion des migration de base de données
    /// </summary>
    public interface IMigrationService
    {
        /// <summary>
        /// migre la base de données
        /// </summary>
        /// <param name="connection"></param>
        void Migrate(SQLiteConnection connection);
    }
}

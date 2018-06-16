using SQLite;

namespace AdventielRentCar.Services
{
    /// <summary>
    /// interface de service d'accès base de données
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// retournne une connexion à la base de données
        /// </summary>
        /// <returns></returns>
        SQLiteConnection Connnection();
    }
}

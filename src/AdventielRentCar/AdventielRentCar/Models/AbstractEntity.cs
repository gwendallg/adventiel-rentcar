using SQLite;

namespace AdventielRentCar.Models
{
    public abstract class AbstractEntity
    {
        /// <summary>
        /// identifiant unique de la migration
        /// </summary>
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }
    }
}

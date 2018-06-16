using SQLite;

namespace AdventielRentCar.Models
{
    [Table("user")]
    public class User : AbstractEntity
    { 
        /// <summary>
        /// identifiant de l'utilisateur
        /// </summary>
        [Column(name: "login")] public string Login { get; set; }
        /// <summary>
        /// salt
        /// </summary>
        [Column(name: "salt")] public string Salt { get; set; }
        /// <summary>
        /// hash
        /// </summary>
        [Column(name: "hash")] public string Hash { get; set; }
    }
}

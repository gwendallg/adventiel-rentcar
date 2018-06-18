using System;
using SQLite;

namespace AdventielRentCar.Models
{
    [Table("migration")]
    public class Migration : AbstractEntity
    {
        /// <summary>
        /// nom du script
        /// </summary>
        [Column(name: "script")]
        public String Script { get; set; }

        /// <summary>
        /// versionde l'application 
        /// </summary>
        [Column(name: "app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// checksum du contenu du script sql
        /// </summary>
        [Column(name: "checkum")]
        public String Checkum { get; set; }

        /// <summary>
        /// date d'enregistrement de la migration
        /// </summary>
        [Column(name: "date_creation")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// durée d'exécution de la migration
        /// </summary>
        [Column(name: "duration")]
        public double Duration { get; set; }
    }
}

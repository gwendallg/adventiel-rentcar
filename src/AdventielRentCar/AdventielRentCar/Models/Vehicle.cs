using SQLite;

namespace AdventielRentCar.Models
{
    [Table("vehicle")]
    public class Vehicle : AbstractEntity
    {
        [Column(name: "manufacturer")] public string Manufacturer { get; set; }
        [Column(name: "model")] public string Model { get; set; }
        [Column(name: "description")] public string Description { get; set; }
        [Column(name: "mileage")] public int Mileage { get; set; }
        [Column(name: "licence_plate")] public string LicencePlate { get; set; }
    }
}

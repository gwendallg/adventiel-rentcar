namespace AdventielRentCarWebApp.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Manufacurer { get; set; }
        public string Model { get; set; }
        public string NumberPlate { get; set; }
        public int? Mileage { get; set; }
        public bool? Availability { get; set; }
    }
}

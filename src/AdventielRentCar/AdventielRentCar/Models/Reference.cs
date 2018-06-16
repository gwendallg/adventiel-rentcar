using SQLite;

namespace AdventielRentCar.Models
{
    [Table("reference")]
    public class Reference : AbstractEntity
    {
        [Column(name:"code")]
        public string Code { get; set; }
        [PrimaryKey]
        [Column(name: "domain")]
        public string Domain { get; set; }
        [Column(name: "value")]
        public string Value { get; set; }
        [Column(name: "description")]
        public string Description { get; set; }
    }
}

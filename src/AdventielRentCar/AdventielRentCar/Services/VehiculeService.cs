using System.Collections.Generic;
using System.Linq;
using AdventielRentCar.Models;

namespace AdventielRentCar.Services
{
    public class VehiculeService : IVehicleService
    {

        private readonly IDatabaseService _databaseService;

        public VehiculeService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IList<Vehicle> All()
        {
            using (var connection = _databaseService.Connnection())
            {
                return connection.Table<Vehicle>().ToList();
            }
        }
    }
}

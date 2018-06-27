using System.Collections.Generic;
using AdventielRentCar.Models;

namespace AdventielRentCar.Services
{
    public interface IVehicleService
    {
        /// <summary>
        /// retourne la liste des véhicules
        /// </summary>
        /// <returns></returns>
        IList<Vehicle> All();
    }
}

using System.Collections.Generic;
using System.Linq;
using AdventielRentCarWebApp.Models;
using AdventielRentCarWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventielRentCarWebApp.Controllers
{
    [Produces("application/json")]
    [Route("v1/vehicle")]
    public class VehicleController : Controller
    {
        public readonly IList<Vehicle> _repository;

        public VehicleController(IResourceService resourceService)
        {
            _repository = resourceService.Load<Vehicle>("vehicles");
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok(_repository);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var ret = _repository.SingleOrDefault(v => v.Id == id);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
    }
}
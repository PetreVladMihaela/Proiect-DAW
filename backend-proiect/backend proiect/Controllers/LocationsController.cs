using backend_proiect.Managers;
using backend_proiect.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Controller]

    public class LocationsController : ControllerBase
    {
        private readonly ILocationsManager manager;

        public LocationsController(ILocationsManager locationsManager)
        {
            this.manager = locationsManager;
        }


        [HttpGet]
        //[Authorize(Policy = "BasicUser")]
        public IActionResult GetLocations()
        {
            return Ok(manager.GetLocations());
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "BasicUser")]
        public IActionResult GetLocation([FromRoute] int id)
        {
            var loc = manager.GetLocation(id);
            return Ok(loc);
        }

        [HttpGet("byLandmarkId/{landmarkId}")]
        //[Authorize(Policy = "BasicUser")]
        public IActionResult GetLocationByLandmarkId([FromRoute] int landmarkId)
        {
            var loc = manager.GetLandmarkLocation(landmarkId);
            return Ok(loc);
        }

        //[HttpGet("byLandmarkId/{id}/city")]
        //public IActionResult GetLandmarkCity([FromRoute] int landmarkId)
        //{
        //    var loc = manager.GetLandmarkCity(landmarkId);
        //    return Ok(loc);
        //}


        [HttpPost]
        public IActionResult Create([FromBody] LocationModel loc)
        {
            manager.Create(loc);
            return Ok();
        }


        [HttpDelete("byLandmarkId/{landmarkId}")]
        public IActionResult DeleteByLandmarkId([FromRoute] int landmarkId)
        {
            manager.DeleteByLandmarkId(landmarkId);
            return Ok();
        }

        [HttpDelete("byLocationId/{id}")]
        public IActionResult DeleteByLocId([FromRoute] int id)
        {
            manager.DeleteByLocationId(id);
            return Ok();
        }


        [HttpPut("editByLandmark")]
        public IActionResult Update([FromBody] LocationModel loc)
        {
            manager.Update(loc);
            return Ok();
        }

    }
}

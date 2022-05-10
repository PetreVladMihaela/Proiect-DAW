using backend_proiect.Managers;
using backend_proiect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Controller]

    public class LandmarksController : ControllerBase
    {
        private readonly ILandmarksManager manager;

        public LandmarksController(ILandmarksManager landmarksManager)
        {
            this.manager = landmarksManager;
        }

        // read
        [HttpGet("")]
        //[Authorize(Policy = "User")]
        public IActionResult GetAllLandmarks()
        {
            var landmarks = manager.GetAllLandmarks();
            return Ok(landmarks);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "User")]
        public IActionResult GetLandmarkByItsId([FromRoute] int id)
        {
            var landmark = manager.GetLandmark(id);
            return Ok(landmark);
        }

        [HttpGet("byCountryId/{countryId}")]
        //[Authorize(Policy = "User")]
        public IActionResult GetCountryLandmarks([FromRoute] int countryId)
        {
            var landmarks = manager.GetLandmarksByCountryId(countryId);
            return Ok(landmarks);
        }

        [HttpGet("{id}/withLocation")]
        //[Authorize(Policy = "User")]
        public IActionResult GetLandmarkWithLocation([FromRoute] int id)
        {
            var landmark = manager.GetLandmarkWithLocation(id);
            return Ok(landmark);
        }

        [HttpGet("byCountryId/{countryId}/withLocations")]
        //[Authorize(Policy = "User")]
        public IActionResult GetLandmarksWithLocations([FromRoute] int countryId)
        {
            var landmark = manager.GetCountryLandmarksWithLocations(countryId);
            return Ok(landmark);
        }

        [HttpGet("Cities/{countryId}")]
        //[Authorize(Policy = "User")]
        public IActionResult GetLandmarCity([FromRoute] int countryId)
        {
            var landmark = manager.GetCountryCities(countryId);
            return Ok(landmark);
        }


        [HttpPost]
        //[Authorize(Policy = "Admin")]
        public IActionResult Create([FromBody] LandmarkModel landmark)
        {
            var id = manager.Create(landmark);
            return Ok(id);
        }

        [HttpPost("addVisitor")]
        //[Authorize(Policy = "User")]
        public IActionResult AddVisitorToCountry([FromBody] LandmarkVisitorModel model)
        {
            manager.AddVisitor(model);
            return Ok();
        }


        [HttpDelete("{id}")]
        //[Authorize(Policy = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpDelete("deleteAll")]
        //[Authorize(Policy = "Admin")]
        public IActionResult DeleteAll()
        {
            manager.DeleteAll();
            return Ok();
        }


        [HttpPut]
        //[Authorize(Policy = "Admin")]
        public IActionResult Update([FromBody] LandmarkModel landmark)
        {
            manager.Update(landmark);
            return Ok();
        }

    }
}

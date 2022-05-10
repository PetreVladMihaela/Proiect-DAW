using backend_proiect.Managers;
using backend_proiect.Models;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace backend_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Controller]

    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsManager manager;

        public VisitorsController(IVisitorsManager visitorsManager)
        {
            this.manager = visitorsManager;
        }

        // read
        [HttpGet("")]
        //[Authorize(Policy = "BasicUser")]
        public IActionResult GetVisitors()
        {
            var visitors = manager.GetVisitors();
            return Ok(visitors);
        }

        [HttpGet("{email}")]
        public IActionResult GetCountryById([FromRoute] string email)
        {
            var visitor = manager.GetVisitorByEmail(email);
            return Ok(visitor);
        }

        [HttpGet("{email}/visitedLandmarks")]
        public IActionResult test([FromRoute] string email)
        {
            var landmarks = manager.GetVisitedLandmarks(email);
            return Ok(landmarks);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VisitorModel visitor)
        {
            manager.Create(visitor);
            return Ok();
        }


        [HttpDelete("{email}")]
        public IActionResult Delete([FromRoute] string email)
        {
            manager.Delete(email);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update([FromBody] VisitorModel visitor)
        {
            manager.Update(visitor);
            return Ok();
        }
    }
}

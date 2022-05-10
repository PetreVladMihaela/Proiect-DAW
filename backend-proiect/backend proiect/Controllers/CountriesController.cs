using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using backend_proiect.Managers;
using backend_proiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Controller]

    public class CountriesController : ControllerBase
    {
        private readonly ICountriesManager manager;

        public CountriesController(ICountriesManager countriesManager)
        {
            this.manager = countriesManager;
        }

        // read
        [HttpGet("")]
        //[Authorize(Policy = "User")]
        public IActionResult GetCountries()
        {
            var countries = manager.GetCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "User")]
        public IActionResult GetCountryById([FromRoute] int id)
        {
            var country = manager.GetCountryById(id);
            return Ok(country);
        }


        [HttpGet("withLandmarks")]
        //[Authorize(Policy = "User")]
        public IActionResult GetCountriesWithLandmarks()
        {
            var countries = manager.GetCountriesWithLandmarks();
            return Ok(countries);
        }


        [HttpPost]
        //[Authorize(Policy = "Admin")]
        public IActionResult Create([FromBody] CountryModel country)
        {
            manager.Create(country);
            return Ok();
        }


        [HttpDelete("{id}")]
        //[Authorize(Policy = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }


        [HttpPut]
        //[Authorize(Policy = "Admin")]
        public IActionResult Update([FromBody] CountryModel country)
        {
            manager.Update(country);
            return Ok();
        }


        //[HttpPut("{id}/updateLandmarks")]
        //public IActionResult UpdateCountryLandmarks([FromBody] int id)
        //{
        //    manager.UpdateCountryLandmarks(id);
        //    return Ok();
        //}

    }
}


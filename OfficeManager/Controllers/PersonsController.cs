using Microsoft.AspNetCore.Mvc;
using OfficeManager.Interfaces;
using OfficeManager.ViewModels;

namespace OfficeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService personsService;

        public PersonsController(IPersonsService personsService)
        {
            this.personsService = personsService;
        }

        [HttpPost()]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            return Created("", new { PersonId = personsService.CreatePerson(personViewModel) });
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            return Ok(new { Deleted = personsService.DeletePerson(id) });
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(personsService.GetAllPersons());
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(string id)
        {
            return Ok(personsService.GetPersonById(id));
        }

        [HttpPut()]
        public IActionResult UpdatePerson(PersonViewModel personViewModel)
        {
            return Ok(new { Updated = personsService.UpdatePerson(personViewModel) });
        }
    }
}
using bs.Data.Helpers;
using bs.Data.Interfaces;
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
        private readonly IUnitOfWork unitOfWork;

        public PersonsController(IUnitOfWork unitOfWork, IPersonsService personsService)
        {
            this.unitOfWork = unitOfWork;
            this.personsService = personsService;
        }

        [HttpPost()]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Created("", new { PersonId = personsService.CreatePerson(personViewModel) });
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(new { Deleted = personsService.DeletePerson(id) });
            });
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(personsService.GetAllPersons());
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(string id)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(personsService.GetPersonById(id));
            });
        }

        [HttpPut()]
        public IActionResult UpdatePerson(PersonViewModel personViewModel)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(new { Updated = personsService.UpdatePerson(personViewModel) });
            });
        }
    }
}
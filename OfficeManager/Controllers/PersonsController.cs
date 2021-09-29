using bs.Data.Helpers;
using bs.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OfficeManager.Interfaces;
using OfficeManager.ViewModels;

namespace OfficeManager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        /// <summary>
        /// The persons service
        /// </summary>
        private readonly IPersonsService personsService;
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="personsService">The persons service.</param>
        public PersonsController(IUnitOfWork unitOfWork, IPersonsService personsService)
        {
            this.unitOfWork = unitOfWork;
            this.personsService = personsService;
        }

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <remarks>
        /// Richiesta di esempio:
        ///
        ///     POST /Persons
        ///     {
        ///        "name": "Mario",
        ///        "surname": "Rossi",
        ///        "birthDate": "1990-06-10"
        ///     }
        ///
        /// </remarks>
        /// <param name="personViewModel">The person view model.</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Created("", new { PersonId = personsService.CreatePerson(personViewModel) });
            });
        }

        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(new { Deleted = personsService.DeletePerson(id) });
            });
        }

        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(personsService.GetAllPersons());
            });
        }

        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetPersonById(string id)
        {
            return unitOfWork.RunInTransaction(() =>
            {
                return Ok(personsService.GetPersonById(id));
            });
        }

        /// <summary>
        /// Updates the person.
        /// </summary>
        /// <param name="personViewModel">The person view model.</param>
        /// <returns></returns>
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
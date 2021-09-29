using bs.Data.Helpers;
using bs.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeManager.Interfaces;
using OfficeManager.ViewModels;

namespace OfficeManager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
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
        ///     POST /api/persons
        ///     {
        ///        "name": "Mario",
        ///        "surname": "Rossi",
        ///        "birthDate": "1990-06-10"
        ///     }
        ///
        /// </remarks>
        /// <param name="personViewModel">The person view model.</param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created person id</response>
        /// <response code="500">If any error occurs</response>            
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <remarks>
        /// Richiesta di esempio:
        ///
        ///     DELETE /api/persons/-personId-
        ///
        /// NB.: Sostituisci -personId- con l'identificatifo della persona (id) che vuoi eliminare
        /// </remarks>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="200">Returns a boolean that explains if the person was deleted or not</response>
        /// <response code="500">If any error occurs</response>            
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <remarks>
        /// Richiesta di esempio:
        ///
        ///     GET /api/persons
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Returns the list of persons</response>
        /// <response code="204">No persons exist</response>
        /// <response code="500">If any error occurs</response>            
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <remarks>
        /// Richiesta di esempio:
        ///
        ///     GET /api/persons/-personId-
        ///
        /// NB.: Sostituisci -personId- con l'identificatifo della persona (id) che vuoi ottenere
        /// </remarks>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="200">Returns the person</response>
        /// <response code="204">No person exists</response>
        /// <response code="500">If any error occurs</response>            
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <remarks>
        /// Richiesta di esempio:
        ///
        ///     PUT /api/persons
        ///     {
        ///        "id": -personId-
        ///        "name": "Mario",
        ///        "surname": "Rossi",
        ///        "birthDate": "1990-06-10"
        ///     }
        ///
        /// NB.: Sostituisci -personId- con l'identificatifo della persona (id) che vuoi modificare
        /// </remarks>
        /// <param name="personViewModel">The person view model.</param>
        /// <returns></returns>
        /// <response code="200">Returns a boolean that explains if the person was updated or not</response>
        /// <response code="500">If any error occurs</response>            
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.Interfaces
{
    public interface IPersonsService
    {
        IEnumerable<IPersonViewModel> GetAllPersons();
        IPersonViewModel GetPersonById(string personId);
        string CreatePerson(IPersonViewModel person);
        bool UpdatePerson(IPersonViewModel person);
        bool DeletePerson(string personId);
        bool MovePerson(string sourceRoomId, string targetRoomId);
    }
}

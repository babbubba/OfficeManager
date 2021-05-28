using OfficeManager.Interfaces;
using System.Collections.Generic;

namespace OfficeManager.Interfaces
{
    public interface IPersonsRepository
    {
        void CreatePerson(IPerson person);
        void DeletePerson(IPerson person);
        IPerson GetPersonById(int id);
        IEnumerable<IPerson> GetPersons();
        IEnumerable<IPerson> GetPersonsByName(string name);
        IEnumerable<IPerson> GetPersonsHavingBirthday(int day, int month);
    }
}
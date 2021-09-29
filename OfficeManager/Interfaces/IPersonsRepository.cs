using OfficeManager.Interfaces;
using System.Collections.Generic;

namespace OfficeManager.Interfaces
{
    public interface IPersonsRepository
    {
        void CreatePerson(IPersonModel person);
        void UpdatePerson(IPersonModel person);
        void DeletePerson(IPersonModel person);
        IPersonModel GetPersonById(int id);
        IEnumerable<IPersonModel> GetPersons();
        IEnumerable<IPersonModel> GetPersonsByName(string name);
        IEnumerable<IPersonModel> GetPersonsHavingBirthday(int day, int month);
    }
}
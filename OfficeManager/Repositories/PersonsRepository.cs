using bs.Data.Interfaces;
using OfficeManager.Interfaces;
using OfficeManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace OfficeManager.Repositories
{
    public class PersonsRepository : bs.Data.Repository, IPersonsRepository
    {
        public PersonsRepository(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }

        public void CreatePerson(IPersonModel person)
        {
            Create((PersonModel)person);
        }

        public void DeletePerson(IPersonModel person)
        {
            Delete((PersonModel)person);
        }

        public IPersonModel GetPersonById(int id)
        {
            return GetById<PersonModel>(id);
        }

        public IEnumerable<IPersonModel> GetPersons()
        {
            return Query<PersonModel>()
                .ToList();
        }

        public IEnumerable<IPersonModel> GetPersonsByName(string name)
        {
            return Query<PersonModel>()
                .Where(p => p.Name == name)
                .ToList();
        }

        public IEnumerable<IPersonModel> GetPersonsHavingBirthday(int day, int month)
        {
            return Query<PersonModel>()
                .Where(p => p.BirthDate.Day == day && p.BirthDate.Month == month)
                .ToList();
        }
    }
}
using bs.Data.Interfaces;
using OfficeManager.Interfaces;
using OfficeManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace OfficeManager.Repository
{
    public class PersonsRepository : bs.Data.Repository, IPersonsRepository
    {
        public PersonsRepository(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }

        public void CreatePerson(IPerson person)
        {
            Create((PersonModel)person);
        }

        public void DeletePerson(IPerson person)
        {
            Delete((PersonModel)person);
        }

        public IPerson GetPersonById(int id)
        {
            return GetById<PersonModel>(id);
        }

        public IEnumerable<IPerson> GetPersons()
        {
            return Query<PersonModel>()
                .ToList();
        }

        public IEnumerable<IPerson> GetPersonsByName(string name)
        {
            return Query<PersonModel>()
                .Where(p => p.Name == name)
                .ToList();
        }

        public IEnumerable<IPerson> GetPersonsHavingBirthday(int day, int month)
        {
            return Query<PersonModel>()
                .Where(p => p.BirthDate.Day == day && p.BirthDate.Month == month)
                .ToList();
        }
    }
}
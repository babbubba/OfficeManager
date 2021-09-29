using AutoMapper;
using OfficeManager.Interfaces;
using OfficeManager.Models;
using System;
using System.Collections.Generic;

namespace OfficeManager.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IMapper mapper;
        private readonly IPersonsRepository personsRepository;

        public PersonsService(IMapper mapper, IPersonsRepository personsRepository)
        {
            this.mapper = mapper;
            this.personsRepository = personsRepository;
        }

        public string CreatePerson(IPersonViewModel person)
        {
            var personModel = mapper.Map<IPersonModel>(person);
            personsRepository.CreatePerson(personModel);
            return personModel.Id.ToString();
        }

        public bool DeletePerson(string personId)
        {
            var id = Convert.ToInt32(personId);
            var existingPersonModel = personsRepository.GetPersonById(id);
            if (existingPersonModel == null) return false;

            personsRepository.DeletePerson(existingPersonModel);
            return true;
        }

        public IEnumerable<IPersonViewModel> GetAllPersons()
        {
            var persons = personsRepository.GetPersons();
            return mapper.Map<IEnumerable<IPersonViewModel>>(persons);
        }

        public IPersonViewModel GetPersonById(string personId)
        {
            var id = Convert.ToInt32(personId);
            var person = personsRepository.GetPersonById(id);
            return mapper.Map<IPersonViewModel>(person);
        }

        public bool MovePerson(string sourceRoomId, string targetRoomId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(IPersonViewModel person)
        {
            if (person.Id <= 0) return false;
            var existingPersonModel = personsRepository.GetPersonById(person.Id);
            mapper.Map(person, existingPersonModel);
            personsRepository.UpdatePerson(existingPersonModel);
            return true;
        }
    }
}
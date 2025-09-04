using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyLearningProject.Enitities.People.Dto;
using MyLearningProject.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Enitities.People
{
    public class PersonAppService : ApplicationService
    {
        private readonly IRepository<Person, int> _personRepository;

        public PersonAppService(IRepository<Person, int> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = new Person
            {
                FullName = input.FullName,
                Age = input.Age.ToString() 
            };

            // Insert the new Person entity into the database
            var personEntity = await _personRepository.InsertAsync(person);

            // Map the entity to a DTO to return to the client
            var personDto = ObjectMapper.Map<PersonDto>(personEntity);

            return personDto;
        }

    }
    
}

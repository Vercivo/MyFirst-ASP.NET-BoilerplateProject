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
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllListAsync();
            return ObjectMapper.Map<List<PersonDto>>(persons);
        }
        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetAsync(id);
            return ObjectMapper.Map<PersonDto>(person);
        }
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var person = new Person
            {
                FullName = input.FullName,
                Age = input.Age
            };

            // Insert the new Person entity into the database
            var personEntity = await _personRepository.InsertAsync(person);

            await CurrentUnitOfWork.SaveChangesAsync(); // Ensure the changes are saved

            // Map the entity to a DTO to return to the client
            var personDto = ObjectMapper.Map<PersonDto>(personEntity);

            return personDto;
        }
        public async Task<PersonDto> UpdateAsync(int id, PersonDto input)
        {
            var person = await _personRepository.GetAsync(id);
            person.FullName = input.FullName;
            person.Age = input.Age.ToString();
            var updatedPerson = await _personRepository.UpdateAsync(person);
            return ObjectMapper.Map<PersonDto>(updatedPerson);
        }
        public async Task DeleteAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }

    }
    
}

using Uwierzytelnianie.Interfaces;
using Uwierzytelnianie.Models;
using Uwierzytelnianie.ViewModels.Person;
using Uwierzytelnianie.Repositories;

namespace Uwierzytelnianie.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public List<PersonVM> GetAllEntries()
        {
            var people = _personRepo.GetAllEntries();
            List<PersonVM> result = new List<PersonVM>();
            foreach (var person in people)
            {
                var pVM = new PersonVM()
                {
                    Id = person.Id,
                    FullName = person.Imie + " " + person.Nazwisko,
                    Rok = person.Rok,
                    Text = person.Text,
                    Date = person.Data,
                    User = person.User
                };
                result.Add(pVM);
            }
            return result;
        }

        public List<PersonVM> GetEntriesFromToday()
        {
            var people = _personRepo.GetEntriesFromToday();
            List<PersonVM> result = new List<PersonVM>();

            foreach (var person in people)
            {
                var pVM = new PersonVM()
                {
                    FullName = person.Imie + " " + person.Nazwisko,
                    Rok = person.Rok,
                    Text = person.Text,
                    Date = person.Data,
                    User = person.User
                };
                result.Add(pVM);
            }
            return result;
        }

        public void AddEntry(Person person)
        {
            _personRepo.AddEntry(person);
        }

        public void RemoveEntry(Person person)
        {
            _personRepo.RemoveEntry(person);
        }

        public Person GetEntry(int? id)
        {
            return _personRepo.GetEntry(id);
        }
    }
}

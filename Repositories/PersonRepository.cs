using Uwierzytelnianie.Interfaces;
using Uwierzytelnianie.Models;
using Uwierzytelnianie.Data;

namespace Uwierzytelnianie.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetAllEntries()
        {
            return _context.Person.OrderByDescending(p => p.Data).Take(20);
        }

        public IQueryable<Person> GetEntriesFromToday()
        {
            DateTime dateTime = DateTime.Today.AddDays(1);
            return _context.Person.Where(p => p.Data >= DateTime.Today && p.Data < dateTime).OrderByDescending(p => p.Data);
        }

        public void AddEntry(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void RemoveEntry(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        public Person GetEntry(int? id)
        {
            return _context.Person.Find(id);
        }

    }
}

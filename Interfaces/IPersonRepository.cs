using Uwierzytelnianie.Models;

namespace Uwierzytelnianie.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAllEntries();
        IQueryable<Person> GetEntriesFromToday();
        void AddEntry(Person person);
        void RemoveEntry(Person person);
        Person GetEntry(int? id);
    }

}

using Uwierzytelnianie.ViewModels.Person;
using Uwierzytelnianie.Models;

namespace Uwierzytelnianie.Interfaces
{
    public interface IPersonService
    {
        List<PersonVM> GetAllEntries();
        List<PersonVM> GetEntriesFromToday();
        void AddEntry(Person person);
        void RemoveEntry(Person person);
        Person GetEntry(int? id);
    }
}

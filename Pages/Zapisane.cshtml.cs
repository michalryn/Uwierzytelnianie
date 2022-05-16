using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Uwierzytelnianie.ViewModels.Person;
using Uwierzytelnianie.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Uwierzytelnianie.Pages
{
    [Authorize]
    public class ZapisaneModel : PageModel
    {
        private readonly IPersonService _personService;

        public ZapisaneModel(IPersonService personService)
        {
            _personService = personService;
        }
        public IList<PersonVM> Persons { get; set; }
        public string? name { get; set; }
        public void OnGet()
        {
            Persons = _personService.GetAllEntries();
            //Persons.OrderByDescending(p => p.Date);
            name = User?.Identity?.Name;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Uwierzytelnianie.Interfaces;
using Uwierzytelnianie.Models;
using Uwierzytelnianie.ViewModels.Person;
using Microsoft.AspNetCore.Identity;

namespace Uwierzytelnianie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Person Person { get; set; }

        [BindProperty]
        public List<PersonVM>? Persons { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IPersonService personService, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _personService = personService;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            Persons = _personService.GetEntriesFromToday();
            Persons.OrderByDescending(p => p.Date);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = Person.AlertMessage();
                if (_signInManager.IsSignedIn(User))
                {
                    Person.User = User?.Identity?.Name;
                }
                else
                {
                    Person.User = null;
                }
                _personService.AddEntry(Person);

                return Redirect("/Index");
            }
            Persons = _personService.GetEntriesFromToday();
            Persons.OrderByDescending(p => p.Date);
            return Page();
        }
    }
}
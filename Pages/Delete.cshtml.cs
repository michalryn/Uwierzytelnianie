using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Uwierzytelnianie.Interfaces;
using Uwierzytelnianie.Models;


namespace Uwierzytelnianie.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IPersonService _personService;
        public DeleteModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public Person Person { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _personService.GetEntry(id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _personService.GetEntry(id);

            if (Person != null && Person.User == User?.Identity?.Name)
            {
                _personService.RemoveEntry(Person);
            }

            return RedirectToPage("./Zapisane");
        }
    }
}

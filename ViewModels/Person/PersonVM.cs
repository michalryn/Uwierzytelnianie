using System.ComponentModel.DataAnnotations;

namespace Uwierzytelnianie.ViewModels.Person
{
    public class PersonVM
    {
        public int Id { get; set; }
        [Display(Name = "Imię i Nazwisko użytkownika")]
        public string FullName { get; set; }

        [Display(Name = "Rok")]
        public int? Rok { get; set; }

        [DataType(DataType.Text)]
        public string? Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string? User { get; set; }
    }
}

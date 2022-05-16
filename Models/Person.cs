using System.ComponentModel.DataAnnotations;

namespace Uwierzytelnianie.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "Imię użytownika")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"),
            StringLength(100, ErrorMessage = "{0} może mieć maksymalnie {1} znaków")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko użytkownika")]
        [StringLength(100, ErrorMessage = "{0} może mieć maksymalnie {1} znaków")]
        public string? Nazwisko { get; set; }

        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"),
            Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Rok { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [DataType(DataType.Text)]
        public string? Text { get; set; }

        public bool Przestepny;

        public string? User { get; set; }

        private void CzyPrzestepny()
        {
            if ((Rok % 4 == 0 && Rok % 100 != 0) || (Rok % 400 == 0))
            {
                Przestepny = true;
                Text = "rok przestępny";
            }

            else
            {
                Przestepny = false;
                Text = "rok nieprzestępny";
            }
            Data = DateTime.Now;
        }
        public string Message()
        {
            string message = "";
            if (Przestepny)
                message += "rok przestępny";
            else
                message += "rok nieprzestępny";
            return message;
        }
        public string AlertMessage()
        {
            CzyPrzestepny();
            string message = $"{Imie}: urodził się w {Rok} roku.";
            if (Przestepny)
                message += " To jest rok przestępny";
            else
                message += " To nie jest rok przestępny";
            return message;
        }
    }
}

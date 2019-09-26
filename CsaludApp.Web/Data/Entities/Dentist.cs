using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CsaludApp.Web.Data.Entities
{
    public class Dentist
    {
        public int Id { get; set; }

        [Display(Name = "Document")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "Dentist")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Dentist")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Consent> Consents { get; set; }
        //public User User { get; internal set; }
    }
}

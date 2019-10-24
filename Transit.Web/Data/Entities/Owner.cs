using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transit.Web.Data.Entities;

namespace Transit.Web.Models.Data.Entities
{
    public class Owner
    {
        public int id { get; set; }

        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document { get; set; }


        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }


        [Display(Name = "Cell Phone")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CellPhone { get; set; }

        [Display(Name = "Owner Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Owner Name")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Vehicle> Vehicles { get; set; }

        public License License { get; set; }

    }
}

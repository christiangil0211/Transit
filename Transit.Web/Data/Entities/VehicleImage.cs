using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transit.Web.Data.Entities
{
    public class VehicleImage
    {
        public int id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";

        public Vehicle Vehicle { get; set; }

    }
}

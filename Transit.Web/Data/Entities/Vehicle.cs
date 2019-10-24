using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transit.Web.Models.Data.Entities;

namespace Transit.Web.Data.Entities
{
    public class Vehicle
    {
        public int id { get; set; }

        [Display(Name = "Placa")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Placa { get; set; }

        [Display(Name = "Star Soat")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSoatStar { get; set; }

        [Display(Name = "End Soat")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSoatEnd { get; set; }

        [Display(Name = "Star Date Gas Analysis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTecnoStar { get; set; }

        [Display(Name = "End Date Gas Analysis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTecnoEnd { get; set; }

        [Display(Name = "Color")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Color { get; set; }

        [Display(Name = "Vehicle Identification Number")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Vin { get; set; }

        [Display(Name = "Type Vehicle")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string TypeVehicle { get; set; }

        [Display(Name = "Start Date Soat")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocalSoat => DateSoatStar.ToLocalTime();

        [Display(Name = "End Date Soat")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocalSoat => DateSoatEnd.ToLocalTime();

        [Display(Name = "Start Date Gas Analysis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocalTecno => DateTecnoStar.ToLocalTime();

        [Display(Name = "End Date Gas Analysis ")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocalTecno => DateTecnoEnd.ToLocalTime();

        public Owner Owner { get; set; }

        public ICollection<VehicleImage> VehicleImages { get; set; }

       

    }
}

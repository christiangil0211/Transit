using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transit.Web.Data.Entities;

namespace Transit.Web.Models.Data.Entities
{
    public class Owner 
    {
        public int id { get; set; }

        public User User { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public License License { get; set; }

    }
}

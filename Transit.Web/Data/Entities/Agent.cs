﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transit.Web.Data.Entities
{
    public class Agent
    {
        public int id { get; set; }

        public User User { get; set; }


    }
}

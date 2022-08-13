﻿using Foodler.Repository.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Accounts
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

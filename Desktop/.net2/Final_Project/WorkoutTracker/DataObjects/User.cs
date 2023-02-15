﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class User
    {
        public int UserID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public List<string> Roles { get; set; }

    }
}

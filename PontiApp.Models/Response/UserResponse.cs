﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Response
{
    public class UserResponse
    {
        public long fbId { get; set; }
        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mail { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}

﻿using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class CategoryDTO : IdDTO
    {
        public string Cetegory { get; set; }

        public bool IsDeleted { get; set; }
    }
}

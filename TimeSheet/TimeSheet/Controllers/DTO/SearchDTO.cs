﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Controllers.DTO
{
    public class SearchDTO
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int Number { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class BaseModel
    {
        [Required]
        public long Id { get; set; }
     
    }
}

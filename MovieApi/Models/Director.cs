using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Director : BaseModel
    {
        public long PersonId { get; set; }

        public Person Person { get; set; }

    }
}

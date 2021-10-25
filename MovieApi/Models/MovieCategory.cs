using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class MovieCategory : BaseModel
    {
        public long CategoryId { get; set; }

        public Category Category { get; set; }

        public long MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}

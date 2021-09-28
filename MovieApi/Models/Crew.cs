using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Crew : BaseModel
    {
        public long? ActorId { get; set; }

        public Actor Actor { get; set; }

        public long? DirectorId { get; set; }

        public Director Director { get; set; }

        public long MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}

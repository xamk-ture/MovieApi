using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public ICollection<Director> Directors { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public string SecretInfo { get; set; }
   
    }
}

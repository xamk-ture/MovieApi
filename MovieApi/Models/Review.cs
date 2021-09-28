using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Review : BaseModel
    {
        //This line fetches all reviews that are critic rated. If userRating is null and professionalRating has value it means it is critic rating
        //var criticReviews = context.Reviews.Where(x => x.UserRating == null).ToArray();
        //var averageRating = criticReviews.Sum(x => x.ProfessionalRating) / reviews.Count();

        //var criticReviews = context.Reviews.Where(x => x.IsCriticRated).ToArray();
        //var averageRating = criticReviews.Sum(x => x.Rating) / reviews.Count();

        //public double ProfessionalRating { get; set; }

        //public double UserRating { get; set; }

        public double Rating { get; set; }

        public bool IsCriticRated { get; set; }

        public string? Text { get; set; }

        public long MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}

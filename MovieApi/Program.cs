using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MovieContext>();

                GenerateMovieData(context);
                GenerateCategories(context);
                GenerateActorDataToMovie(context, 1);
                GenerateDirectorDataToMovie(context, 1);

                context.SaveChanges();
            }

            host.Run();
        }

        private static void GenerateCategories(MovieContext context)
        {
            if (context.Categories.Any())
                return;

            var horrorCategory = new Category() { Name = "Horror" };
            var comedyCategory = new Category() { Name = "Comedy" };

            context.Add(horrorCategory);
            context.Add(comedyCategory);
        }

        /// <summary>
        /// Generates actor data to movie
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="movieId">MovieId to what movie to generate the data</param>
        private static void GenerateMovieData(MovieContext context)
        {
            if (context.Movies.Any())
                return;

            //You can add here new objects to the in memory database, so you have some data when you are starting up the project
            var movie1 = new Movie()
            {
                Name = "Testi elokuva",
                Description = "Testi kuvaus",
                SecretInfo = "Ei asiakkaille nähtäväksi!"
            };

            context.Movies.Add(movie1);

            var movie2 = new Movie()
            {
                Name = "Elokuva kaksi",
                Description = "Kaksi kuvaus",
                SecretInfo = "Salaista tietoa",
                Reviews = new List<Review>() { new Review() { Rating = 1, Text = "Yksi tähteä", IsCriticRated = true } }
            };

            context.Movies.Add(movie2);
        }

        /// <summary>
        /// Generates director data to movie
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="movieId">MovieId to what movie to generate the data</param>
        private static void GenerateActorDataToMovie(MovieContext context, long movieId)
        {
            if (context.Actors.Any())
                return;

            var actorPerson = new Person();
            actorPerson.FirstName = "Pena";
            actorPerson.LastName = "Näyttelijä";

            context.Persons.Add(actorPerson);

            var actor = new Actor();
            actor.MovieId = movieId;
            actor.PersonId = actorPerson.Id;
            actorPerson.Actor = actor;

            context.Actors.Add(actor);
        }

        private static void GenerateDirectorDataToMovie(MovieContext context, long movieId)
        {
            if (context.Directors.Any())
                return;

            var directorPerson = new Person();
            directorPerson.FirstName = "Ohjaaja";
            directorPerson.LastName = "Nainen";

            context.Persons.Add(directorPerson);

            var director = new Director();
            director.MovieId = movieId;
            director.Person = directorPerson;

            context.Directors.Add(director);
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

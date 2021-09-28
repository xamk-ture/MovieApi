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


                //You can add here new objects to the in memory database, so you have some data when you are starting up the project
                var movie1 = new Movie()
                {
                    Name = "Testi elokuva",
                    Description = "Testi kuvaus",
                    Reviews = new List<Review>() { new Review() { Rating = 5, Text = "Viisi tähteä" }, new Review() { Rating = 3, Text = "Kolme tähteä" } }
                };

                context.Movies.Add(movie1);

                var movie2 = new Movie()
                {
                    Name = "Elokuva kaksi",
                    Description = "Kaksi kuvaus",
                    Reviews = new List<Review>() { new Review() { Rating = 1, Text = "Yksi tähteä", IsCriticRated = true } }
                };

                context.Movies.Add(movie2);

                var person = new Person();
                person.FirstName = "Pena";
                person.Id = 12;

                context.Persons.Add(person);

                var actor = new Actor();
                actor.PersonId = person.Id;
                person.Actor = actor;

                context.SaveChanges();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

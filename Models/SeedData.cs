using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Best Two Years",
                    ReleaseDate = DateTime.Parse("2003-10-10"),
                    Genre = "Dramedy",
                    Rating = "PG",
                    Price = 7.99M,
                    ImgPath = "~/img/best-two-years.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Rating = "G",
                    Price = 8.99M,
                    ImgPath = "~/img/meet-the-mormons.jpg"
                },
                new Movie
                {
                    Title = "Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Drama",
                    Rating = "PG",
                    Price = 9.99M,
                    ImgPath = "~/img/other-side-of-heaven.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}

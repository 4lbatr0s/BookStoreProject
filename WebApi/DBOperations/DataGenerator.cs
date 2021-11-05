using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.InMemory;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any()) //database objesine erisiyoruz.
                {
                    return; //eger db de hiçbir şey yoksa ..
                }
                context.Books.AddRange(
                        new Book
                        {
                            GenreId = 1, //self growth
                        Title = "Deep Work",
                            PageCount = 300,
                            PublishDate = new DateTime(2018, 10, 12)
                        },
                    new Book
                    {
                        GenreId = 2, //sciencefiction
                    Title = "Dune",
                        PageCount = 500,
                        PublishDate = new DateTime(2001, 6, 21)
                    },
                    new Book
                    {
                        GenreId = 2, //novel
                    Title = "Roman Empire",
                        PageCount = 286,
                        PublishDate = new DateTime(1976, 2, 27)
                    }
                );

                context.SaveChanges(); //eklenenleri kaydet.
            }
        }
    }

}
using EF.Interceptors.Data;
using EF.Interceptors.Entities;

namespace EF.Interceptors.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateDatabase()
        {
            using var context = new ApplicationDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using var context = new ApplicationDbContext();
            context.Books.AddRange(new List<Book>() {
                new (){
                    Name = "he Half Known Life",
                    Author = " Emma Cline"
                },
                new (){
                    Name = "The Future",
                    Author = "Naomi Alderman"
                },
                new() {
                    Name = "Monsters",
                    Author = "Claire Dederer"
                },
                new() {
                    Name = "Blackouts",
                    Author = "Justin Torres"
                }
            });
        }

        public static void ShowBooks()
        {
            Console.WriteLine("Books");
            Console.WriteLine("-------------");

            using var context = new ApplicationDbContext();
            foreach (var book in context.Books)
                Console.WriteLine($"Id: {book.Id}, Title: {book.Name},  Author: {book.Author}");
        }
    }
}
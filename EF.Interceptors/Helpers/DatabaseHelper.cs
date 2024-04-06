using EF.Interceptors.Data;
using EF.Interceptors.Entities;
using Microsoft.EntityFrameworkCore;

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
                    Title = "he Half Known Life",
                    Author = new(){Name = "Emma Cline"}
                },
                new (){
                    Title = "The Future",
                    Author = new(){ Name = "Naomi Alderman" }
                },
                new() {
                    Title = "Monsters",
                    Author = new() { Name = "Claire Dederer" }
                },
                new() {
                    Title = "Blackouts",
                    Author = new() { Name = "Justin Torres" }
                }
            });

            context.SaveChanges();
        }

        public static void ShowBooks()
        {
            Console.WriteLine("Books");
            Console.WriteLine("-------------");

            using var context = new ApplicationDbContext();
            foreach (var book in context.Books.Include(x => x.Author))
                Console.WriteLine($"Id: {book.Id}, Title: {book.Title},  Author: {book.Author.Name}, IsDeleted: {book.IsDeleted}");
        }
    }
}
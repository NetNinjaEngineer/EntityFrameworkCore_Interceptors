using EF.Interceptors.Data;
using EF.Interceptors.Helpers;

namespace EF.Interceptors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.RecreateDatabase();

            DatabaseHelper.PopulateDatabase();

            Console.WriteLine("Before Delete Book #1");

            DatabaseHelper.ShowBooks();

            Console.WriteLine("After Delete Book #1");

            using var context = new ApplicationDbContext();
            var book = context.Books.FirstOrDefault(x => x.Id == 1);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }

            DatabaseHelper.ShowBooks();

            Console.ReadKey();
        }
    }
}

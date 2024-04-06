using EF.Interceptors.Entities.Contract;

namespace EF.Interceptors.Entities
{
    public class Book : ISoftDeletable
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal Price { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}

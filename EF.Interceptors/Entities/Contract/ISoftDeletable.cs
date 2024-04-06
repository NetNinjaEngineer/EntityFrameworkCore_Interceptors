namespace EF.Interceptors.Entities.Contract
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
            DateDeleted = DateTime.UtcNow;
        }

        public void UndoDelete()
        {
            IsDeleted = false;
            DateDeleted = null;
        }

    }
}

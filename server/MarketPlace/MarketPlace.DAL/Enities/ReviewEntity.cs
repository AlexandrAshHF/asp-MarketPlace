namespace MarketPlace.DAL.Enities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTime DateOfCreate { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}

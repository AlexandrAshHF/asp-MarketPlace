namespace MarketPlace.API.Contracts.ReviewDTO
{
    public class ReviewRequestDTO
    {
        public Guid? Id { get; set; }
        public Guid ProductId {  get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
    }
}

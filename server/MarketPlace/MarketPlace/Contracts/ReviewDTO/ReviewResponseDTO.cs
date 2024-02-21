namespace MarketPlace.API.Contracts.ReviewDTO
{
    public class ReviewResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}

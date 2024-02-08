using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Core.Models
{
    public class ReviewModel
    {
        public const int MAX_LENGTH_TEXT = 250;
        public const double MAX_VALUE_RATING = 5.0;
        public ReviewModel(Guid id, string um, string text, double rating, DateTime time, ProductModel product) 
        {
            Id = id;
            Username = um;
            Text = text;
            Rating = rating;
            DateOfCreate = time;
            Product = product;
        }
        public Guid Id { get; }
        public string Username { get; }
        public string Text { get; }
        public double Rating { get; }
        public DateTime DateOfCreate { get; }
        public ProductModel Product { get; }
        public static (ReviewModel, string) CreateReview(Guid id, string um, string text, double rating, DateTime time, ProductModel product)
        {
            string errorMessege = string.Empty;

            if (text.IsNullOrEmpty() || text.Length > MAX_LENGTH_TEXT)
                errorMessege = $"Comment cannot be empty or longer than {MAX_LENGTH_TEXT} characters";

            if (rating < 1 || rating > MAX_VALUE_RATING)
                errorMessege = $"Rating cannot be smaller 1 or bigger {MAX_VALUE_RATING} points";

            var review = new ReviewModel(id, um, text, rating, time, product);

            return (review, errorMessege);
        }
    }
}
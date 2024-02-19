using MarketPlace.API.Contracts.ReviewDTO;
using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.DataIntefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewsService _reviewsService;
        private IUsersService _usersService;
        public ReviewController(IReviewsService reviewsService, IUsersService usersService)
        {
            _reviewsService = reviewsService;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpGet("ReviewList")]
        public async Task<IActionResult> ReviewList(Guid productId)
        {
            var reviews = _reviewsService.GetReviewsByProductIdAsync(productId);

            return Ok(reviews);
        }

        [HttpPut("EntryReview")]
        public async Task<IActionResult> EntryReview(ReviewRequestDTO requestDTO)
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst("userId").Value ?? throw new ArgumentNullException("userClaims.FindFirst(\"userId\")", "Missing userId in Claims");

            var user = await _usersService.GetUserById(new Guid(userId));
            if (user == null)
                return BadRequest(user);

            var response = await _reviewsService.EntryReviewAsync(requestDTO.Id, user.Username, requestDTO.Text, requestDTO.Rating, requestDTO.ProductId);

            return response.Item2.IsNullOrEmpty() ? Ok(response.Item1) : BadRequest(response.Item2);
        }

        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var response = await _reviewsService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}
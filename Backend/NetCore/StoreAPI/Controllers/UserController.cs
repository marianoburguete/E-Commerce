using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(IConfiguration configuration, DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Get([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birth = user.Birth,
            };
        }

        [HttpGet]
        [Route("cartitemscount")]
        [Authorize]
        public async Task<ActionResult<int>> GetCartItemsCount([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return user.Cart.Items.Count;
        }

        [HttpGet]
        [Route("cart")]
        [Authorize]
        public async Task<ActionResult<Cart>> GetCart([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return user.Cart;
        }

        [HttpGet]
        [Route("orders")]
        [Authorize]
        public async Task<ActionResult<List<Order>>> GetOrders([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return user.Orders;
        }

        [HttpGet]
        [Route("questions")]
        [Authorize]
        public async Task<ActionResult<List<Question>>> GetQuestions([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return user.Questions;
        }

        [HttpGet]
        [Route("reviews")]
        [Authorize]
        public async Task<ActionResult<List<Review>>> GetReviews([FromRoute] int Id)
        {
            var user = await _context.Users.FindAsync(Id);

            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            return user.Reviews;
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromRoute] int Id, [FromBody] UserDto user)
        {
            var u = await _context.Users.FindAsync(Id);
            
            if (u == null)
            {
                return BadRequest("User not found");
            }
            
            _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete([FromRoute] int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(IConfiguration configuration, DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<Product>>> List([FromQuery] int userId)
        {
            var products = await _context.Products
                .Where(x => x.CreatorId == userId)
                .ToListAsync();

            return products;
        }

        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<Product>> Details([FromQuery] int productId)
        {
            var product = await _context.Products
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<List<Product>>> Post([FromBody] ProductDto product)
        {
            var user = await _context.Users
                .FindAsync(product.CreatorId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var newProduct = new Product
            {
                CreatedBy = user,
                CreatorId = product.CreatorId,
                Title = product.Title,
                Summary = product.Summary,
                Content = product.Content,
                StartsAt = product.StartsAt,
                EndsAt = product.EndsAt,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images,
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public ProductController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery]int userId)
        {
            var products = await _context.Products
                .Where(x => x.CreatorId == userId)
                .ToListAsync();
            
            return products;
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Post([FromBody]ProductDto product)
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

            return await Get(product.CreatorId);
        }
    }
}

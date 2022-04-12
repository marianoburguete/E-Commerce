using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(IConfiguration configuration, DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> List()
        {
            var products = await _context.Products
                .Where(x => x.StartsAt <= DateTime.Now && x.EndsAt >= DateTime.Now)
                .ToListAsync();

            return products;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<Product>>> Post([FromBody] ProductDto product)
        {
            var user = await _context.Users
                .FindAsync(product.CreatorId);
            if (user == null)
            {
                return NotFound("User not found");
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

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromRoute] int Id, [FromBody] ProductDto product)
        {
            var p = await _context.Products.FindAsync(Id);
            
            if (p == null)
            {
                return NotFound();
            }

            _context.Update(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete([FromRoute] int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("user")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> List([FromRoute] int userId)
        {
            var products = await _context.Products
                .Where(x => x.StartsAt <= DateTime.Now && x.EndsAt >= DateTime.Now)
                .Where(x => x.CreatorId == userId)
                .ToListAsync();

            return products;
        }

        [HttpGet]
        [Route("details")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> Details([FromRoute] int productId)
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

        [HttpGet]
        [Route("questions")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Question>>> GetQuestions([FromRoute] int productId, [FromRoute] bool answeredOnly)
        {
            var questions = await _context.Questions
                .Where(x => x.ProductId == productId)
                .Where(x => answeredOnly ? x.IsAnswered : true)
                .ToListAsync();
            
            return questions;
        }
    }
}

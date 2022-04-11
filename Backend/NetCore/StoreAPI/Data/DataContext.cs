using StoreAPI.Model;

namespace StoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasOne(e => e.Owner)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // No borro al usuario si se borra el carrito

            modelBuilder.Entity<CartItem>()
                .HasOne(e => e.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // No borro al producto si se borra la item del carrito

            modelBuilder.Entity<Order>()
                .HasOne(e => e.ShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // No borro la direccion de envio si se borra la orden

            modelBuilder.Entity<Order>()
                .HasOne(e => e.BillingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // No borro la direccion de facturacion si se borra la orden

            modelBuilder.Entity<OrderItem>()
                .HasOne(e => e.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // No borro al producto si se borra el item de la orden

            modelBuilder.Entity<Product>()
                .HasOne(e => e.CreatedBy)
                .WithMany(d => d.MyProducts)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.NoAction); // No borro al usuario si se borra el producto

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade); // Borro las imagenes si se borra el producto

            modelBuilder.Entity<Question>() // FIXED
                .HasOne(e => e.Product)
                .WithMany(d => d.Questions)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // No borro el producto si se borra la pregunta

            modelBuilder.Entity<Question>() // FIXED
                .HasOne(e => e.Author)
                .WithMany(d => d.Questions)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.NoAction); // No borro al usuario si se borra la pregunta

            modelBuilder.Entity<Review>() // FIXED
                .HasOne(e => e.Product)
                .WithMany(d => d.Reviews)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // No borro el producto si se borra la review

            modelBuilder.Entity<Review>() // FIXED
                .HasOne(e => e.Purchaser)
                .WithMany(d => d.Reviews)
                .HasForeignKey(e => e.PurchaserId)
                .OnDelete(DeleteBehavior.NoAction); // No borro al usuario si se borra la review

            modelBuilder.Entity<Review>()
                .HasOne(e => e.Order)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction); // No borro la orden si se borra la review
            
            modelBuilder.Entity<User>()
                .HasMany(e => e.BillingAddresses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade); // Borro las direcciones de facturacion si se borra el usuario

            modelBuilder.Entity<User>()
                .HasOne(e => e.Cart)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade); // Borro el carrito si se borra el usuario

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction); // No borro las ordenes si se borra el usuario

            modelBuilder.Entity<User>()
                .HasOne(e => e.DefaultBillingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(e => e.DefaultShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace IceParlourApp.Models
{
    public class BillingContext : DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        { }
        public DbSet<AddressMaster> AddressMaster { get; set; }
        public DbSet<PriceMaster> PriceMaster { get; set; }
        public DbSet<OrderMaster> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<IceCreamMaster> IceCreamMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceMaster>().HasData(
                new PriceMaster { PriceId = 1, Price = 16, Currency = "INR" },
                new PriceMaster { PriceId = 2, Price = 17, Currency = "INR" },
                new PriceMaster { PriceId = 3, Price = 18, Currency = "INR" },
                new PriceMaster { PriceId = 4, Price = 19, Currency = "INR" },
                new PriceMaster { PriceId = 5, Price = 20, Currency = "INR" },
                new PriceMaster { PriceId = 6, Price = 0, Currency = "INR" },
                new PriceMaster { PriceId = 7, Price = 0, Currency = "INR" },
                new PriceMaster { PriceId = 8, Price = 0, Currency = "INR" },
                new PriceMaster { PriceId = 9, Price = 0, Currency = "INR" });

            modelBuilder.Entity<IceCreamMaster>().HasData(
                new IceCreamMaster { IceCreamId = 1, Name = "Vanilla", PriceId = 1, IsToppings = false },
                new IceCreamMaster { IceCreamId = 2, Name = "Chocolate", PriceId = 2, IsToppings = false },
                new IceCreamMaster { IceCreamId = 3, Name = "Strawberry", PriceId = 3, IsToppings = false },
                new IceCreamMaster { IceCreamId = 4, Name = "Cookie and Cream", PriceId = 4, IsToppings = false },
                new IceCreamMaster { IceCreamId = 5, Name = "Hazel Nut ", PriceId = 5, IsToppings = false },
                new IceCreamMaster { IceCreamId = 6, Name = "Cookies", PriceId = 6, IsToppings = true },
                new IceCreamMaster { IceCreamId = 7, Name = "Fruits", PriceId = 7, IsToppings = true },
                new IceCreamMaster { IceCreamId = 8, Name = "Chocochips", PriceId = 8, IsToppings = true },
                new IceCreamMaster { IceCreamId = 9, Name = "Nuts", PriceId = 9, IsToppings = true });
        }
    }
}

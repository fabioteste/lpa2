using System.Data.Entity;
using LPA2.Domain.Entities;
using LPA2.Infra.Mappings;

namespace LPA2.Infra.Contexts
{
    public class LPA2DataContext : DbContext
    {
        public LPA2DataContext() : base(@"Server=DORMAMU;Database=LPA2; User ID=sa; Password=sqlexpress;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using LPA2.Domain.Entities;

namespace LPA2.Infra.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");
            HasKey(x => x.Id);
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.Quantity);
            HasRequired(x => x.Product);
        }
    }
}

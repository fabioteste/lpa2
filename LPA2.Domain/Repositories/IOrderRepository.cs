using LPA2.Domain.Entities;

namespace LPA2.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}

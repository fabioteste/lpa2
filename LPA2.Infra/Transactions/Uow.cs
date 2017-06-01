using LPA2.Infra.Contexts;

namespace LPA2.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly LPA2DataContext _context;

        public Uow(LPA2DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //Do nothing
        }
    }
}

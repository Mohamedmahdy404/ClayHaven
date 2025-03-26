using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repositories.Generic;

namespace DataAccessLayer.Repositories.OrderRepo
{
    public class OrderRepo : GenericRepo<Order> , IOrderRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }
    }
}

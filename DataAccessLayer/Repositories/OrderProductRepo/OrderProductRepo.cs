using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.OrderProductRepo
{
    public class OrderProductRepo : GenericRepo<OrderProduct>, IOrderProductRepo
    {
        private ApplicationDbContext _dbContext;
        public OrderProductRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderProduct>> GetAllDataWithProduct()
        {
            return await _dbContext.Set<OrderProduct>()
                .Include(op => op.Product) // Load related Product
                
                .ToListAsync();
        }
    }
}

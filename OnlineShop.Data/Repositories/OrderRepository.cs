using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    //OrderRepository, Repository<Order> sınıfının işlevselliğini miras alır ve
    //OnlineShopDbContext ile belirtilen veritabanı bağlamını kullanarak
    //Order varlıklarına ilişkin veritabanı işlemlerini gerçekleştirebilir
    public class OrderRepository :Repository<Order>, IOrderRepository
    {
        //OnlineShopDbContext nesnesini kullanarak Order varlıklarıyla ilgili veritabanı işlemlerini gerçekleştirebilir.
        public OrderRepository(OnlineShopDbContext context)
        : base(context)
        { }

        public async Task<IEnumerable<Order>> GetAllWithOrderAsync()
        {
            return await OnlineShopDbContext.Orders
                .ToListAsync();
        }

        public async Task<Order> GetWithOrderByIdAsync(int OrderID)
        {
            // ID'si verilen orderı döndüren bir metod
            return await OnlineShopDbContext.Orders
            .SingleOrDefaultAsync(o => o.OrderID == OrderID);
        }

        public async Task<IEnumerable<Order>> GetAllWithOrderByCustomerIDAsync(int CustomerID)
        {
            return await OnlineShopDbContext.Orders
            .Where(o => o.CustomerID == CustomerID)
            .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }

    }

}

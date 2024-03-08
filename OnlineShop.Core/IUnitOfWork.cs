using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{

    /*
     * IUnitOfWork arabirimi, birim işlemlerini gruplamak ve yönetmek için kullanılır. 
     * Bu, birden çok repository üzerinde aynı işlemi gerçekleştirmek ve işlemleri tek bir işlem olarak işlemek için kullanışlıdır. 
     * Bu, veritabanı işlemlerini daha tutarlı hale getirmeye ve uygulama mantığını daha kolay yönetmeye yardımcı olur.
     */

    //IDisposable kaynak yönetimi için kullanılan bir arabirimdir. 
    //bir nesnenin kaynakları serbest bırakmak için bir yöntem sağlar.
    public interface IUnitOfWork : IDisposable
    {
        //: Adres bilgisi repository'sine erişim sağlayan bir özellik.
        //Bu özellik, adres bilgisi işlemlerini gerçekleştirmek için kullanılır.
        IAddressInformationRepository AddressInformations { get; }
        ICreditCardRepository CreditCards { get; }
        ICustomerRepository Customers { get; }
        IOrderHistoryRepository OrderHistories { get; }
        IOrderRepository Orders { get; }
        IPaymentInformationRepository PaymentInformations { get; }
        IProductRepository Products { get; }
        IPromotionRepository Promotions { get; }
        IReturnRepository Returns { get; }
        IShoppingCartRepository ShoppingCarts { get; }
        IStockRepository Stocks { get; }

        // Birim işleminin (transaction) tüm değişikliklerini veritabanına uygulamak için kullanılan bir metot. 
        Task<int> CommitAsync();

    }
}

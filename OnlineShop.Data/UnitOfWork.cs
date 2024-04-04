using OnlineShop.Core;
using OnlineShop.Core.Repositories;
using OnlineShop.Data.Repositories;

namespace OnlineShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext _context;
        private AddressInformationRepository _addressInformationRepository;
        private CreditCardRepository _creditCardRepository;
        private CustomerRepository _customerRepository;
        private OrderRepository _orderRepository;
        private PaymentInformationRepository _paymentInformationRepository;
        private ProductRepository _productRepository;
        private ReturnedProductRepository _returnedProductRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private StockRepository _stockRepository;

        public UnitOfWork(OnlineShopDbContext context)
        {
            this._context = context;
        }

        public IAddressInformationRepository AddressInformations => _addressInformationRepository = _addressInformationRepository ?? new AddressInformationRepository(_context);
        public ICreditCardRepository CreditCards => _creditCardRepository = _creditCardRepository ?? new CreditCardRepository(_context);
        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);
        public IPaymentInformationRepository PaymentInformations => _paymentInformationRepository = _paymentInformationRepository ?? new PaymentInformationRepository(_context);
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);
        public IReturnedProductRepository ReturnedProducts => _returnedProductRepository = _returnedProductRepository ?? new ReturnedProductRepository(_context);
        public IShoppingCartRepository ShoppingCarts => _shoppingCartRepository = _shoppingCartRepository ?? new ShoppingCartRepository(_context);
        public IStockRepository Stocks => _stockRepository = _stockRepository ?? new StockRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            //CommitAsync().GetAwaiter().GetResult();
            _context.Dispose();
        }



    }
}

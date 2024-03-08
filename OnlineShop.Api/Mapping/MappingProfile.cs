using AutoMapper;
using OnlineShop.Api.DTO;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Models.StockManagement;

namespace OnlineShop.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Domian to Resource
            CreateMap<AddressInformation, AddressInformationDTO>();
            CreateMap<CreditCard, CreditCardDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderHistory, OrderHistoryDTO>();
            CreateMap<PaymentInformation, PaymentInformationDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Promotion, PromotionDTO>();
            CreateMap<Return, ReturnDTO>();
            CreateMap<ShoppingCart, ShoppingCartDTO>();
            CreateMap<Stock, StockDTO>();

            //Resource to Domain
            CreateMap<AddressInformationDTO, AddressInformation>();
            CreateMap<CreditCardDTO, CreditCard>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderHistoryDTO, OrderHistory>();
            CreateMap<PaymentInformationDTO, PaymentInformation>();
            CreateMap<ProductDTO, Product>();
            CreateMap<PromotionDTO, Promotion>();
            CreateMap<ReturnDTO, Return>();
            CreateMap<ShoppingCartDTO, ShoppingCart>();
            CreateMap<StockDTO, Stock>();

            //Save 
            //SaveProductDTO sınıfını Product sınıfına dönüştüren bir eşleştirme (mapping) oluşturuyor
            CreateMap<SaveProductDTO, Product>();
            CreateMap<SaveAddressInformationDTO, AddressInformation>();
            CreateMap<SaveCreditCardDTO, CreditCard>();
            CreateMap<SaveCustomerDTO, Customer>();
            CreateMap<SaveOrderDTO, Order>();
            CreateMap<SaveOrderHistoryDTO, OrderHistory>();
            CreateMap<SavePaymentInformationDTO, PaymentInformation>();
        }
    }
}

using AutoMapper;
using OnlineShop.Api.DTO;
using OnlineShop.Core.Models;

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
            CreateMap<PaymentInformation, PaymentInformationDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ReturnedProduct, ReturnedProductDTO>();
            CreateMap<ShoppingCart, ShoppingCartDTO>();
            CreateMap<Stock, StockDTO>();

            //Resource to Domain
            CreateMap<AddressInformationDTO, AddressInformation>();
            CreateMap<CreditCardDTO, CreditCard>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<OrderDTO, Order>();
            CreateMap<PaymentInformationDTO, PaymentInformation>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ReturnedProductDTO, ReturnedProduct>();
            CreateMap<ShoppingCartDTO, ShoppingCart>();
            CreateMap<StockDTO, Stock>();

            //Save 
            //SaveProductDTO sınıfını Product sınıfına dönüştüren bir eşleştirme (mapping) oluşturuyor
            CreateMap<SaveProductDTO, Product>();
            CreateMap<SaveAddressInformationDTO, AddressInformation>();
            CreateMap<SaveCreditCardDTO, CreditCard>();
            CreateMap<SaveCustomerDTO, Customer>();
            CreateMap<SaveOrderDTO, Order>();
            CreateMap<SavePaymentInformationDTO, PaymentInformation>();
            CreateMap<SaveReturnedProductDTO, ReturnedProduct>();
            CreateMap<SaveShoppingCartDTO, ShoppingCart>();
            CreateMap<SaveStockDTO, Stock>();
        }
    }
}

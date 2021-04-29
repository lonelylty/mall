using Heals.CSX.Mall.Users.Dtos;
//using Heals.CSX.Mall.Web.Pages.Users.AppUser.ViewModels;
using Heals.CSX.Mall.Products.Dtos;
using Heals.CSX.Mall.Web.Pages.Products.Product.ViewModels;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Web.Pages.Orders.ProductItemOrdered.ViewModels;
using Heals.CSX.Mall.Web.Pages.Orders.OrderItem.ViewModels;
using Heals.CSX.Mall.Addresses.Dtos;
using Heals.CSX.Mall.Web.Pages.Addresses.Address.ViewModels;
using Heals.CSX.Mall.Web.Pages.Orders.Order.ViewModels;
using Heals.CSX.Mall.Carts.Dtos;
using Heals.CSX.Mall.Web.Pages.Carts.CartItem.ViewModels;
using Heals.CSX.Mall.Carts.Dtos;
using Heals.CSX.Mall.Web.Pages.Carts.Cart.ViewModels;
using AutoMapper;

namespace Heals.CSX.Mall.Web
{
    public class MallWebAutoMapperProfile : Profile
    {
        public MallWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            //CreateMap<AppUserDto, CreateEditAppUserViewModel>();
            //CreateMap<CreateEditAppUserViewModel, CreateUpdateAppUserDto>();
            CreateMap<ProductDto, CreateEditProductViewModel>();
            CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
            CreateMap<ProductItemOrderedDto, CreateEditProductItemOrderedViewModel>();
            CreateMap<CreateEditProductItemOrderedViewModel, CreateUpdateProductItemOrderedDto>();
            CreateMap<OrderItemDto, CreateEditOrderItemViewModel>();
            CreateMap<CreateEditOrderItemViewModel, CreateUpdateOrderItemDto>();
            CreateMap<AddressDto, CreateEditAddressViewModel>();
            CreateMap<CreateEditAddressViewModel, CreateUpdateAddressDto>();
            CreateMap<OrderDto, CreateEditOrderViewModel>();
            CreateMap<CreateEditOrderViewModel, CreateOrderDto>();
            CreateMap<CartItemDto, CreateEditCartItemViewModel>();
            CreateMap<CreateEditCartItemViewModel, CreateUpdateCartItemDto>();
            CreateMap<CartDto, CreateEditCartViewModel>();
            CreateMap<CreateEditCartViewModel, CreateUpdateCartDto>();
        }
    }
}

using Heals.CSX.Mall.Users;
using Heals.CSX.Mall.Users.Dtos;
using Heals.CSX.Mall.Products;
using Heals.CSX.Mall.Products.Dtos;
using AutoMapper;
using Heals.CSX.Mall.Orders;
using Heals.CSX.Mall.Orders.Dtos;
using Heals.CSX.Mall.Addresses;
using Heals.CSX.Mall.Addresses.Dtos;
using System.IO;
using Heals.CSX.Mall.Carts;
using Heals.CSX.Mall.Carts.Dtos;
using System;

namespace Heals.CSX.Mall
{
    public class MallApplicationAutoMapperProfile : Profile
    {
        public MallApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<MallUser, AppUserDto>();
            CreateMap<CreateUpdateAppUserDto, AppUser>(MemberList.Source);
            //CreateMap<CreateUpdateAppUserDto, MallUser>(MemberList.Source);

            CreateMap<Product, ProductDto>().ForMember(d => d.PictureUri,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.PictureUri) ? "" : $"{MallConsts.MallSiteDomain}/{MallConsts.MallSitePicturePath}/{src.PictureUri}"));
            CreateMap<CreateUpdateProductDto, Product>(MemberList.Source);
            CreateMap<ProductItemOrdered, ProductItemOrderedDto>().ForMember(d => d.ProductNo,
                opt => opt.MapFrom(src => src.ProductSeqId));
            CreateMap<CreateUpdateProductItemOrderedDto, ProductItemOrdered>(MemberList.Source).ForMember(d => d.ProductSeqId,
                opt => opt.MapFrom(src => src.ProductNo));
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<CreateUpdateOrderItemDto, OrderItem>(MemberList.Source);
            CreateMap<Address, AddressDto>();
            CreateMap<CreateUpdateAddressDto, Address>(MemberList.Source);
            CreateMap<Order, OrderDto>().ForMember(d => d.TargetDeliveryDate,
                opt => opt.MapFrom(src => src.TargetDeliveryDate ?? ((DateTimeOffset)src.TargetDeliveryDate).UtcDateTime));
            CreateMap<CreateOrderDto, Order>(MemberList.Source);
            CreateMap<CartItem, CartItemDto>().ForMember(d => d.ProductDto,opt => opt.MapFrom(src => src.Product));
            CreateMap<CreateUpdateCartItemDto, CartItem>(MemberList.Source);
            CreateMap<Cart, CartDto>();
            CreateMap<CreateUpdateCartDto, Cart>(MemberList.Source);
        }
    }
}

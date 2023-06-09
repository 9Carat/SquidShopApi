﻿using AutoMapper;
using SquidShopApi.Models;
using SquidShopApi.Models.DTO;

namespace SquidShopApi
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
			CreateMap<Product, ProductDTO>().ReverseMap();
			CreateMap<Product, ProductUpdateDTO>().ReverseMap();
			CreateMap<Product, ProductCreateDTO>().ReverseMap();

			CreateMap<Category, CategoryDTO>().ReverseMap();
			CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

			CreateMap<User, UserDTO>().ReverseMap();
			CreateMap<User, UserUpdateDTO>().ReverseMap();
			CreateMap<User, UserCreateDTO>().ReverseMap();

			CreateMap<Order, OrderDTO>().ReverseMap();
			CreateMap<Order, OrderCreateDTO>().ReverseMap();
			CreateMap<OrderList, OrderListDTO>().ReverseMap();
			CreateMap<OrderList, OrderListUpdateDTO>().ReverseMap();

			CreateMap<Promotion, PromotionDTO>().ReverseMap();
		}
    }
}

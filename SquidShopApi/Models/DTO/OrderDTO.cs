﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SquidShopApi.Models.DTO
{
	public class OrderDTO
	{
		public int OrderId { get; set; }
		[ForeignKey("Users")]
		public int FK_UserId { get; set; }
		public User Users { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public bool OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public virtual ICollection<OrderList> OrderLists { get; set; }//nav
    }
}

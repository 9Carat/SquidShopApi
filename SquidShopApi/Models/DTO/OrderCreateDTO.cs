using System.ComponentModel.DataAnnotations.Schema;

namespace SquidShopApi.Models.DTO
{
	public class OrderCreateDTO
	{
		public int OrderId { get; set; }
		public int FK_UserId { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ShippingAddress { get; set; }
        public bool OrderStatus { get; set; }
	}
}

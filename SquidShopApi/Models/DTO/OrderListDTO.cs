using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SquidShopApi.Models.DTO
{
	public class OrderListDTO
	{
		public int OrderListId { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		[ForeignKey("Products")]
		public int FK_ProductId { get; set; }
		public Product Product { get; set; }
		[ForeignKey("Orders")]
		public int FK_OrderId { get; set; }
		public Order Orders { get; set; }
	}
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SquidShopApi.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		[ForeignKey("Users")]
		public int FK_UserId { get; set; }
		public User Users { get; set; }//nav
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[StringLength(75)]
		public string ShippingAddress { get; set; }
		public bool OrderStatus { get; set; }
		public virtual ICollection<OrderList> OrderLists { get; set; }//nav
	}
}

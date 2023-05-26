using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SquidShopApi.Models.DTO
{
	public class ProductDTO
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int InStock { get; set; }
		public double UnitPrice { get; set; }
		public string ImageName { get; set; }
		[ForeignKey("Categories")]
		public int FK_CategoryId { get; set; }
		public Category Categories { get; set; }
		public virtual ICollection<OrderList> OrderLists { get; set; }//nav
    }
}

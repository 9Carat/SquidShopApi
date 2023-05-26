using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SquidShopApi.Models.DTO
{
	public class ProductCreateDTO
	{
		public string ProductName { get; set; }
		public int InStock { get; set; }
		public double UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public double DiscountUnitPrice { get; set; } 
        public string ImageName { get; set; }
		public int FK_CategoryId { get; set; }
    }
}

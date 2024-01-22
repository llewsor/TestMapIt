using System.ComponentModel;

namespace TestMapIT.Models
{
	public class ItemMasterDTO
	{
		public string? Code { get; set; }

		[DisplayName("Item Code")]
		public string ItemCode { get; set; }

		public string Description { get; set; }

		public bool Active { get; set; }

		[DisplayName("Customer Description")]
		public string? CustomerDescription { get; set; }

		[DisplayName("Sales")]
		public bool SalesItem { get; set; }

		[DisplayName("Stock")]
		public bool StockItem { get; set; }

		[DisplayName("Purchased")]
		public bool PurchasedItem { get; set; }

		public string Barcode { get; set; }

		[DisplayName("Manage Item By")]
		public int ManageItemBy { get; set; }

		[DisplayName("Minimum Inventory")]
		public decimal MinimumInventory { get; set; }

		[DisplayName("Maximum Inventory")]
		public decimal MaximumInventory { get; set; }

		public string? Remarks { get; set; }

		[DisplayName("Image")]
		public string ImagePath { get; set; }

		public IFormFile? Image { get; set; }
	}
}

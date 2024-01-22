namespace TestMapIT.Models
{
    public class ItemMasterListViewDTO
	{
		public string ItemCode { get; set; }

		public string Description { get; set; }

		public bool Active { get; set; }

		public bool SalesItem { get; set; }

		public bool StockItem { get; set; }

		public bool PurchasedItem { get; set; }

        public int ManageItemBy { get; set; }

  //      public decimal MinimumInventory { get; set; }

		//public decimal MaximumInventory { get; set; }

		//public string ImagePath { get; set; }
	}
}

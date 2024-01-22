using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities.Models
{
    [Table("ItemMaster")]
    public class ItemMaster
    {
        [Key]
        [Required(ErrorMessage = "ItemCode required")]
        [MaxLength(25)]
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }

        [MaxLength(300)]
        [DisplayName("Customer Description")]
        public string? CustomerDescription { get; set; }

        [Required]
        [DisplayName("Sales Item")]
        public bool SalesItem { get; set; }

        [Required]
        [DisplayName("Stock Item")]
        public bool StockItem { get; set; }

        [Required]
        [DisplayName("Purchased Item")]
        public bool PurchasedItem { get; set; }

        [Required]
        [MaxLength(100)]
        public string Barcode { get; set; }

        [Required]
        [DisplayName("Manage Item By")]
        public ManageItemBys ManageItemBy { get; set; }

        [Required]
        [DisplayName("Minimum Inventory")]
        public decimal MinimumInventory { get; set; }

        [Required]
        [DisplayName("Maximum Inventory")]
        public decimal MaximumInventory { get; set; }

        [DisplayFormat(NullDisplayText = "No remarks")]
        public string? Remarks { get; set; }

        [Required]
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public enum ManageItemBys { None = 0, Serial = 1, Batch = 2 }

    }
}

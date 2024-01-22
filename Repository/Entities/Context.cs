using Microsoft.EntityFrameworkCore;
using Repository.Entities.Models;

namespace Repository.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<ItemMaster> ItemMasters { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ItemMaster>().ToTable("ItemMaster");
			//modelBuilder.Entity<ItemMaster>().HasIndex(e => e.ItemCode).IsUnique();
			modelBuilder.Entity<ItemMaster>().HasData(
				new ItemMaster
				{
					ItemCode = Guid.NewGuid().ToString().Substring(0, 25),
					Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.",
					Active = true,
					SalesItem = false,
					StockItem = true,
					PurchasedItem = false,
					Barcode = "070590708898824485667995070969",
					ManageItemBy = ItemMaster.ManageItemBys.None,
					MinimumInventory = 0,
					MaximumInventory = 100,
					ImagePath = "374ad050-7773-4f42-86d2-fbb66273f13b.png"
				},
				new ItemMaster
				{
					ItemCode = Guid.NewGuid().ToString().Substring(0, 25),
					Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.",
					Active = true,
					SalesItem = false,
					StockItem = true,
					PurchasedItem = false,
					Barcode = "070590708898824485667995070969",
					ManageItemBy = ItemMaster.ManageItemBys.None,
					MinimumInventory = 0,
					MaximumInventory = 100,
					ImagePath = "58108b9a-e114-4d02-9967-f8a00e42ef59.png"
				},
				new ItemMaster
				{
					ItemCode = Guid.NewGuid().ToString().Substring(0, 25),
					Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.",
					Active = true,
					CustomerDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.",
					SalesItem = false,
					StockItem = true,
					PurchasedItem = false,
					Barcode = "070590708898824485667995070969",
					ManageItemBy = ItemMaster.ManageItemBys.Serial,
					MinimumInventory = 0,
					MaximumInventory = 100,
					Remarks = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus.",
					ImagePath = "9e9ef54a-f995-4da1-95ee-3456414d28fb.png"
				});
		}
	}
}

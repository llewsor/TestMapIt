using Repository.Entities;
using Repository.Entities.Models;
using Repository.Interfaces;

namespace Repository
{
	public class ItemMasterRepository: BaseRepository<ItemMaster>, IItemMasterRepository
    {
		public ItemMasterRepository(Context context) : base(context) { }
	}
}

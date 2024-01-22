using Repository.Entities;
using Repository.Interfaces;

namespace Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private Context _context;
		private IItemMasterRepository _itemMaster;

		public RepositoryWrapper(Context context)
		{
			_context = context;
		}

		public IItemMasterRepository ItemMaster
		{
			get
			{
				if (_itemMaster == null)
					_itemMaster = new ItemMasterRepository(_context);

				return _itemMaster;
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}

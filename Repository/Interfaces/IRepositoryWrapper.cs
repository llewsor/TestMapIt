namespace Repository.Interfaces
{
	public interface IRepositoryWrapper
	{
		IItemMasterRepository ItemMaster {  get; }
		void Save();
	}
}

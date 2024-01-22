namespace TestMapIT.Workers
{
	public interface IFileWorker
	{
		public Tuple<int, string> SaveImage(IFormFile imageFile);
		public void DeleteImage(string imageFileName);
	}
}

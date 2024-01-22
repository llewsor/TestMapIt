namespace TestMapIT.Workers
{
	public class FileWorker : IFileWorker
	{

		private IWebHostEnvironment environment;

		public FileWorker(IWebHostEnvironment env)
		{
			environment = env;
		}

		public Tuple<int, string> SaveImage(IFormFile imageFile)
		{
			try
			{
				var folderName = "uploads";
				var path = Path.Combine(environment.WebRootPath, folderName);

				if (File.Exists(Path.Combine(path, imageFile.FileName)))
				{
					return new Tuple<int, string>(1, imageFile.FileName);
				}

				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}

				var ext = Path.GetExtension(imageFile.FileName);
				var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
				if (!allowedExtensions.Contains(ext))
				{
					return new Tuple<int, string>(0, string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions)));
				}

				var newFileName = Guid.NewGuid().ToString() + ext;
				var stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create);
				imageFile.CopyTo(stream);
				stream.Close();
				return new Tuple<int, string>(1, newFileName);
			}
			catch (Exception ex)
			{
				return new Tuple<int, string>(0, "Error has occured! " + ex.Message);
			}
		}

		public void DeleteImage(string imageFileName)
		{
			var path = Path.Combine(this.environment.WebRootPath, "Uploads\\", imageFileName);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}
}

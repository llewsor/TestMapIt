using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Repository.Entities.Models;
using Repository.Interfaces;
using TestMapIT.Models;
using TestMapIT.Workers;

namespace TestMapIT.Controllers
{
    public class ItemMasterController : Controller
	{
		private readonly IRepositoryWrapper _repo;
		private readonly IMapper _mapper;
        private readonly IFileWorker _file;
        private readonly IStringLocalizer<ItemMasterController> _local;

		public ItemMasterController(IRepositoryWrapper repo, IMapper mapper, IFileWorker file, IStringLocalizer<ItemMasterController> local)
		{
			_repo = repo;
			_mapper = mapper;
            _file = file;
            _local = local;
		}

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.ItemMaster.FindAll().Select(_mapper.Map<ItemMaster, ItemMasterListViewDTO>).ToList());
        }

        [HttpGet]
        public IActionResult Item(string itemCode)
        {
            var temp = _repo.ItemMaster.FindByCondition(x => x.ItemCode == itemCode).SingleOrDefault();
			return View(_mapper.Map<ItemMasterDTO>(temp) ?? new ItemMasterDTO());
        }

        [HttpPost]
        public IActionResult Save([FromForm]ItemMasterDTO item)
        {
            string _imagePath = string.Empty;
            try
			{
				if (item == null) return BadRequest();
				//if (item == null || item.Image == null) return BadRequest();

				if (!string.IsNullOrEmpty(item.ImagePath))
                    item.ImagePath = item.ImagePath.TrimStart("~/Uploads/".ToCharArray());

                ItemMaster? search = _repo.ItemMaster.FindByCondition(x => x.ItemCode == item.ItemCode).SingleOrDefault();

                if (item.Code?.ToLower() != item.ItemCode.ToLower() && search != null)
                    return BadRequest(_local["ItemCodeAlreadyInUse"].Value);

                if (!string.IsNullOrEmpty(item.ImagePath) && item.Image != null && item.Image.FileName != item.ImagePath)
                    _file.DeleteImage(item.ImagePath);

                if (item.Image != null)
                {
                    var fileResult = _file.SaveImage(item.Image);

                    if (fileResult.Item1 == 0)
                    {
                        return BadRequest(fileResult.Item2);
                    }

                    item.ImagePath = fileResult.Item2;
                }

                _imagePath = item.ImagePath;

				if (!string.IsNullOrEmpty(item.Code))
                {
					ItemMaster? original = _repo.ItemMaster.FindByCondition(x => x.ItemCode == item.Code).SingleOrDefault();

                    if (original != null)
                    {
                        if (item.Code?.ToLower() != item.ItemCode.ToLower())
                        {
                            _repo.ItemMaster.Delete(original);
                            var tttt = _mapper.Map<ItemMaster>(item);

							_repo.ItemMaster.Add(tttt);
                        }
                        else
                        {
                            original = _mapper.Map<ItemMaster>(item);
							_repo.ItemMaster.Update(original);
                        }
                    }
				}
                else
                {
                    var rrr = _mapper.Map<ItemMaster>(item);
					_repo.ItemMaster.Add(rrr);
				}
                
                _repo.Save();
                return Json(new { Success = true, message = _local["ItemSavedSuccessfully"].Value, imagePath = _imagePath });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string itemCode)
        {
            try
            {
                ItemMaster? original = _repo.ItemMaster.FindByCondition(x => x.ItemCode == itemCode).SingleOrDefault();

                if (original == null)
                    return NotFound();

                _file.DeleteImage(original.ImagePath);
                _repo.ItemMaster.Delete(original);
                _repo.Save();
                return Ok(new CommonResponse(_local["DeletedSuccessfully"].Value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

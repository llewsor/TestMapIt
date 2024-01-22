using AutoMapper;
using Humanizer;
using Repository.Entities.Models;
using TestMapIT.Models;

namespace TestMapIT
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<ItemMaster, ItemMasterListViewDTO>()
				.ForMember(x => x.Description, e => e.MapFrom(c => c.Description.Length >= 50 ? c.Description.Truncate(47) + "..." : c.Description));
			CreateMap<ItemMaster, ItemMasterDTO>()
				.ForMember(x=>x.ImagePath, e => e.MapFrom(c => "~/Uploads/" + c.ImagePath));
			CreateMap<ItemMasterDTO, ItemMaster>()
				.ForMember(x => x.ImagePath, e => e.MapFrom(c => c.ImagePath.TrimStart("~/Uploads/".ToCharArray())));
		}
	}
}

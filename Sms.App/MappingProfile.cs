using AutoMapper;
using Sms.App.Models.Master;
using Sms.App.Models.Users;
using Sms.BusinessObjects.Master;
using Sms.BusinessObjects.User;

namespace Sms.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginModel, LoginBo>().ReverseMap();
            CreateMap<LoginDetailModel, LoginDetailBo>().ReverseMap();

            CreateMap<ReligionModel, ReligionBo>().ReverseMap();
            CreateMap<RoleModel, RoleBo>();
        }
    }
}
using AutoMapper;
using dailybook.Models;
using dailybook.ViewModels;

namespace dailybook.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterVM, Customer>();
            //.ForMember(cus => cus.Fullname, option => option.MapFrom(RegisterVM => RegisterVM.Fullname))
            //.ReverseMap();
        }
    }
}

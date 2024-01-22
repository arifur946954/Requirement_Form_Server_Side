using AutoMapper;
using RequirementForm.DTO;
using RequirementForm.Models;

namespace RequirementForm
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<PresentAddressDTO, Presentaddress>();
            CreateMap<ParmanentAddressDTO, Parmanentaddress>();
            CreateMap<ExperienceDTO, Experience>();
            CreateMap<AccademicQulificatoinDTO, Accademicqulification>();

        }
    }
}

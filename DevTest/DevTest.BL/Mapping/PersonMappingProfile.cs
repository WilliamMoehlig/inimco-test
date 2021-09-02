using AutoMapper;
using DevTest.BL.Persons.Models;
using DevTest.Domain;
using SocialAccount = DevTest.Domain.SocialAccount;

namespace DevTest.BL.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<string[], Person>().ForMember(dest => dest.SocialSkills, m => m.MapFrom(src => src));
            CreateMap<string, SocialSkill>().ForMember(dest => dest.Description, m => m.MapFrom(src => src));
            CreateMap<Persons.Models.SocialAccount, SocialAccount>();

            CreateMap<CreatePersonRequest, Person>()
                .IncludeMembers(s => s.SocialSkills)
                .ForMember(dest => dest.SocialAccounts, m => m.MapFrom(src => src.SocialAccounts));
        }
    }
}

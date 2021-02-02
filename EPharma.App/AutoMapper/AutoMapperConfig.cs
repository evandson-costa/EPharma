using AutoMapper;
using EPharma.App.ViewModels;
using EPharma.Business.Models;

namespace EPharma.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Plano, PlanoViewModel>().ReverseMap();
        }
    }
}

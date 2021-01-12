using AutoMapper;
using OSlight.App.ViewModels;
using OSlight.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSlight.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<AbrirOS, AbrirOSViewModel>().ReverseMap();
            CreateMap<FecharOS, FecharOSViewModel>().ReverseMap();
        }
    }
}

using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.SubCategoria;
using API.Domain.DTOs.User;
using API.Domain.DTOs.Usuario;
using API.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
            CreateMap<CategoriaCreateInput, Categoria>().ReverseMap();

            CreateMap<SubCategoriaDto, SubCategoria>().ReverseMap();
            CreateMap<SubCategoriaCreateInput, SubCategoria>().ReverseMap();

            CreateMap<UserDtoInput, User>().ReverseMap();
            CreateMap<UserDtoOutput, User>().ReverseMap();

            CreateMap<UsuarioDto, Usuario>().ReverseMap();

        }
    }
}

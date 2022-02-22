using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.SubCategoria;
using API.Domain.DTOs.User;
using API.Domain.DTOs.Usuario;
using API.Domain.DTOs.TelefoneUsuario;
using API.Domain.DTOs.TipoChamado;
using API.Domain.DTOs.Chamado;
using API.Domain.DTOs.ChamadoCriticidade;
using API.Domain.DTOs.ChamadoStatus;
using API.Domain.DTOs.ComentarioPerfil;
using API.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using API.Domain.DTOs.ContatoPrestador;
using API.Domain.DTOs.ItemChamado;

namespace API.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
            CreateMap<CategoriaCreateInput, Categoria>().ReverseMap();
            CreateMap<CategoriaUpdateInput, Categoria>().ReverseMap();

            CreateMap<SubCategoriaDto, SubCategoria>().ReverseMap();
            CreateMap<SubCategoriaCreateInput, SubCategoria>().ReverseMap();
            CreateMap<SubCategoriaUpdateInput, SubCategoria>().ReverseMap();

            CreateMap<UserDtoInput, User>().ReverseMap();
            CreateMap<UserDtoOutput, User>().ReverseMap();

            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<UsuarioCreateInput, Usuario>().ReverseMap();
            CreateMap<UsuarioUpdateInput, Usuario>().ReverseMap();

            CreateMap<TelefoneUsuarioDto, TelefoneUsuario>().ReverseMap();

            CreateMap<TipoChamadoDto, TipoChamado>().ReverseMap();
            CreateMap<TipoChamadoCreateInput, TipoChamado>().ReverseMap();
            CreateMap<TipoChamadoUpdateInput, TipoChamado>().ReverseMap();

            CreateMap<ChamadoDto, Chamado>().ReverseMap();
            CreateMap<ChamadoCreateInput, Chamado>().ReverseMap();
            CreateMap<ChamadoUpdateInput, Chamado>().ReverseMap();

            CreateMap<ChamadoCriticidadeDto, ChamadoCriticidade>().ReverseMap();

            CreateMap<ChamadoStatusDto, ChamadoStatus>().ReverseMap();
            CreateMap<ComentarioPerfilDto, ComentarioPerfil>().ReverseMap();

            CreateMap<ComentarioPerfilDto, ComentarioPerfil>().ReverseMap();

            CreateMap<ContatoPrestadorDto, ContatoPrestador>().ReverseMap();

            CreateMap<ItemChamadoDto, ItemChamado>().ReverseMap();

            CreateMap<SubCategoriaPrestadorDto, SubCategoriaPrestador>().ReverseMap();
           

        }
    }
}

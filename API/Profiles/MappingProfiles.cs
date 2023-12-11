using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() // Remember adding : Profile in the class
        { // 2611
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<CategoriaPersona, CategoriaPersonaDto>().ReverseMap();
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<ContactoPersona, ContactoPersonaDto>().ReverseMap();
            CreateMap<Contrato, ContratoDto>().ReverseMap();
            CreateMap<DireccionPersona, DepartamentoDto>().ReverseMap();
            CreateMap<DireccionPersona, DireccionPersonaDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<Programacion, ProgramacionDto>().ReverseMap();
            CreateMap<TipoContacto, TipoContactoDto>().ReverseMap();
            CreateMap<TipoDireccion, TipoDireccionDto>().ReverseMap();
            CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
            CreateMap<Turnos, TurnosDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserRegisterDto, UserDto>().ReverseMap();
        }
    }
}
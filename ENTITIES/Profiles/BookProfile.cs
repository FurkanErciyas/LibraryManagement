using AutoMapper;
using ENTITIES.DTO.CreateDTO;
using ENTITIES.DTO.DeleteDTO;
using ENTITIES.DTO.UpdateDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookUpdateDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(src => src.BookType))
                .ForMember(dest => dest.BookLanguage, opt => opt.MapFrom(src => src.BookLanguage));

            CreateMap<BookCreateDTO, Book>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(src => src.BookType))
                .ForMember(dest => dest.BookLanguage, opt => opt.MapFrom(src => src.BookLanguage));

            CreateMap<BookDeleteDTO, Book>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DataStatus, opt => opt.MapFrom(src => src.DataStatus))
                .ForMember(dest => dest.DeletedDate, opt => opt.MapFrom(src => src.DeletedDate));

        }
    }
}

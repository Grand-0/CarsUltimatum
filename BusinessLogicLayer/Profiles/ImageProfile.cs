
using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageDTO, Image>();
            CreateMap<Image, ImageDTO>();
        }
    }
}

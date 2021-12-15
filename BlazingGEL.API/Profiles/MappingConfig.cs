using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.CoreBusiness.Models;

namespace BlazingGEL.API.Profiles;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingCongif = new MapperConfiguration(config =>
        {
            // Sources -> Targets
            config.CreateMap<PostDto, Post>().ReverseMap();
            config.CreateMap<CategoryDto, Category>().ReverseMap();
        });

        return mappingCongif;
    }
}

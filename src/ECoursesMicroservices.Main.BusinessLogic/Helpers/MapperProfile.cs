using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using ECoursesMicroservices.Main.Data.Entities;

namespace ECoursesMicroservices.Main.BusinessLogic.Helpers;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<TagDto, Tag>()
            .ReverseMap();

        CreateMap<CategoryDto, Category>()
            .ReverseMap();

        CreateMap<AuthorDto, Author>()
            .ReverseMap();

        CreateMap<CourseDto, Course>()
            .ReverseMap();
    }
}

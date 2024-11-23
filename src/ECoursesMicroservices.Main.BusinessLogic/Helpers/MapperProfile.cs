using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.Data.Entities;

namespace ECoursesMicroservices.Main.BusinessLogic.Helpers;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        ConfigureDtoMapping();
        ConfigureCommandsMapping();
    }

    public void ConfigureDtoMapping()
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

    private void ConfigureCommandsMapping()
    {
        CreateMap<CreateAuthorCommand, Author>();

        CreateMap<CreateCategoryCommand, Category>();

        CreateMap<CreateCourseCommand, Course>()
            .ForMember(c => c.Tags, opt => opt.Ignore());

        CreateMap<CreateTagCommand, Tag>();

        CreateMap<UpdateAuthorCommand, Author>();

        CreateMap<UpdateCategoryCommand, Category>();

        CreateMap<UpdateCourseCommand, Course>()
            .ForMember(x => x.Tags, opt => opt.Ignore());

        CreateMap<UpdateTagCommand, Tag>();

    }
}

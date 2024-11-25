using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;

namespace ECoursesMicroservices.Video.BusinessLogic.Helpers;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        ConfigureDtoMapping();
        ConfigureCommandsMapping();
    }

    private void ConfigureDtoMapping()
    {
        CreateMap<VideoDto, Data.Entities.Video>()
            .ReverseMap();
    }

    private void ConfigureCommandsMapping()
    {
        CreateMap<CreateVideoCommand, Data.Entities.Video>()
            .ForMember(x => x.PreviewImageUrl, opt => opt.Ignore())
            .ForMember(x => x.Url, opt => opt.Ignore());

        CreateMap<UpdateVideoCommand, Data.Entities.Video>()
            .ForMember(x => x.PreviewImageUrl, opt => opt.Ignore())
            .ForMember(x => x.Url, opt => opt.Ignore());
    }
}

using ECoursesMicroservices.Video.BusinessLogic.Options;
using Microsoft.Extensions.Options;

namespace ECoursesMicroservices.Video.BusinessLogic.Helpers;
public class WebRootPathExtractor
{
    private readonly WebRootOptions _options;
    public WebRootPathExtractor(IOptions<WebRootOptions> options)
    {
        _options = options.Value;
    }

    public string GetWebRootPath()
    {
        return Environment.CurrentDirectory + _options.WebRootLocation;
    }
}

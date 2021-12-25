using Statistic.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;
using Statistic.Service.Controllers.Dto;

namespace Statistic.Service
{
    public static class ServiceConfiguration
    {
        public static void ConfigureMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<ITag, TagDto>();
                config.CreateMap<ITitle, TitleDto>()
                      .ForMember(dest=>dest.Color, opt=>opt.MapFrom(src=>
                      $"#{src.ColorSql.R:X2}{src.ColorSql.G:X2}{src.ColorSql.B:X2}"));
                config.CreateMap<IStatistic, StatisticDto>();
            });
        }

        public static void ConfigureProvider(IServiceCollection services)
        {

        }
    }
}

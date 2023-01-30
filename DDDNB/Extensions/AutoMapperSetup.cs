using Application.AutoMap;
using AutoMapper;

namespace DDDNB.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(AutoMapperConfig));

            AutoMapperConfig.RegisterMappings();
        }
    }
}

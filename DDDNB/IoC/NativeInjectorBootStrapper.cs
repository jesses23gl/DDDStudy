using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastruct.Data.Data;
using Infrastruct.Data.Repository;

namespace DDDNB.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services) 
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IStudentAppService, StudentAppService>();

            services.AddScoped<StudyContext>();
        }
    }
}

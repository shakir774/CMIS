using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;
using Domain.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using Core.Entities;
using Domain.Dtos;

namespace Course.API
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<ILecturerRepository, LecturerRepository>();
            services.AddTransient<ILecturerService, LecturerService>();

            services.AddTransient<ISemesterRepository, SemesterRepository>();
            services.AddTransient<ISemesterService, SemesterService>();

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();
            
        }
    }
}
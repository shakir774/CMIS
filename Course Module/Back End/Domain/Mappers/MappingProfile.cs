using AutoMapper;
using Core.Entities;
using Domain.Dtos;

namespace Domain.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
                //     .ReverseMap();

            CreateMap<CoursePolicy, CoursePolicyDto>()
                    .ReverseMap();

            CreateMap<Grading, GradingDto>()
                    .ReverseMap();

            CreateMap<LecturerCoursePolicy, LecturerCoursePolicyDto>()
                    .ReverseMap();

            CreateMap<Lecturer, LecturerDto>()
                    .ReverseMap();

            CreateMap<Semester, SemesterDto>()
                    .ReverseMap();

            CreateMap<Student, StudentDto>()
                    .ReverseMap();
        }
    }
}
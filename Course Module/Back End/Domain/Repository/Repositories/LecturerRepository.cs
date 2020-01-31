using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Domain.Repository.Interfaces;
using Core.Entities;
using Core.DbContexts;

namespace Domain.Repository.Repositories {
    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository (CourseDbContext context):base(context) 
        {
        }
        public bool Remove(int Id)
        {
            try
            {
                var entity = Entity.FirstOrDefault(e => e.Id == Id);
                if (entity != null)
                {
                        Entity.Remove(entity);
                        Save();
                        return true;
                }
                else return false;
               
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public Lecturer Get(int Id) 
        {
            return Entity.FirstOrDefault(e => e.Id == Id);
        }
        public bool Update(int Id, Lecturer entity)
        {
           try
            {
                if (entity.Id == Id)
                {
                    Entity.Update(entity);
                    Save();
                    return true;
                }
                else return false;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<LecturerCoursePolicy> GetLecturerCoursePolicies(int lecturerId)
        {
            var lecturer =  Entity.FirstOrDefault(i => i.Id == lecturerId);
            if(lecturer == null)
            {
                var semesterLecturer = context.SemesterCourses.FirstOrDefault(i => i.LecturerId == lecturer.Id);
                return semesterLecturer.Policies;
            }
            return null;
        }

        public bool AddLecturerCoursePolicies(int lecturerId, LecturerCoursePolicy policy)
        {
            context.LecturerCoursePolicies.Add(policy);
            var lecturer = context.SemesterCourses.FirstOrDefault(i => i.LecturerId == lecturerId);
            if(lecturer != null)
            {
                lecturer.Policies.Add(policy);
                Save();
                return true;
            } else {
                return false;
            }
        }

        public IEnumerable<Course> GetCourses(int id)
        {
            return context.SemesterCourses.Where(i => i.LecturerId == id).Select(i => new {
                Course = i.Course
            }).ToList() as IEnumerable<Course>;
        }

        public bool AddCourse(string code, int id, int semesterId)
        {
            var course = context.Courses.FirstOrDefault(i => i.Code == code);
            var lecturer = Entity.FirstOrDefault(i => i.Id == id);

            if(lecturer != null)
            {
                var semesterCourse = new SemesterCourse {
                    Lecturer = lecturer,
                    Course = course,
                    SemesterId = semesterId
                };
                context.SemesterCourses.Add(semesterCourse);
                Save();
                return true;
            }
            return false;
        }
    }
}
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Interfaces;
using Domain.Dtos;

namespace Course.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        //retorna lista de objetos do tipo Course
        [HttpGet]
        public IEnumerable<CourseDto> GetAll()
        {
            return courseService.GetAll();
        }

        //retorna um objeto do tipo Course pelo id
        [HttpGet("{code}")]
        public CourseDto GetByID(string code)
        {
            return courseService.Get(code);
        }

        //insere um objeto do tipo Course
        [HttpPost]
        public IActionResult Add([FromBody] CourseDto Course)
        {
            try
            {  
               if (courseService.Add(Course))
               {
                  return Ok("Successfully Added");
               }
               else{
                  return BadRequest("Failed To Add");
               }
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
 
        //atualiza um objeto do tipo Course pelo id
        [HttpPut("{code}")]
        public IActionResult UpdateByID(string code, [FromBody] CourseDto Course)
        {
            try
            {  
               if (courseService.Update(code,Course))
               {
                  return Ok("Successfully Updated");
               }
               else{
                  return BadRequest("Failed To Update");
               }
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //deleta um objeto do tipo Course pelo id
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            try
            {  
               if (courseService.Remove(code))
               {
                  return Ok("Successfully Removed");
               }
               else{
                  return BadRequest("Failed to Remove");
               }
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }   

        [HttpPost("policy/{code}")]
        public async Task<IActionResult> CoursePolicies(string code, [FromBody] CoursePolicyDto coursePolicyDto)
        {
            try
            {
                if(await courseService.AddPolicyAsync(code, coursePolicyDto))
                {
                    return Ok("Successfully Added");
                } else
                    return BadRequest("Failed To Add");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }  
        
        [HttpGet("policy/{code}")]
        public IActionResult CoursePolicies(string code)
        {
            return Ok(courseService.GetCoursePolicies(code));
        }     
    }
    // "Details": [
    // 	{
    // 		"Id": 1,
    // 		"Details": "Rest APIs learnt",
    // 		"CoursePolicyId": 3
    // 	}	
    // ]
}
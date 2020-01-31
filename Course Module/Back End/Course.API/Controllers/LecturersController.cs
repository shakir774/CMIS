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
    public class LecturersController : ControllerBase
    {
        
        private readonly ILecturerService lecturerService;

        public LecturersController(ILecturerService lecturerService)
        {
            this.lecturerService = lecturerService;
        }

        //retorna lista de objetos do tipo Lecturer
        [HttpGet]
        public IEnumerable<LecturerDto> GetAll()
        {
            return lecturerService.GetAll();
        }

        //retorna um objeto do tipo Lecturer pelo id
        [HttpGet("{id}")]
        public LecturerDto GetByID(int id)
        {
            return lecturerService.Get(id);
        }

        //insere um objeto do tipo Lecturer
        [HttpPost]
        public IActionResult Add([FromBody] LecturerDto Lecturer)
        {
            try
            {  
               if (lecturerService.Add(Lecturer))
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
 
        //atualiza um objeto do tipo Lecturer pelo id
        [HttpPut("{id}")]
        public IActionResult UpdateByID(int id, [FromBody] LecturerDto Lecturer)
        {
            try
            {  
               if (lecturerService.Update(id,Lecturer))
               {
                  return Ok("Successfully Updated");
               }
               else{
                  return BadRequest("Failed to Update");
               }
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //deleta um objeto do tipo Lecturer pelo id
        [HttpDelete("{id}")]
        public IActionResult DeleteByID(int id)
        {
            try
            {  
               if (lecturerService.Remove(id))
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

        [HttpGet("policy/{id}")]
        public IActionResult GetPolicy(int id)
        {
            return Ok(lecturerService.GetLecturerCoursePolicies(id));
        }
        [HttpPost("policy/{id}")]
        public IActionResult PostPolicy(int id, [FromBody] LecturerCoursePolicyDto coursePolicyDto)
        {
            return Ok(lecturerService.AddLecturerCoursePolicies(id, coursePolicyDto));
        }

        [HttpGet("course/{id}")]
        public IActionResult GetCourse(int id)
        {
            return Ok(lecturerService.GetCourses(id));
        }

        [HttpPost("course/{id}/{code}/{semId}")]
        public IActionResult PostCourse(int id, string code, int semId)
        {
            return Ok(lecturerService.AddCourse(code, id, semId));
        }
    }
}
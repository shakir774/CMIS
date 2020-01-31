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
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        //retorna lista de objetos do tipo Student
        [HttpGet]
        public IEnumerable<StudentDto> GetAll()
        {
            return studentService.GetAll();
        }

        //retorna um objeto do tipo Student pelo id
        [HttpGet("{id}")]
        public StudentDto GetByID(int id)
        {
            return studentService.Get(id);
        }

        //insere um objeto do tipo Student
        [HttpPost]
        public IActionResult Add([FromBody] StudentDto Student)
        {
            try
            {
                if (studentService.Add(Student))
                {
                    return Ok("Successfully Added");
                }
                else
                {
                    return BadRequest("Failed to Add");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //atualiza um objeto do tipo Student pelo id
        [HttpPut("{id}")]
        public IActionResult UpdateByID(int id, [FromBody] StudentDto Student)
        {
            try
            {
                if (studentService.Update(id, Student))
                {
                    return Ok("Successfully Updated");
                }
                else
                {
                    return BadRequest("Failed To Updated");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //deleta um objeto do tipo Student pelo id
        [HttpDelete("{id}")]
        public IActionResult DeleteByID(int id)
        {
            try
            {
                if (studentService.Remove(id))
                {
                    return Ok("Successfully Removed");
                }
                else
                {
                    return BadRequest("Failed to Remove");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
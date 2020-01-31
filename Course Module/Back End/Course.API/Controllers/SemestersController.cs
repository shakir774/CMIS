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
    public class SemestersController : ControllerBase
    {
        private readonly ISemesterService semesterService;

        public SemestersController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        //retorna lista de objetos do tipo Semester
        [HttpGet]
        public IEnumerable<SemesterDto> GetAll()
        {
            return semesterService.GetAll();
        }

        //retorna um objeto do tipo Semester pelo id
        [HttpGet("{id}")]
        public SemesterDto GetByID(int id)
        {
            return semesterService.Get(id);
        }

        //insere um objeto do tipo Semester
        [HttpPost]
        public IActionResult Add([FromBody] SemesterDto Semester)
        {
            try
            {
                if (semesterService.Add(Semester))
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

        //atualiza um objeto do tipo Semester pelo id
        [HttpPut("{id}")]
        public IActionResult UpdateByID(int id, [FromBody] SemesterDto Semester)
        {
            try
            {
                if (semesterService.Update(id, Semester))
                {
                    return Ok("Successfully Updated");
                }
                else
                {
                    return BadRequest("Failed to Update");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //deleta um objeto do tipo Semester pelo id
        [HttpDelete("{id}")]
        public IActionResult DeleteByID(int id)
        {
            try
            {
                if (semesterService.Remove(id))
                {
                    return Ok("Successfully Removed");
                }
                else
                {
                    return BadRequest("Failed To Remove");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
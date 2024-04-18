using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Contract;
using Student.Model;
using System.Collections.Generic;
using System;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;
        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet()]
        public int GetTotalMarkObtained(int studentId)
        {
            return _studentBusiness.GetTotalMarkObtained(studentId);
        }

        [HttpGet()]
        public double GetTotalPercentageObtained(int studentId)
        {
            return _studentBusiness.GetTotalPercentageObtained(studentId);
        }

        [HttpGet()]
        public IEnumerable<Marksheet> GetAllMarksById(int studentId)
        {
            return _studentBusiness.GetAllMarksById(studentId);
        }

        [HttpPost()]
        public IActionResult AddMarks(Marksheet markSheet)
        {
            _studentBusiness.AddMarks(markSheet);
            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateMarks(Marksheet markSheet)
        {
            _studentBusiness.UpdateMarks(markSheet);
            return Ok();
        }

        [HttpGet()]
        public IEnumerable<object> GetStudentList()
        {
            return _studentBusiness.GetStudentList();
        }

        [HttpGet()]
        public IEnumerable<object> GetTopThree(int @class)
        {
            return _studentBusiness.GetTopThree(@class);
        }
    }
}

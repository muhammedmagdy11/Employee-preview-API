using EmployeesAndDepartmentsAPI.Models;
using EmployeesAndDepartmentsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public DepartmentController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _repositoryManager.Department.GetAllDepartmentAsync(trackchanges: false);

            return Ok(departments);
        }
        [HttpGet("{id}", Name = "DepartmentById")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(id, trackchanges: false);
            if (department == null)
                return NotFound();
            return Ok(department);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("employee object is null");
            }

            await _repositoryManager.Department.CreateDepartment(department);
            await _repositoryManager.SaveAsync();
            return CreatedAtRoute("DepartmentById", new { id = department.Id },
           department);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(id, trackchanges: false);
            if (department == null)
            {
                return NotFound();
            }
            _repositoryManager.Department.DeleteDepartment(department);
            await _repositoryManager.SaveAsync();
            return NoContent();

        }
    }
}

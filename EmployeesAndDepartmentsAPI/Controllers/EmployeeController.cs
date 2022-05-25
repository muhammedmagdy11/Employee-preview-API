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
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public EmployeeController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
          
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _repositoryManager.Employee.GetAllEmployeesAsync(trackchanges: false);
            
            return Ok(employees);
        }
        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, trackchanges: false);
            if (employee == null)
                return NotFound();
            return Ok(employee);

        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("employee object is null");
            }
           
           await _repositoryManager.Employee.CreateEmployee(employee);
           await  _repositoryManager.SaveAsync();
            return CreatedAtRoute("EmployeeById", new { id = employee.Id },
           employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, trackchanges: false);
            if (employee == null)
            {
                return NotFound();
            }
            _repositoryManager.Employee.DeleteEmployee(employee);
           await _repositoryManager.SaveAsync();
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            _repositoryManager.Employee.UpdateEmployee(employee);
           await _repositoryManager.SaveAsync();
            return Ok(employee);

        }
    }
}

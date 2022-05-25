using EmployeesAndDepartmentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync(bool trackchanges);
        Task<Department> GetDepartmentAsync(int Id, bool trackchanges);

        Task CreateDepartment(Department department);
        void DeleteDepartment(Department department);

    }
}

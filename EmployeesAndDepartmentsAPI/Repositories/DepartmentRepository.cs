using EmployeesAndDepartmentsAPI.Context;
using EmployeesAndDepartmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentAsync(bool trackchanges)
        {
            return await FindAll(trackchanges).Include(d=>d.Employees).ToListAsync();
        }
        public async Task<Department> GetDepartmentAsync(int Id, bool trackchanges)
        {
            return await FindByCondition(e => e.Id.Equals(Id), trackchanges).Include(e => e.Employees).SingleOrDefaultAsync();
        }
        public async Task CreateDepartment(Department department)
        {
            if (department != null)
                await Create(department);
        }

        public void DeleteDepartment(Department department)
        {
            if (department != null)
                Delete(department);
        }
    }
}

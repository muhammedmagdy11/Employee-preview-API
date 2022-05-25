using EmployeesAndDepartmentsAPI.Context;
using EmployeesAndDepartmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
    {
        private DbSet<FamilyMember> _FamillyMembers;

        public EmployeeRepository(ProjectContext projectContext) : base(projectContext)
        {
            _FamillyMembers = projectContext.Set<FamilyMember>();
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackchanges)
        {
            return await FindAll(trackchanges).Include(e=>e.FamilyMembers).ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int Id, bool trackchanges)
        {
            return await FindByCondition(e => e.Id.Equals(Id), trackchanges).Include(e=>e.FamilyMembers).SingleOrDefaultAsync();
        }
        public async Task CreateEmployee(Employee employee)
        {
            if (employee != null)
                await Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee != null)
                Delete(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
                Update(employee);

        }
        public void UpdateFamilyMember(FamilyMember familyMember)
        {
            var alreadyInDB = _FamillyMembers.FirstOrDefault(a => a == familyMember);
            var AreEqual = JsonConvert.SerializeObject(familyMember).ToString() == JsonConvert.SerializeObject(alreadyInDB).ToString();
            if (!AreEqual)
            {
                _FamillyMembers.Update(familyMember);
            }
        }
    }
}

using EmployeesAndDepartmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Context
{
    public class ProjectContext :DbContext
    {
        public ProjectContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }

    }
}

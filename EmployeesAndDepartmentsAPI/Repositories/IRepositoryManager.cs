
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        IDepartmentRepository Department { get; }
        Task SaveAsync();
    }
}

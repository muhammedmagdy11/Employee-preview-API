using System.Threading.Tasks;
using EmployeesAndDepartmentsAPI.Context;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public class RepositoryManager: IRepositoryManager
    {
        private IEmployeeRepository _EmployeeRepository;
        private IDepartmentRepository _DepartmentRepository;
        private ProjectContext _ProjectContext;

        public RepositoryManager(ProjectContext ProjectContext)
        {
            _ProjectContext = ProjectContext;
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_EmployeeRepository == null)
                    _EmployeeRepository = new EmployeeRepository(_ProjectContext);
                return _EmployeeRepository;
            }
        }
        public IDepartmentRepository Department
        {
            get
            {
                if (_DepartmentRepository == null)
                    _DepartmentRepository = new DepartmentRepository(_ProjectContext);
                return _DepartmentRepository;
            }
        }

        public Task SaveAsync()
        {
            return _ProjectContext.SaveChangesAsync();

        }
    }
}

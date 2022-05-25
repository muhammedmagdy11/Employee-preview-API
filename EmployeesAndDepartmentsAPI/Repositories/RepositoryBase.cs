using EmployeesAndDepartmentsAPI.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private ProjectContext _ProjectContext;

        public RepositoryBase(ProjectContext ProjectContext)
        {
            _ProjectContext = ProjectContext;
        }
        public async Task Create(T entity)
        {
            await _ProjectContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _ProjectContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _ProjectContext.Set<T>().AsNoTracking() : _ProjectContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _ProjectContext.Set<T>().Where(expression).AsNoTracking() : _ProjectContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _ProjectContext.Set<T>().Update(entity);
        }
    }
}

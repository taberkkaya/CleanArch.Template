using CleanArch.Domain.Employees;
using CleanArch.Infrastructure.Context;
using GenericRepository;

namespace CleanArch.Infrastructure.Repositories;

internal class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}

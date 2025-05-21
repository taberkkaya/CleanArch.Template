using CleanArch.Domain.Employees;
using MediatR;
using ResultKit;

namespace CleanArch.Application.Employees;

public sealed record EmployeeGetQuery(Guid Id) : IRequest<Result<Employee>>;

internal sealed class EmployeeGetQueryHandler(
    IEmployeeRepository employeeRepository
    ) : IRequestHandler<EmployeeGetQuery, Result<Employee>>
{
    public async Task<Result<Employee>> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (employee is null)
            return Result<Employee>.Failure($"Employee with id {request.Id} not found.");

        return employee;
    }
}

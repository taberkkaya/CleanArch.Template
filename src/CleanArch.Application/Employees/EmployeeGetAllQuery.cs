using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Employees;
using MediatR;

namespace CleanArch.Application.Employees;

public sealed record EmployeeGetAllQuery() : IRequest<IQueryable<EmployeeGetAllQueryResponse>>;

public sealed class EmployeeGetAllQueryResponse : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public decimal Salary { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string SocialSecurityNumber { get; set; } = default!;

}

public sealed class EmployeeGetAllQueryHandler(
        IEmployeeRepository employeeRepository
    ) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = employeeRepository.GetAll()
            .Select(e => new EmployeeGetAllQueryResponse
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary,
                DateOfBirth = e.DateOfBirth,
                SocialSecurityNumber = e.PersonalInfo.SocialSecurityNumber,
                CreatedAt = e.CreatedAt,
                CreatedBy = e.CreatedBy,
                UpdatedAt = e.UpdatedAt,
                UpdatedBy = e.UpdatedBy,
                DeletedAt = e.DeletedAt,
                DeletedBy = e.DeletedBy,
                IsDeleted = e.IsDeleted
            })
            .AsQueryable();

        return Task.FromResult(response);
    }
}

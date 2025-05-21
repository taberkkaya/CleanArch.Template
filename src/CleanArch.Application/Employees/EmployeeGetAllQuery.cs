using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Employees;
using CleanArch.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

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
        IEmployeeRepository employeeRepository,
        UserManager<AppUser> userManager
    ) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = (from employee in employeeRepository.GetAll()
                        join create_user in userManager.Users.AsQueryable() on employee.CreatedBy equals create_user.Id
                        join update_user in userManager.Users.AsQueryable() on employee.UpdatedBy equals update_user.Id
                        into update_user
                        from update_users in update_user.DefaultIfEmpty()
                        select new EmployeeGetAllQueryResponse
                        {
                            Id = employee.Id,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Salary = employee.Salary,
                            DateOfBirth = employee.DateOfBirth,
                            SocialSecurityNumber = employee.PersonalInfo.SocialSecurityNumber,
                            CreatedAt = employee.CreatedAt,
                            CreatedBy = employee.CreatedBy,
                            CreatedByName = create_user.FirstName + " " + create_user.LastName + " (" + create_user.Email + ")",
                            UpdatedAt = employee.UpdatedAt,
                            UpdatedBy = employee.UpdatedBy,
                            UpdatedByName = employee.UpdatedBy == null ? null : update_users.FirstName + " " + update_users.LastName + "(" + update_users.Email + ")",
                            DeletedAt = employee.DeletedAt,
                            DeletedBy = employee.DeletedBy,
                            IsDeleted = employee.IsDeleted,
                            IsActive = employee.IsActive
                        }).AsQueryable();

        return Task.FromResult(response);
    }
}

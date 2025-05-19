using CleanArch.Domain.Abstractions;

namespace CleanArch.Domain.Employees;

public sealed class Employee : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName}";
    public decimal Salary { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public PersonalInfo PersonalInfo { get; set; } = default!;
    public Address Address { get; set; } = default!;
}

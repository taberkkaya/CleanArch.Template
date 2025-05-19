namespace CleanArch.Domain.Employees;

public sealed record PersonalInfo
{
    public string SocialSecurityNumber { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}

using CleanArch.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using ResultKit;



namespace CleanArch.Application.Employees;

public sealed record EmployeeCreateCommand(
    string FirstName,
    string LastName,
    decimal Salary,
    DateOnly BirthOfDate,
    PersonalInfo PersonalInfo,
    Address? Address
    ) : IRequest<Result<string>>;

public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Ad alanı boş olamaz.");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Soyad alanı boş olamaz.");
        RuleFor(x => x.BirthOfDate)
            .NotEmpty()
            .WithMessage("Doğum tarihi alanı boş olamaz.");
        RuleFor(x => x.PersonalInfo.SocialSecurityNumber)
            .NotEmpty()
            .WithMessage("Sosyal güvenlik numarası alanı boş olamaz.");
    }
}

internal sealed class EmployeeCreateCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork

    ) : IRequestHandler<EmployeeCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {

        var isEmployeeExist = await employeeRepository
            .AnyAsync(x => x.PersonalInfo.SocialSecurityNumber == request.PersonalInfo.SocialSecurityNumber);

        if (isEmployeeExist)
            return Result<string>.Failure("Bu sosyal güvenlik numarasına sahip bir çalışan zaten mevcut.");

        Employee employee = request.Adapt<Employee>();

        await employeeRepository.AddAsync(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel kaydı başarıyla tamamlandı.";
    }
}
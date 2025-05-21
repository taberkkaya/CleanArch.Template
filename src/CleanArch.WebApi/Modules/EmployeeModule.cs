using CleanArch.Application.Employees;
using CleanArch.Domain.Employees;
using MediatR;
using ResultKit;

namespace CleanArch.WebApi.Modules;

public static class EmployeeModule
{
    public static void RegisterEmployeeRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/employees").WithTags("Employees").RequireAuthorization();

        group.MapPost(string.Empty,
            async (ISender sender, EmployeeCreateCommand request, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            }).Produces<Result<string>>();

        group.MapGet(string.Empty,
            async (ISender sender, Guid id, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new EmployeeGetQuery(id), cancellationToken);
            return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
        }).Produces<Result<Employee>>();
    }
}

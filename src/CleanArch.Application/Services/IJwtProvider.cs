using CleanArch.Domain.Users;

namespace CleanArch.Application.Services;

public interface IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user, string password, CancellationToken cancellationToken = default);
}

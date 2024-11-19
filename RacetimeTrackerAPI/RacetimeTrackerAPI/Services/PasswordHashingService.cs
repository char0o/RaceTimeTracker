using Microsoft.AspNetCore.Identity;
using RacetimeTrackerAPI.DTOs;

namespace RacetimeTrackerAPI.Services;

public class PasswordHashingService
{
    private readonly PasswordHasher<DTOs.User> _passwordHasher;

    public PasswordHashingService()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    public string HashPassword(DTOs.User user, string password)
    {
        return this._passwordHasher.HashPassword(user, password);
    }

    public bool VerifyHashedPassword(DTOs.User user, string hashedPassword, string password)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}
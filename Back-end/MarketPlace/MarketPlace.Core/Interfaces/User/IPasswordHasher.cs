namespace MarketPlace.Core.Interfaces.Auth;

public interface IPasswordHasher
{
    string GenerateHash(string password);
    bool Verify(string password, string passwordHash);
}
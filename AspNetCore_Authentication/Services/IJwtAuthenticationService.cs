namespace AspNetCore_Authentication.Services
{
    public interface IJwtAuthenticationService
    {
        string GenerateToken(string userName, string role = "Customer");

        string ValidateToken(string token);
    }
}

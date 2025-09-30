namespace AspNetCore_Authentication.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private static readonly string myToken = "Bhavya1234567@"; //hard coded value
        string IJwtAuthenticationService.GenerateToken(string userName, string role)
        {
            return myToken;
        }

        string IJwtAuthenticationService.ValidateToken(string token)
        {
            if(token.Contains("Bhavya"))
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            };
        }
    }
}

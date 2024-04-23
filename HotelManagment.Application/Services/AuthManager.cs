namespace HotelManagment.Application.Services;

public class AuthManager(IConfiguration configuration) : IAuthManager
{
    private readonly IConfiguration _config = configuration.GetSection("Jwt");

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.MobilePhone,user.PhoneNumber.ToString()),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Gender,user.Gender.ToString()),
            new Claim (ClaimTypes.Locality,user.Country)
        };

        var issuer = _config["Issuer"];
        var audience = _config["Audience"];
        var secretKey = _config["SecretKey"];
        var expire = double.Parse(_config["Lifetime"]!);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
            expires: DateTime.Now.AddMinutes(expire),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}

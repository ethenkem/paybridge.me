using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PayBridge.Infrastructure.Auth;


public class JwtTokenService
{
    private readonly IConfiguration _config;

    public JwtTokenService(IConfiguration config)
    {
        this._config = config;
    }

    public string CreateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Uid),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _config["Jwt:Key"]!));
        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
          issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
           claims: claims,
           expires: DateTime.UtcNow.AddDays(7),
           signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }



}

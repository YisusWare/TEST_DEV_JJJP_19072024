using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TEST_DEV_API.Interfaces;
using TEST_DEV_API.Models;

namespace TEST_DEV_API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            //_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _config = config;
        }
        public string CrearToken(TbUsuario usuario)
        {
            var tokenKey = _config["TokenKey"] ?? throw new Exception("No se pudo acceder al token Key");
            if (tokenKey.Length < 64) throw new Exception("Token key demasiado corta");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,usuario.Email)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TEST_DEV.Data.Data;
using TEST_DEV.Models.Models;
using TEST_DEV.Models.ViewModels;
using TEST_DEV_API.Interfaces;

namespace TEST_DEV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<TbUsuario>> Register(LoginViewModel registro)
        {
            if (await ValidateUser(registro.Email))
            {
                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();

            TbUsuario usuario = new TbUsuario
            {
                Email = registro.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registro.Password)),
                PasswordSalt = hmac.Key
            };

            _context.TbUsuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new UsuarioViewModel()
            {
                Email = usuario.Email,
                Token = _tokenService.CrearToken(usuario)
            }
            );

        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioViewModel>> Login(LoginViewModel login)
        {
            TbUsuario user = await _context.TbUsuarios.SingleOrDefaultAsync(u => u.Email == login.Email);

            if (user == null) return Unauthorized("This user is not registrated");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Wrong Password");
            }

            return Ok(new UsuarioViewModel()
            {
                Email = user.Email,
                Token = _tokenService.CrearToken(user)
            });
        }

        private async Task<bool> ValidateUser(string username)
        {
            return await _context.TbUsuarios.AnyAsync(user => user.Email == username);
        }


    }
}

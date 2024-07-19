using TEST_DEV.Models.Models;

namespace TEST_DEV_API.Interfaces
{
    public interface ITokenService
    {
        string CrearToken(TbUsuario usuario);
    }
}

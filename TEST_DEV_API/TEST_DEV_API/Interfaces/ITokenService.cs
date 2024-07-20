using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_API.Models;

namespace TEST_DEV_API.Interfaces
{
    public interface ITokenService
    {
        string CrearToken(TbUsuario usuario);
    }
}

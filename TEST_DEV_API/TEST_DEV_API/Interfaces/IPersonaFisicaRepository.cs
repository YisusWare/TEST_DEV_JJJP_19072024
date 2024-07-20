using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_API.Models;

namespace TEST_DEV_API.Interfaces
{
    public interface IPersonaFisicaRepository
    {
        public Task CrearPersonaFisica(TbPersonasFisica nuevaPersonaFisica);

        public Task<TbPersonasFisica> ObtenerPersonaFisicaPorId(int id);

        public Task<IEnumerable<TbPersonasFisica>> ObtenerPersonasFisicas(TbPersonasFisica nuevaPersonaFisica);
        public Task ActualizarPersonaFisica(TbPersonasFisica nuevaPersonaFisica);
        public Task EliminarPersonaFisica(int idPersonaFisica);
    }
}

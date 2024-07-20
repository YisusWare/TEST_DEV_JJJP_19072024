using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV.Data.Data;
using TEST_DEV_API.Interfaces;
using TEST_DEV_API.Models;

namespace TEST_DEV_API.Services
{
    public class PersonaFisicaRepository : IPersonaFisicaRepository
    {
        private readonly AppDbContext _context;
        private readonly SPDbContext _spContext;

        public PersonaFisicaRepository(AppDbContext context, SPDbContext spContext)
        {
            _context = context;
            _spContext = spContext;
        }

        public async Task CrearPersonaFisica(TbPersonasFisica nuevaPersonaFisica)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@Nombre",
                    Value = nuevaPersonaFisica.Nombre
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoPaterno",
                    Value = nuevaPersonaFisica.ApellidoPaterno
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoMaterno",
                    Value = nuevaPersonaFisica.ApellidoMaterno
                },
                new SqlParameter
                {
                    ParameterName = "@RFC",
                    Value = nuevaPersonaFisica.Rfc
                },
                  new SqlParameter
                {
                    ParameterName = "@FechaNacimiento",
                    Value = nuevaPersonaFisica.FechaNacimiento
                },
                  new SqlParameter
                {
                    ParameterName = "@UsuarioAgrega",
                    Value = nuevaPersonaFisica.UsuarioAgrega
                }
            };

            await _spContext.Database.ExecuteSqlRawAsync("EXEC dbo.sp_AgregarPersonaFisica @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento, @UsuarioAgrega", parms.ToArray());

            return;
        }

        public async Task<IEnumerable<TbPersonasFisica>> ObtenerPersonasFisicas(TbPersonasFisica nuevaPersonaFisica)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@Nombre",
                    Value = nuevaPersonaFisica.Nombre
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoPaterno",
                    Value = nuevaPersonaFisica.ApellidoPaterno
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoMaterno",
                    Value = nuevaPersonaFisica.ApellidoMaterno
                },
                new SqlParameter
                {
                    ParameterName = "@RFC",
                    Value = nuevaPersonaFisica.Rfc
                },
                new SqlParameter
                {
                    ParameterName = "@FechaNacimiento",
                    Value = nuevaPersonaFisica.FechaNacimiento
                }
            };

            List<TbPersonasFisica> personasFisicas = await _context.TbPersonasFisicas
                                                            .FromSqlRaw<TbPersonasFisica>("EXEC sp_BuscarPersonasFisicas @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento", parms.ToArray())
                                                            .AsNoTracking()
                                                            .ToListAsync();

            return personasFisicas;
        }

        public async Task<TbPersonasFisica> ObtenerPersonaFisicaPorId(int id)
        {
            TbPersonasFisica persona = await _context.TbPersonasFisicas.FindAsync(id);

            if (persona == null && persona.Activo == false)
            {
                return new TbPersonasFisica();
            }

            return persona;
        }

        public async Task ActualizarPersonaFisica(TbPersonasFisica nuevaPersonaFisica)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@IdPersonaFisica",
                    Value = nuevaPersonaFisica.IdPersonaFisica
                },
                new SqlParameter
                {
                    ParameterName = "@Nombre",
                    Value = nuevaPersonaFisica.Nombre
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoPaterno",
                    Value = nuevaPersonaFisica.ApellidoPaterno
                },
                new SqlParameter
                {
                    ParameterName = "@ApellidoMaterno",
                    Value = nuevaPersonaFisica.ApellidoMaterno
                },
                new SqlParameter
                {
                    ParameterName = "@RFC",
                    Value = nuevaPersonaFisica.Rfc
                },
                  new SqlParameter
                {
                    ParameterName = "@FechaNacimiento",
                    Value = nuevaPersonaFisica.FechaNacimiento
                },
                  new SqlParameter
                {
                    ParameterName = "@UsuarioAgrega",
                    Value = nuevaPersonaFisica.UsuarioAgrega
                }
            };

            await _spContext.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarPersonaFisica @IdPersonaFisica,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@RFC,@FechaNacimiento,@UsuarioAgrega", parms.ToArray());
            return;
        }
        public async Task EliminarPersonaFisica(int idPersonaFisica)
        {
            SqlParameter parms = new SqlParameter
            {
                ParameterName = "@IdPersonaFisica",
                Value = idPersonaFisica
            };

            await _spContext.Database.ExecuteSqlRawAsync("sp_EliminarPersonaFisica @IdPersonaFisica", parms);

            return;
        }
    }
}

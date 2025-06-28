using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Caso1SPrograAvWeb.Data
{
    public class ConexionSQL : IConexionSQL
    {
        private readonly string _connectionString;

        public ConexionSQL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Cadena de conexión no encontrada");
        }

        public IDbConnection CrearConexion() => new SqlConnection(_connectionString);
    }

    public interface IConexionSQL
    {
        IDbConnection CrearConexion();
    }
}
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace APICorePedidos.Data.Contexto
{
    public class SqlContexto : IDisposable
    {
        public IConfiguration Configuration { get; set; }

        public SqlContexto(IConfiguration config)
        {
            Configuration = config;
        }

        public IDbConnection BDConexao
        {
            get
            {
                var connectionString = Configuration["ConnectionStrings:PedidosDatabase"].ToString();
                return new SqlConnection(connectionString);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

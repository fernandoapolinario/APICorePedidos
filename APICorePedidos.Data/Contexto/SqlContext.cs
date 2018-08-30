using System;
using System.Data;
using System.Data.SqlClient;

namespace APICorePedidos.Data.Contexto
{
    public class SqlContexto : IDisposable
    {
        public IDbConnection BDConexao
        {
            get
            {
                var config = @"Server=localhost\SQLEXPRESS;Database=APICorePedidos;Trusted_Connection=True;";

                return new SqlConnection(config);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

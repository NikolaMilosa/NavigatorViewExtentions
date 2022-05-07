using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using Npgsql;

namespace NavigatorViewExtensions.Services.Connection
{
    public class DapperService : IDapper
    {
        private readonly string _connectionString;
        private readonly IDbConnection _dbConnection;

        public DapperService()
        {
            _connectionString = Environment.GetEnvironmentVariable("SRB_CON");
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Missing connection string!");
            }

            _dbConnection = new NpgsqlConnection(_connectionString);
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }

        public T Get<T>(string sp, DynamicParameters parameters)
        {
            return _dbConnection.QueryFirst<T>(sp, parameters, commandType: CommandType.Text);
        }

        public IEnumerable<T> GetAll<T>(string sp, DynamicParameters parameters)
        {
            return _dbConnection.Query<T>(sp, parameters, commandType: CommandType.Text);
        }
    }
}
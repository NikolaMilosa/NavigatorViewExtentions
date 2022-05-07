using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Dapper;

namespace NavigatorViewExtensions.Services.Connection
{
    public interface IDapper : IDisposable
    {
        IDbConnection GetConnection();

        T Get<T>(string sp, DynamicParameters parameters);

        IEnumerable<T> GetAll<T>(string sp, DynamicParameters parameters);
    }
}
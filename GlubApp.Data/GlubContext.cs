using GlubApp.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace GlubApp.Data;

public class GlubContext
{
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public GlubContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    public SqlTableDependency<Aircraft> ServiceBrokerConnection() => new SqlTableDependency<Aircraft>(_connectionString);
}

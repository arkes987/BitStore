﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace BitStore.Metadata.Context
{
    public class MetadataContext
    {
        private readonly IConfiguration _configuration;
        public IDbConnection Connection { get; }

        public MetadataContext(IConfiguration configuration) =>
            Connection = new NpgsqlConnection(configuration["Metadata:ConnectionString"]);

    }
}

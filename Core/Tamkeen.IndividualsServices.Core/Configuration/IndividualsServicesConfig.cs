using System;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Configuration
{
    public class IndividualsServicesConfig
    {
        public List<string> RequiredScopes { get; set; }

        public string ClientSecret { get; set; }

        public List<string> CorsEnabledUri { get; set; }

        public List<string> CorsEnabledHeaders { get; set; }

        public List<string> CorsEnabledVerbs { get; set; }

        public List<string> CorsExposedHeaders { get; set; }

        public DbConnectionString DbConnection { get; set; }

        public IdSrvConfig IdSrv { get; set; }
        public bool SkipSSL { get; set; }

        public OracleDb OracleDb { get; set; }
    }

    public class DbConnectionString
    {
        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }
    }

    public class IdSrvConfig
    {
        public Uri BaseUrl { get; set; }
        public string ApiName { get; set; }
    }


    public class OracleDb
    {
        public string Schema { get; set; }
        public string ConnectionString { get; set; }
    }
}

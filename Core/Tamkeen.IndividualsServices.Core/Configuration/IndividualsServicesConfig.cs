using System;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Configuration
{
    public class IndividualsServicesConfig
    {

        public CorsConfiguration Cors { get; set; }

        public SqlConnectionInfo SqlConnection { get; set; }

        public IdSrvConfiguration IdSrv { get; set; }
        public bool SkipSSL { get; set; }

        public OracleConnectionInfo OracleConnection { get; set; }
    }

    public class SqlConnectionInfo
    {
        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }
    }

    public class IdSrvConfiguration
    {
        public Uri BaseUrl { get; set; }
        public string ApiName { get; set; }
        public List<string> RequiredScopes { get; set; }
        public string ClientSecret { get; set; }
    }


    public class OracleConnectionInfo
    {
        public string Schema { get; set; }
        public string ConnectionString { get; set; }
    }

    public class CorsConfiguration
    {
        public List<string> EnabledUri { get; set; }

        public List<string> EnabledHeaders { get; set; }

        public List<string> EnabledVerbs { get; set; }

        public List<string> ExposedHeaders { get; set; }
    }
}

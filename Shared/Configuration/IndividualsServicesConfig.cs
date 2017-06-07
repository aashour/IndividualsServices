using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Configuration
{
    public class IndividualsServicesConfig
    {
        public List<string> RequiredScopes { get; set; }

        public string ClientSecret { get; set; }

        public List<Uri> CorsEnabledUri { get; set; }

        public List<string> CorsEnabledHeaders { get; set; }

        public List<string> CorsEnabledVerbs { get; set; }

        public List<string> CorsExposedHeaders { get; set; }
    }
}

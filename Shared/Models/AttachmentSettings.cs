using Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class AttachmentSettings : ISettings
    {
        /// <summary>
        /// Maximum allowed size.
        /// </summary>
        public int MaximumSize { get; set; }


    }
}

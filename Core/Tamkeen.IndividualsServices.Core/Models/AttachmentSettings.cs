using Tamkeen.IndividualsServices.Core.Configuration;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public class AttachmentSettings : ISettings
    {
        /// <summary>
        /// Maximum allowed size.
        /// </summary>
        public int MaximumSize { get; set; }


    }
}

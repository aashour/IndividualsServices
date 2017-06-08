using Tamkeen.IndividualsServices.Core.Data;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public class UserEstablishment: BaseEntity<long>
    {
        public string IdNumber { get; set; }

        public long EstablishmentId { get; set; }       

        public int TypeId { get; set; }

        public string Name { get; set; }

        public bool? IsVerified { get; set; }
    }
}

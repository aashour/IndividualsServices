using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
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

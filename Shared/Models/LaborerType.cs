using Shared.Data;
using System.Collections.Generic;

namespace Shared.Models
{
    public class LaborerType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime? CreatedOn { get; set; }
        public System.DateTime? ModifiedOn { get; set; }
        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EstablishmentKPI
    {
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public Color Color { get; set; }
    }

    public struct Color
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

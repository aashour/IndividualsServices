namespace Tamkeen.IndividualsServices.Core.Models
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

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class EstablishmentDto
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string EconomicActivity { get; set; }
        public string CommercialRecordNumber { get; set; }
        public string OwnerIdOrSevenHundred { get; set; }
        public string Color { get; set; }
        public string WaselAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EstablishmentRepresentatvieDto EstablishmentRepresentatvie { get; set; }
    }

    public class EstablishmentRepresentatvieDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

}

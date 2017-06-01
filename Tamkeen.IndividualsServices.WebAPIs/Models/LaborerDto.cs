using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class LaborerDto
    {
        public string IdNumber { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime? IdExpirationDate { get; set; }
        public int YearOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string Job { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime? StatusModificationDate { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public long EstablishmentId { get; set; }
        public List<RunawayRequestDto> RunawayRequests { get; set; } = new List<RunawayRequestDto>();
    }
}

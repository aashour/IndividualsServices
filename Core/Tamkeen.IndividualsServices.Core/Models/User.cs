using Tamkeen.IndividualsServices.Core.Data;
using System;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class User : BaseEntity<long>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public int? LaborOfficeId { get; set; }
        public short? NationalityId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? TypeId { get; set; }
        public long? IdNumber { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        public long? IqamaNumber { get; set; }
        public DateTime? IqamaExpiryDate { get; set; }
        public string Email { get; set; }
        public bool? Deleted { get; set; }
        public bool? Activated { get; set; }
        public string MobileNumber { get; set; }
        public bool IsSystem { get; set; }
        public bool EmailVerified { get; set; }
        public short EmailVerificationCount { get; set; }
        public System.DateTime? EmailLastVerificationDate { get; set; }
        public bool MobileVerified { get; set; }
        public short MobileVerificationCount { get; set; }
        public System.DateTime? MobileLastVerificationDate { get; set; }
        public bool DataVerified { get; set; }
        public virtual UserType Type { get; set; }
        public virtual LaborOffice LaborOffice { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<OracleTransactionLog> OracleTransactionLogs { get; set; } = new List<OracleTransactionLog>();
        //public virtual ICollection<RunawayRequest> RunawayRequests { get; set; } = new List<RunawayRequest>();
        public ICollection<ServiceLog> ServiceLogs { get; set; }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Entities
{
    public class MolUser : IdentityUser<int, MolUserLogin, MolUserRole, MolUserClaim>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public short? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserTypeId { get; set; }
        public long? IdNumber { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        public long? IqamaNumber { get; set; }
        public DateTime? IqamaExpiryDate { get; set; }

    }



    public class MolUserLogin : IdentityUserLogin<int> { }
    public class MolUserRole : IdentityUserRole<int> { }
    public class MolUserClaim : IdentityUserClaim<int> { }

}
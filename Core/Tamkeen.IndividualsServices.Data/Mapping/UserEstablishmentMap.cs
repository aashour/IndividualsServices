using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class UserEstablishmentMap : EntityTypeConfiguration<UserEstablishment>
    {
        public UserEstablishmentMap()
        {
            this.ToTable("MOL_VwUserEstablishments");
            this.HasKey(est => est.Id);

            this.Property(t => t.Id).HasColumnName("PK_AuthorizedId");
            this.Property(t => t.IdNumber).HasColumnName("AuthorizedIdNo");
            this.Property(t => t.EstablishmentId).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.Name).HasColumnName("AuthorizedName");
            this.Property(t => t.TypeId).HasColumnName("AuthorizedType");
            this.Property(t => t.IsVerified).HasColumnName("IsVerified");
        }
    }
}

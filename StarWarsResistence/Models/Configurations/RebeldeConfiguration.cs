using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarWarsResistence.Models.Configurations
{
    public class RebeldeConfiguration : IEntityTypeConfiguration<Rebelde>
    {
        public void Configure(EntityTypeBuilder<Rebelde> builder)
        {
            builder.HasKey(x => x.Id);

            /*builder.HasOne(x => x.Localizacao)
                  .WithMany(y => y.Id)
                  .HasForeignKey(x => x.IdLocalizacao)
                  .HasConstraintName("FK_Rebelde_Localizacao_Id");*/

        }
    }
}

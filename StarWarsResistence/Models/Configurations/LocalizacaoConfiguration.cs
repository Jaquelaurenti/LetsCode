using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarWarsResistence.Models.Configurations
{
    public class LocalizacaoConfiguration : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

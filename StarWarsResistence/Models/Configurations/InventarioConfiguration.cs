using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarWarsResistence.Models.Configurations
{
    public class ItemInventarioConfiguration : IEntityTypeConfiguration<ItemInventario>
    {
        public void Configure(EntityTypeBuilder<ItemInventario> builder)
        {
            builder.HasKey(x => x.Id);

                builder.HasOne(x => x.Inventario)
                   .WithMany(y => y.Itens)
                   .HasForeignKey(x => x.IdInventario)
                   .HasConstraintName("FK_Inventario_Itens_Id");

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppVenta.Dominio;

namespace AppVenta.Infraestructura.Datos.Configs
{
    internal class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tblVentas");
            builder.HasKey(c => c.ventaId);

            builder.HasMany(venta => venta.VentaDetalles).WithOne(venta => venta.Venta);
        }
    }
}

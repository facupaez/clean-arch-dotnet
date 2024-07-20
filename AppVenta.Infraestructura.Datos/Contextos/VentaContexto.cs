using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppVenta.Infraestructura.Datos.Contextos
{
    public class VentaContexto : DbContext {

        string db_user = Environment.GetEnvironmentVariable("db_user");
        string db_pw = Environment.GetEnvironmentVariable("db_pw");

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<VentaDetalle> VentasDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=tcp:serverappventa.database.windows.net,1433;Initial Catalog=app-venta;Persist Security Info=False;User ID=adminappventa;Password=Channel321*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            // connect to postgres with connection string from app settings
            options.UseNpgsql("Host=localhost;Port=5432;Database=AppVenta;Username=" + db_user + ";Password=" + db_pw + ";");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductoConfig());
            builder.ApplyConfiguration(new VentaConfig());
            builder.ApplyConfiguration(new VentaDetalleConfig());
        }
    }
}

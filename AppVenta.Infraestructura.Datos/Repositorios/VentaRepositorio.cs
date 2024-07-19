using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {

        private VentaContexto db;

        public VentaRepositorio(VentaContexto _db)
        {
            db = _db;
        }
        public Venta Agregar(Venta entidad)
        {
            entidad.ventaId = Guid.NewGuid();
            db.Ventas.Add(entidad);

            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null)
            {
                throw new NullReferenceException("Está intentando anular una venta que no existe.");
            }

            ventaSeleccionada.anulado = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SeleccionarPorId(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
            return ventaSeleccionada;
        }
    }
}

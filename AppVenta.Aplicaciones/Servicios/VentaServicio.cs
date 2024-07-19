using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVenta.Aplicaciones.Interfaces;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {

        IRepositorioMovimiento<Venta, Guid> repoVenta;
        IReposotorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;

        public VentaServicio(IRepositorioMovimiento<Venta, Guid> _repoVenta, IReposotorioBase<Producto, Guid> _repoProducto, IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle)
        {
            repoVenta = _repoVenta;
            repoProducto = _repoProducto;
            repoDetalle = _repoDetalle;
        }

        public Venta Agregar(Venta entidad)
        {
            if (entidad == null) throw new ArgumentException("La venta es requerida.");

            var ventaAgregada = repoVenta.Agregar(entidad);

            entidad.VentaDetalles.ForEach(detalle =>
            {
                var productoSeleccionado = repoProducto.SeleccionarPorId(detalle.productoId);
                if (productoSeleccionado == null)
                    throw new NullReferenceException("Usted está intentando vender un producto que no existe.");
            

            var detalleNuevo = new VentaDetalle();
                detalleNuevo.ventaId = ventaAgregada.ventaId;
                detalleNuevo.productoId = detalle.productoId;
                detalleNuevo.costoUnitario = productoSeleccionado.costo;
                detalleNuevo.precioUnitario = productoSeleccionado.precio;
                detalleNuevo.cantidadVendida = detalle.cantidadVendida;
                detalleNuevo.subtotal = detalleNuevo.precioUnitario * detalleNuevo.cantidadVendida;
                detalleNuevo.impuesto = detalleNuevo.subtotal * 15 / 100;
                detalleNuevo.total = detalleNuevo.subtotal + detalleNuevo.impuesto;
                repoDetalle.Agregar(detalleNuevo);

                productoSeleccionado.cantidadEnStock -= detalleNuevo.cantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalleNuevo.subtotal;
                entidad.impuesto += detalleNuevo.impuesto;
                entidad.total += detalleNuevo.total;
            });

            repoVenta.GuardarCambios();
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            repoVenta.Anular(entidadId);
            repoVenta.GuardarCambios();
        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();
        }

        public Venta SeleccionarPorId(Guid entidadId)
        {
            return repoVenta.SeleccionarPorId(entidadId);
        }
    }
}

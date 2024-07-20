using AppVenta.Aplicaciones.Interfaces;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {

        private readonly IRepositorioBase<Producto, Guid> repoProducto;

        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        } 
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null) throw new ArgumentException("El producto es requerido.");

            var resultadoProduco = repoProducto.Agregar(entidad);
            repoProducto.GuardarCambios();

            return resultadoProduco;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null) throw new ArgumentException("El producto es requerido.");

            repoProducto.Editar(entidad);
            repoProducto.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarCambios();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorId(Guid entidadId)
        {
            return repoProducto.SeleccionarPorId(entidadId);
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces;

namespace AppVenta.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadId> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>
    {

    }
}

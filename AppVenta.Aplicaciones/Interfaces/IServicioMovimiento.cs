using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces;

namespace AppVenta.Aplicaciones.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TEntidadId> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>
    {
        void Anular(TEntidadId entidadId);
    }
}

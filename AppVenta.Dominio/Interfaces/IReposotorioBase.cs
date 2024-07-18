using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces
{
    public interface IReposotorioBase<TEntidad, TEntidadId> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>, ITransaccion
    {

    }
}

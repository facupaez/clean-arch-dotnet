using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadId> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>, ITransaccion
    {
        void Anular(TEntidadId entidadId);
    }
}

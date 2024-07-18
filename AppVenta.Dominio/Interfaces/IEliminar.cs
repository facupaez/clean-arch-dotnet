using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces
{
    public interface IEliminar<TEntidadId>
    {
        void Eliminar(TEntidadId entidadId);
    }
}

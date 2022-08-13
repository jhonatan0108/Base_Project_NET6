using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Domain.ExternalServices.Facturas
{
    public interface IFacturasService 
    {
        List<string> GetNameFactura();
    }
}

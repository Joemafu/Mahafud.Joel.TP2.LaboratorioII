using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionBaseDeDatos : Exception
    {
        public ExcepcionBaseDeDatos() : base ("No fue posible conectarse a la base de datos.")
        {

        }
    }
}

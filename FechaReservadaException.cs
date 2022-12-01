using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    class FechaReservadaException:ApplicationException
    {
        public FechaReservadaException():base("Esta Fecha ya fue registrada") { }
        public FechaReservadaException(string msj) : base(msj) { }
        public FechaReservadaException(string msj, Exception ex) : base(msj, ex) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    internal class CamposVaciosException : InvalidOperationException
    {
        public CamposVaciosException() :
            base("Rellene todos los campos para continuar")
        {

        }
        public CamposVaciosException(Exception e) :
            base("Rellene todos los campos para continuar")
        {

        }
    }
}

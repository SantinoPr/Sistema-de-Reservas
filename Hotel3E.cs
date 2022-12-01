using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    class Hotel3E:Hotel2E
    {
        public Hotel3E(string nombre, string direccion, int nro, int tipo, double precioB)
            : base(nombre, direccion, nro, tipo, precioB) 
        {
            switch (tipo)
            {
                case 1:
                    CostoDia = Preciobase;
                    break;
                case 2:
                    CostoDia = Preciobase + (Preciobase * 0.80);
                    break;
                case 3:
                    CostoDia = Preciobase + (Preciobase * 1.50);
                    break;

            }
            CostoDia = CostoDia + (CostoDia * 0.40);
        }
        public override string ToString()
        {
            return String.Format("hotel;3;" + Direccion + ";" + Tipo + ";" + Nro + ";" + Nombre);
        }
    }
}

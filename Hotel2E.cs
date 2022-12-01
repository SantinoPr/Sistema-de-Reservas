using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace TP2_LABII
{
    [Serializable]
    class Hotel2E:Alojamiento
    {
        readonly string nombre;
        readonly int tipo;
        public int Tipo
        {
            get; set;
        }
        public int Piso
        {
            get;  set;
        }
        public string Nombre
        {
            get; set;
        }
        public double CostoDia
        {
            get;
            set;
        }
        List<Image> Imagenes = new List<Image>();
        
        public Hotel2E(string nombre, string direccion, int nro, int tipo, double precioB ) 
            : base(direccion, nro, precioB,tipo) 
        {
            this.nombre = nombre;
            this.tipo = tipo;

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
        }

        override public double Precio(int dias)
        {
            return Preciobase * dias;
        }

        public override string ToString()
        {
            return String.Format("hotel;2;" + Direccion + ";" + tipo + ";" + Nro + ";" + nombre);
        }
    }
}

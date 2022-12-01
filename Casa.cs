using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    class Casa:Alojamiento
    {
        enum TipoServicios{Wifi,Pileta,Cochera,Limpieza,Desayuno,Mascotas}
        public List<string> Servicios = new List<string>();
        private bool[] servs = new bool[6];

        public int MinDias { get;  set; }
        public int CantCamas { get;  set; }
        public string Nombre { get;  set; } = "";

        public Casa(string direccion, int minDias, double precio, int camas, int nro, List<int> servicios,  string nombre, bool[] sers) : base(direccion,nro,precio, camas) 
        {
            this.MinDias = minDias;
            this.CantCamas = camas;
            this.Nombre = nombre;
            sers.CopyTo(servs,0);
            string val;
            for(int i = 0; i < servicios.Count; i++)
            {
                val=((TipoServicios)servicios[i]).ToString();
                this.Servicios.Add(val);
            }
        }
        public void ModificarServicios(List<int> servicios)
        {
            Servicios.Clear();
            string val;
            for (int i = 0; i < servicios.Count; i++)
            {
                val = ((TipoServicios)servicios[i]).ToString();
                this.Servicios.Add(val);
            }
        }
        override public double Precio(int dias)
        {
            int pServcio = 0;

            foreach (bool b in servs)
            {
                if (b) pServcio += 200;
            }

            return (Preciobase + pServcio) * dias;
        }
        public override string ToString()
        {
            return String.Format("casa;" + Nro + ";" + Direccion + ";" + Servicios.Count + ";" + CantCamas+";"+Preciobase+";"+MinDias);
        }

    }
}

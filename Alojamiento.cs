 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    abstract class Alojamiento: IComparable
    {
        Bitmap[] imagenes = new Bitmap[5];
        List<Reserva> reservas = new List<Reserva>();
        public string Direccion
        {
            get; set;
        }
        public int Nro
        {
            get; set;
        }
        public int Camas
        {
            get;  set;
        }
        public double Preciobase
        {
            get;  set;
        }
        public List<Reserva> Reservas { get { return reservas; } }
        public Bitmap Getimagen(int pos)
        {
            return imagenes[pos];
        }
        public void Setimagen(Bitmap image, int pos)
        {
            imagenes[pos] = image;
        }
        public Alojamiento(string direccion, int nro, double precioBase, int camas) 
        {
            this.Direccion = direccion;
            this.Nro = nro;
            this.Preciobase = precioBase;
            Camas = camas;
        }

        public void AgregarReserva(Reserva reserva)
        {
            reservas.Add(reserva);
        }
            
        public int CompareTo(object obj1)
        {
            Alojamiento obj = (Alojamiento)obj1;
            return this.Nro.CompareTo(obj.Nro);
        }

        public abstract double Precio(int dias);
    }
}

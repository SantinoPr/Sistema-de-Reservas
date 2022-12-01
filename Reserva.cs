using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    class Reserva
    {
        public Cliente cliente;
        public int CantDias
        {
            get;
            set;
        }
        public int CantPersonas
        {
            get;
            set;
        }
        public int Nro { get; set; }
        public DateTime FechaIn { get; private set; }
        public DateTime FechaOut { get; private set; }
        public List<DateTime> Fechas=new List<DateTime>();
        public Alojamiento alojamiento { get; private set; }
        public double PrecioTotal
        {
            get;
            set;
        }
        public Reserva(Cliente cliente, Alojamiento alojamiento, int dias, DateTime fechain, DateTime fechaout, double precio, int nro, int cantPersonas)
        {
            this.cliente = cliente;
            this.CantDias = dias;
            this.FechaIn = fechain;
            this.FechaOut = fechaout;
            this.alojamiento = alojamiento;
            this.PrecioTotal = precio;
            this.CantPersonas = cantPersonas;
            this.Nro = nro;
            bool coinciden = false;
            
            int cantdias = Convert.ToInt32(fechaout.Day) - Convert.ToInt32(fechain.Day);

            for (DateTime date = fechain; date.Date <= fechaout.Date; date = date.AddDays(1))
            {
                Fechas.Add(date);
            }

            if (alojamiento != null)
            {
                foreach (Reserva reserva in alojamiento.Reservas)
                {
                    for (int i = 0; i < Fechas.Count; i++)
                    {
                        if (reserva.Fechas.Contains(Fechas[i]))
                            coinciden = true;
                    }
                }
                if (coinciden)
                    throw new FechaReservadaException("Fechas ya reservadas, seleccione otras...");
            }
        }
        public override string ToString()
        {
            string aloj = "";
            if (alojamiento.GetType() == typeof(Casa))
                aloj = "casa";
            else if (alojamiento.GetType() == typeof(Hotel2E))
                aloj = "hotel2";
            else if (alojamiento.GetType() == typeof(Hotel3E))
                aloj = "hotel3";

            string fechain = FechaIn.ToString("dd/MM/yyyy"), fechaout = FechaOut.ToString("dd/MM/yyyy");


            return String.Format(cliente.Nombre + ";" + cliente.DNI + ";" + aloj.ToString() +";" + alojamiento.Direccion +
                ";" + alojamiento.Nro + ";" + fechain + ";" + fechaout + ";" + PrecioTotal + ";" + CantDias+";"+CantPersonas + ";" + this.Nro);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TP2_LABII
{
    [Serializable]
    class Empresa
    {

        List<Reserva> reservasRealizadas = new List<Reserva>();
        List<Cliente> clientesRegistrados = new List<Cliente>();
        List<Alojamiento> alojamientos = new List<Alojamiento>();

        public double PrecioBase;
        public List<Reserva> ReservasRegistradas { get { return reservasRealizadas; } }

        public List<Alojamiento> Alojamientos { get { return alojamientos; } }

        public List<Cliente> ClientesRegistrados { get { return clientesRegistrados; } }

        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool IniciarSesion(string usuario, string contraseña)
        {
            string usuario1 = "sa";
            string constrasenia1 = "sa";
            if (usuario==usuario1 && contraseña== constrasenia1)
            {
                return true;
            }
            return false;
        }
        public void AgregarAlojamiento(Alojamiento alojamiento)
        {
            alojamientos.Add(alojamiento);
        }
        public void AgregarCliente(Cliente cliente)
        {
            clientesRegistrados.Add(cliente);
        }
        public void AgregarReserva(Reserva reserva)
        {
            reservasRealizadas.Add(reserva);
            reserva.alojamiento.AgregarReserva(reserva);
        }
        public void EliminarReserva(Reserva reserva)
        {
            reserva.alojamiento.Reservas.Remove(reserva);
            reservasRealizadas.Remove(reserva);
        }
        public void EliminarAlojamiento(Alojamiento obj)
        {
            alojamientos.Remove(obj);
        }
        public void EliminarCliente(Cliente obj)
        {
           clientesRegistrados.Remove(obj);
        }
        public Alojamiento BinarySearch(int key)
        {

            int minNum = 0;
            int maxNum = alojamientos.Count - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == alojamientos[mid].Nro)
                {
                    return alojamientos[mid];
                }
                else if (key < alojamientos[mid].Nro)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return null;
        }
       
        //public void LimpiarAlojamiento(Alojamiento a)
        //{
        //    if (a.Reservas.Count > 0 && a != null)
        //    {
        //        foreach (Reserva r in reservasRealizadas)
        //        {
        //            try
        //            {
        //                if (r != null)
        //                {
        //                    if (r.alojamiento == a)
        //                    {
        //                        EliminarReserva(r);
        //                    }
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }
        //}
        public Cliente ClienteSearch(int key)
        {
            int i = 0;
            if (clientesRegistrados.Count > 0)
            {
                while (clientesRegistrados[i].DNI != key)
                {
                    i++;
                }
                return clientesRegistrados[i];
            }
            else
                return null;
        }
        
        public Reserva ReservaSearch(int key)
        {
            int minNum = 0;
            int maxNum = reservasRealizadas.Count - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == reservasRealizadas[mid].Nro)
                {
                    return reservasRealizadas[mid];
                }
                else if (key < reservasRealizadas[mid].Nro)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return null;
        }
    }
}

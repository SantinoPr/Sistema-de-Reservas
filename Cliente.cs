using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LABII
{
    [Serializable]
    class Cliente
    {
        string nombre;
        int dni;
        public int DNI
        {
            get { return dni; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public Cliente(string nombre, int dni) 
        {
            this.nombre = nombre;
            this.dni = dni;
        }
        public override string ToString()
        {
            return String.Format(nombre+";"+dni);
        }
    }
}

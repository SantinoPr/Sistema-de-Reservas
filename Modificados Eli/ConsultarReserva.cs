using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_LABII
{
    public partial class ConsultarReserva : Form
    {
        public ConsultarReserva()
        {
            InitializeComponent();
            this.DGVReservas.BackgroundColor = Color.FromArgb(192, 192, 255);
        }

        private void ConsultarReserva_Load(object sender, EventArgs e)
        {

        }
    }
}

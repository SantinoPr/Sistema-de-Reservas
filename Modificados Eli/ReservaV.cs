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
    public partial class ReservaV : Form
    {
        public ReservaV()
        {
            InitializeComponent();
        }
        DateTime ingreso;
        DateTime egreso;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ingreso = monthCalendar1.SelectionStart;
            egreso = ingreso.AddDays(Convert.ToInt32(nUdDias.Value));
            labelIngreso.Text = String.Format(ingreso.Day+"/"+ingreso.Month+"/"+ingreso.Year);
            labelEgreso.Text = String.Format(egreso.Day + "/" + egreso.Month + "/" + egreso.Year);
            labelIngreso.Visible = true;
        }

        private void ReservaV_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ReservaV_Leave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnExistentes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nUdDias_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

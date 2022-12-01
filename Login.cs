using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_LABII
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
                tbUsuario.Text = "";
        }
        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
                tbUsuario.Text = "Usuario";
        }
        private void tbClave_Leave(object sender, EventArgs e)
        {
            if (tbClave.Text == "")
                tbClave.Text = "Contraseña";

        }

        private void tbClave_Enter(object sender, EventArgs e)
        {
            if (tbClave.Text == "Contraseña")
                tbClave.Text = "";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //formprincipal = new Form1();
            //try
            //{
            //    string mailOrigen = "santino-albarello@hotmail.com";
            //    string mailDestino = "santo.iban.albarello@gmail.com";
            //    string mensaje = "Recibimos una solicitud de restablecimiento de tu contraseña, Confirmala para elejir una nueva";
            //    MailMessage mail = new MailMessage(mailOrigen, mailDestino, "<p>Restablecimiento de contraseña</p>", mensaje);
            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //    smtp.Port = 587;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new System.Net.NetworkCredential(mailOrigen, "Chupaelperro1");
            //    smtp.Send(mail);
            //    smtp.Dispose();
            //}
            //catch (Exception ex)
            //{

            //}

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tbClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

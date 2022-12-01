using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Net.Mail;

namespace TP2_LABII
{
    public partial class Form1 : Form
    {

        //Status strip

        ///////Variables/////////
        #region
        public Form1()
        {
            InitializeComponent();
            this.DGVCasas.BackgroundColor = Color.FromArgb(192, 192, 255);
            this.DGVHoteles.BackgroundColor = Color.FromArgb(192, 192, 255);
        }
        bool Modificando = false;
        Alojamiento Obj2;
        WebV webV;
        ReservaV reservaV;
        TicketV V;
        Reserva reserva;
        AgregarAlojamiento agregar;
        Cliente cliente;
        Login login = new Login();
        Inicio Vinicio;
        Bitmap imagen;
        ModificarImg modificarImg;
        Alojamiento alojamiento;
        Empresa empresa;
        List<Alojamiento> alojamientos = new List<Alojamiento>();
        ClientesV clientesV = new ClientesV();
        ClientesVNuevo clientesVNuevo = new ClientesVNuevo(); //Agregado
        ConsultarReserva consultarReservasV = new ConsultarReserva();
        int nro = 0;
        string pathEmpresa = Application.StartupPath + "\\Archivos\\Empresa.txt";
        string pathExportacion = Application.StartupPath + "\\Archivos\\Exportacion\\";
        bool bandera = false;

        ////////////////////////
        #endregion

        ///////Deserialización/////////       
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                if (File.Exists(pathEmpresa))
                {
                    FileStream fs = new FileStream(pathEmpresa, FileMode.Open, FileAccess.Read);
                    BinaryFormatter bs = new BinaryFormatter();
                    if (fs.Length > 0)
                        empresa = (Empresa)bs.Deserialize(fs);
                    else
                        empresa = new Empresa();
                    ActualizarGraficoPastel();
                    ActualizarGraficoBarras();
                    fs.Dispose(); fs.Close();

                }
                else
                {
                    FileStream fs = new FileStream(pathEmpresa, FileMode.Create);
                    empresa = new Empresa();
                    fs.Dispose(); fs.Close();
                }
                //Eventos de la ventana de Login
                login.btnInicio.Click += new System.EventHandler(login_btnInicio_Click);
                login.btnCerrar.Click += new System.EventHandler(login_btnCerrar_Click);
                login.ShowDialog();
                login.btnInicio.Click -= new System.EventHandler(login_btnInicio_Click);
                login.btnCerrar.Click -= new System.EventHandler(login_btnCerrar_Click);

                string linea;

                foreach (Cliente c in empresa.ClientesRegistrados)
                {
                    linea = c.ToString();
                    string[] campos = linea.Split(';');
                    clientesV.DGVClientes.Rows.Add(campos);
                }
                comBAlojamiento.SelectedIndex = 0;
                if (MessageBox.Show("¿Desea cambiar el precio base?", "Atencion", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Vinicio = new Inicio();
                    Vinicio.textBox1.KeyPress += new KeyPressEventHandler(Vinicio_textBox1_KeyPress);
                    try
                    {
                        if (Vinicio.ShowDialog() == DialogResult.OK)
                        {
                            empresa.PrecioBase = Convert.ToDouble(Vinicio.textBox1.Text);
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Porfavor ingrese un valor numérico, distinto de cero.");
                        Vinicio.ShowDialog();
                    }
                    finally
                    {
                        Vinicio.Dispose();
                        Vinicio.Close();
                    }
                }
            }         
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        ////////Login//////////
        #region
        //Boton de inicio sesion de la ventana Login
        private void login_btnInicio_Click(object sender, EventArgs e)
        {
            string usuario = login.tbUsuario.Text;
            string clave = login.tbClave.Text;
            bool correcta=empresa.IniciarSesion(usuario, clave);
            if (correcta == false)
            {
                MessageBox.Show("Nombre de Usuario o Contraseña incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else         
               login.Close();
            
        }
        private void login_btnCerrar_Click(object sender, EventArgs e)
        {
            login.Close();
            this.Close();
        }


        //////////////////////////////
        #endregion

        ///////Serialización/////////
        #region
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream(pathEmpresa, FileMode.Truncate, FileAccess.Write);

            BinaryFormatter bs = new BinaryFormatter();
            bs.Serialize(fs, empresa);
            fs.Dispose();
            fs.Close();
        }
        //////////////////////////////
        #endregion

        ///////Exportacion/////////
        #region


        //////////////////////////////
        #endregion

        ///////Importacion/////////
        #region

        //Importar desde toolstrip
        private void importarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell DGVCell = consultarReservasV.DGVReservas.SelectedCells[0];
            DataGridViewRow indexRow = consultarReservasV.DGVReservas.Rows[DGVCell.RowIndex];

            Reserva obj1 = empresa.ReservaSearch(Convert.ToInt32(indexRow.Cells[0].Value));
            Alojamiento aloj1 = obj1.alojamiento;
            empresa.EliminarReserva(obj1);

            consultarReservasV.DGVReservas.Rows.Clear();
            foreach (Reserva obj in empresa.ReservasRegistradas)
            {
                string[] campos = new string[3];

                campos[0] = obj.Nro.ToString();
                if (obj.alojamiento.GetType() == typeof(Casa))
                    campos[1] = "Casa";
                if (obj.alojamiento.GetType() == typeof(Hotel2E) || obj.alojamiento.GetType() == typeof(Hotel3E))
                    campos[1] = "Hotel";
                if (obj.cliente != null)
                {
                    campos[2] = obj.cliente.DNI.ToString();
                }

                consultarReservasV.DGVReservas.Rows.Add(campos);
            }
            ActualizarGraficoPastel();
            ActualizarGraficoBarras();
        }

        //Importar desde alojamiento
        private void reservaV_btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string[] num = reservaV.lblTitulo.Text.Split(' ');

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                    {
                        string[] all = File.ReadAllLines(ofd.FileName);
                        int i = 0;
                        DateTime fin, fout; int nro, personas, dias; double precio; Alojamiento obj = null; Cliente cliente;
                        while (i < all.Length)
                        {
                            if (all[i] != null)
                            {
                                string[] campos = all[i].Split(';');
                                //Crea parametros

                                //Setea los label iguales para ambos
                                fin = DateTime.ParseExact(campos[5], "dd/MM/yyyy", new CultureInfo("es-ES"));
                                fout = DateTime.ParseExact(campos[6], "dd/MM/yyyy", new CultureInfo("es-ES"));
                                personas = Convert.ToInt32(campos[9]);
                                dias = Convert.ToInt32(campos[8]);
                                precio = Convert.ToDouble(campos[7]);
                                nro = Convert.ToInt32(campos[10]);
                                string[] numAloj = reservaV.lblTitulo.Text.Split(' ');
                                int n = Convert.ToInt32(numAloj[2]);
                                obj = empresa.BinarySearch(n);
                                cliente = new Cliente(campos[0], Convert.ToInt32(campos[1]));

                                //Porque se sacan los datos de los labels para agregar:
                                reservaV.labelIngreso.Text = fin.ToShortDateString();
                                reservaV.labelEgreso.Text = fout.ToShortDateString();
                                reservaV.lblNombre.Text = campos[0];
                                reservaV.lblDNI.Text = campos[1];
                                reservaV.labelCostoT.Text = (Convert.ToDouble(campos[7])).ToString();
                                reservaV.nUdDias.Value = Convert.ToInt32(dias);
                                reservaV.nUdPersonas.Value = Convert.ToInt32(personas);

                                //Crea la reserva
                                reserva = new Reserva(cliente, obj, dias,
                                   fin,
                                   fout,
                                   precio,
                                   nro,
                                   personas
                                   );

                                if (empresa.ReservaSearch(reserva.Nro) == null) empresa.AgregarReserva(reserva);
                                i++;
                            }
                            ActualizarlbDatos(obj);
                        }
                        MessageBox.Show("Se importaron " + i + " reservas");
                    }
                    else MessageBox.Show("No se encontró el archivo seleccionado", "Atención");
                }
            }
            catch (FechaReservadaException)
            {
                MessageBox.Show("Fecha ya reservada", "Atencion");
            }
        }

        //////////////////////////
        #endregion

        ///////Form Principal/////////
        #region
        //Eventos a la hora de reservar
        private void Vinicio_textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void DGVHoteles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            reservaV = new ReservaV();
            int identif;
            Alojamiento obj;
            double costo;
            try
            {
                if (DGVHoteles.Rows[e.RowIndex].Cells[2].Value.ToString() != null && bandera==false)
                {
                    if (DGVHoteles.Rows[e.RowIndex].Cells[2].Value.ToString() == "2 Estrellas")
                    {
                        identif = Convert.ToInt32(DGVHoteles.Rows[e.RowIndex].Cells[3].Value);
                        empresa.Alojamientos.Sort();
                        obj = empresa.BinarySearch(identif);
                        Obj2 = obj;
                        reservaV.lblTitulo.Text = String.Format("Hotel 2 Estrellas - " + ((Hotel2E)obj).Nombre);
                        ActualizarlbDatos(obj);

                        reservaV.nUdDias.Minimum = 1;
                        costo = ((Hotel2E)obj).CostoDia * Convert.ToInt32(reservaV.nUdDias.Value);
                        costoAlojamiento = costo;
                        reservaV.labelCostoT.Text = String.Format("$" + costo);

                        reservaV.nUdDias.ValueChanged += new EventHandler(reservaV_nUdDias_ValueChanged);
                        reservaV.btnNuevo.Click += new System.EventHandler(reservaV_btnNuevo_Click);
                        reservaV.btnExistentes.Click += new System.EventHandler(reservaV_btnExistentes_Click);
                        reservaV.btnGuardar.Click +=new System.EventHandler(reservaV_btnGuardar_Click);
                        reservaV.pictureBox1.Image = (Image)obj.Getimagen(0);
                        reservaV.pictureBox2.Image = (Image)obj.Getimagen(1);
                        reservaV.pictureBox3.Image = (Image)obj.Getimagen(2);
                        reservaV.pictureBox4.Image = (Image)obj.Getimagen(3);
                       
                        nro++;
                        reservaV.ShowDialog();
                        reservaV.nUdDias.ValueChanged -= new EventHandler(reservaV_nUdDias_ValueChanged);
                        reservaV.btnNuevo.Click -= new System.EventHandler(reservaV_btnNuevo_Click);
                        reservaV.btnExistentes.Click -= new System.EventHandler(reservaV_btnExistentes_Click);
                        reservaV.btnGuardar.Click -= new System.EventHandler(reservaV_btnGuardar_Click);

                    }
                    if (DGVHoteles.Rows[e.RowIndex].Cells[2].Value.ToString() == "3 Estrellas")
                    {
                        identif = Convert.ToInt32(DGVHoteles.Rows[e.RowIndex].Cells[3].Value);
                        empresa.Alojamientos.Sort();
                        obj = empresa.BinarySearch(identif);
                        reservaV.lblTitulo.Text = String.Format("Hotel 3 Estrellas - " + ((Hotel3E)obj).Nombre);

                        ActualizarlbDatos(obj);

                        reservaV.nUdDias.Minimum = 1;
                        costo = ((Hotel3E)obj).CostoDia * Convert.ToInt32(reservaV.nUdDias.Value);
                        reservaV.labelCostoT.Text = String.Format("$" + costo);

                        reservaV.btnNuevo.Click += new System.EventHandler(reservaV_btnNuevo_Click);
                        reservaV.btnExistentes.Click += new System.EventHandler(reservaV_btnExistentes_Click);
                        reservaV.btnImportar.Click += new System.EventHandler(reservaV_btnImportar_Click);
                        reservaV.btnGuardar.Click += new System.EventHandler(reservaV_btnGuardar_Click);
                        reservaV.nUdDias.ValueChanged += new EventHandler(reservaV_nUdDias_ValueChanged);
                        Obj2 = obj;
                        CheckearDatosReserva(obj);
                        reservaV.ShowDialog();
                        nro++;
                        reservaV.btnImportar.Click -= new System.EventHandler(reservaV_btnImportar_Click);
                        reservaV.btnNuevo.Click -= new System.EventHandler(reservaV_btnNuevo_Click);
                        reservaV.btnExistentes.Click -= new System.EventHandler(reservaV_btnExistentes_Click);
                        reservaV.btnGuardar.Click -= new System.EventHandler(reservaV_btnGuardar_Click);

                        reservaV.nUdDias.ValueChanged -= new EventHandler(reservaV_nUdDias_ValueChanged);
                    }

                }
                bandera = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
            }
        }
        private void DGVCasas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bandera == false)
            {
                reservaV = new ReservaV();
                int identif;
                Casa obj;
                try
                {
                    identif = Convert.ToInt32(DGVCasas.Rows[e.RowIndex].Cells[1].Value);
                    empresa.Alojamientos.Sort();
                    obj = (Casa)empresa.BinarySearch(identif);
                    Obj2 = obj;
                    reservaV.lblTitulo.Text = String.Format("Casa Nro: " + obj.Nro);

                    ActualizarlbDatos(obj);

                    double costo = obj.Preciobase * Convert.ToInt32(reservaV.nUdDias.Value);
                    costoAlojamiento = costo;

                    reservaV.labelCostoT.Text = String.Format("$" + costo);

                    reservaV.btnNuevo.Click += new System.EventHandler(reservaV_btnNuevo_Click);
                    reservaV.btnImportar.Click += new System.EventHandler(reservaV_btnImportar_Click);
                    reservaV.btnExistentes.Click += new System.EventHandler(reservaV_btnExistentes_Click);
                    reservaV.btnGuardar.Click += new System.EventHandler(reservaV_btnGuardar_Click);
                    reservaV.nUdDias.ValueChanged += new EventHandler(reservaV_nUdDias_ValueChanged);
                    reservaV.pictureBox1.Image = (Image)obj.Getimagen(0);
                    reservaV.pictureBox2.Image = (Image)obj.Getimagen(1);
                    reservaV.pictureBox3.Image = (Image)obj.Getimagen(2);
                    reservaV.pictureBox4.Image = (Image)obj.Getimagen(3);

                    CheckearDatosReserva(obj);
                    reservaV.ShowDialog(); 
                    
                    reservaV.btnImportar.Click -= new System.EventHandler(reservaV_btnImportar_Click);
                    reservaV.btnNuevo.Click -= new System.EventHandler(reservaV_btnNuevo_Click);
                    reservaV.btnExistentes.Click -= new System.EventHandler(reservaV_btnExistentes_Click);
                    reservaV.nUdDias.ValueChanged -= new EventHandler(reservaV_nUdDias_ValueChanged);
                    reservaV.btnGuardar.Click -= new System.EventHandler(reservaV_btnGuardar_Click);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            bandera = false;

        }

        private void reservaV_nUdDias_ValueChanged(object sender, EventArgs e)
        {
            DateTime ingreso = reservaV.monthCalendar1.SelectionStart;
            DateTime egreso;

            egreso = ingreso.AddDays(Convert.ToInt32(reservaV.nUdDias.Value));
            reservaV.labelEgreso.Text = String.Format(egreso.Day + "/" + egreso.Month + "/" + egreso.Year);
            reservaV.labelEgreso.Visible = true;
            CheckearDatosReserva(Obj2);
        }
        private void reservaV_btnNuevo_Click(object sender, EventArgs e)
        {
            clientesVNuevo = new ClientesVNuevo();
            if (clientesVNuevo.ShowDialog() == DialogResult.OK)
            {
                string[] campos = new string[2];

                try
                {
                    string nombre = clientesVNuevo.tBNombre.Text;
                    int dni = Convert.ToInt32(clientesVNuevo.tBDNI.Text);

                    cliente = new Cliente(nombre, dni);
                    empresa.AgregarCliente(cliente);
                    campos[0] = nombre;
                    campos[1] = dni.ToString();

                    clientesV.DGVClientes.Rows.Add(campos);
                    reservaV.lblNombre.Text = nombre;
                    reservaV.lblDNI.Text = dni.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    clientesVNuevo.Close();
                }

                CheckearDatosReserva(Obj2);
            }
        }
        private void reservaV_btnExistentes_Click(object sender, EventArgs e)
        {
            string nombre = "";
            int dni = 0;

            if (clientesV.ShowDialog() == DialogResult.OK)
            {
                nombre = clientesV.DGVClientes.SelectedRows[0].Cells[0].Value.ToString();
                dni = Convert.ToInt32(clientesV.DGVClientes.SelectedRows[0].Cells[1].Value.ToString());
            }
            reservaV.lblNombre.Text = nombre;
            reservaV.lblDNI.Text = dni.ToString();
            CheckearDatosReserva(Obj2);
        }
        private void btnFiltrarC_Click(object sender, EventArgs e)
        {
            DGVCasas.Rows.Clear();
            if (comBAlojamiento.SelectedIndex == 0)
            {
                int cantCamas = Convert.ToInt32(numericUpDown1.Value);
                string localidad = cBLocalidadC.Text;
                List<string> servicios = new List<string>();
                List<Casa> casas = new List<Casa>();
                bool existe = false;
                bool existe1 = false;
                bool existe2 = true;

                if (cbWIFI.Checked)
                    servicios.Add("Wifi");
                if (cbPileta.Checked)
                    servicios.Add("Pileta");
                if (cbCochera.Checked)
                    servicios.Add("Cochera");
                if (cbLimpieza.Checked)
                    servicios.Add("Limpieza");
                if (cbDesayuno.Checked)
                    servicios.Add("Desayuno");
                if (cbMascotas.Checked)
                    servicios.Add("Mascotas");

                foreach (Alojamiento obj in empresa.Alojamientos)
                {
                    if (obj.GetType() == typeof(Casa))
                    {
                        Casa casa1 = (Casa)obj;
                        if (casa1.Direccion == localidad)
                            existe = true;
                        if (casa1.CantCamas >= cantCamas)
                            existe1 = true;
                        if (servicios.Count > 0)
                        {
                            for (int i = 0; i < servicios.Count; i++)
                            {
                                if (!(casa1.Servicios.Contains(servicios[i]))) existe2 = false;
                            }
                        }
                        else existe2 = true;

                        if (existe && existe1 && existe2)
                            casas.Add(casa1);
                    }
                    existe = false;
                    existe1 = false;
                    existe2 = true;
                }
                foreach (Casa casa in casas)
                {
                    string[] campos = new string[6];
                    campos[0] = casa.Nombre;
                    campos[1] = casa.Nro.ToString();
                    campos[2] = casa.Direccion;
                    campos[3] = casa.Servicios.Count.ToString();
                    campos[4] = casa.CantCamas.ToString();
                    campos[5] = casa.Preciobase.ToString();
                    DGVCasas.Rows.Add(campos);
                }
            }
            if (comBAlojamiento.SelectedIndex == 1)
            {
                DGVHoteles.Rows.Clear();
                bool existe = false;
                bool existe1 = false;
                string localidad = cBLocalidad.Text;
                List<Hotel2E> hoteles2 = new List<Hotel2E>();
                List<Hotel3E> hoteles3 = new List<Hotel3E>();

                int tipo = 1;
                if (rbSimple.Checked)
                    tipo = 0;
                if (rbDoble.Checked)
                    tipo = 2;
                if (rbTriple.Checked)
                    tipo = 3;


                if (rbH2.Checked)
                {
                    foreach (Alojamiento obj in empresa.Alojamientos)
                    {
                        if (obj.GetType() == typeof(Hotel2E))
                        {
                            Hotel2E hotel = (Hotel2E)obj;

                            if (hotel.Direccion == localidad)
                                existe = true;
                            if (hotel.Tipo == tipo)
                                existe1 = true;

                            if (existe && existe1)
                                hoteles2.Add(hotel);
                        }
                        existe = false;
                        existe1 = false;
                    }
                    foreach (Hotel2E hotel in hoteles2)
                    {
                        string[] campos = new string[6];
                        campos[0] = "2";
                        campos[1] = hotel.Direccion;
                        campos[2] = hotel.Tipo.ToString();
                        campos[3] = hotel.Nro.ToString();
                        campos[4] = hotel.Nombre;
                        campos[5] = hotel.Preciobase.ToString();
                        DGVHoteles.Rows.Add(campos);
                    }
                }
                if (rbH3.Checked)
                {
                    foreach (Alojamiento obj in empresa.Alojamientos)
                    {
                        if (obj.GetType() == typeof(Hotel3E))
                        {
                            Hotel3E hotel = (Hotel3E)obj;

                            if (hotel.Direccion == localidad)
                                existe = true;
                            if (hotel.Tipo == tipo)
                                existe1 = true;

                            if (existe && existe1)
                                hoteles3.Add(hotel);
                        }
                        existe = false;
                        existe1 = false;
                    }
                    foreach (Hotel3E hotel in hoteles3)
                    {
                        string[] campos = new string[6];
                        campos[0] = "3";
                        campos[1] = hotel.Direccion;
                        campos[2] = hotel.Tipo.ToString();
                        campos[3] = hotel.Nro.ToString();
                        campos[4] = hotel.Nombre;
                        campos[5] = hotel.Preciobase.ToString();
                        DGVHoteles.Rows.Add(campos);
                    }
                }
            }
        }
        private void reservaV_btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Advertencia", "Esta seguro de generar la reserva?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(r==DialogResult.OK)
            {
                try
                {
                    DateTime fechain = reservaV.monthCalendar1.SelectionStart;
                    DateTime fechaout = DateTime.ParseExact(reservaV.labelEgreso.Text.ToString(), "dd/MM/yyyy", null);
                    int dias = Convert.ToInt32(reservaV.nUdDias.Value);
                    int personas = Convert.ToInt32(reservaV.nUdPersonas.Value);
                    double costo = 0;
                    if (Obj2 is Casa)
                    {
                        costo = Obj2.Preciobase * Convert.ToInt32(reservaV.nUdDias.Value);
                        costoAlojamiento = costo;
                    }
                 
                    cliente = empresa.ClienteSearch(Convert.ToInt32(reservaV.lblDNI.Text));
                    if (cliente != null)
                        reserva = new Reserva(cliente, Obj2, dias, fechain, fechaout, costo, nro, personas);
                    else
                    {
                        empresa.AgregarCliente(cliente = new Cliente(reservaV.lblNombre.Text, Convert.ToInt32(reservaV.lblDNI.Text)));
                        reserva = new Reserva(cliente, Obj2, dias, fechain, fechaout, costo, nro, personas);
                    }
                    empresa.AgregarReserva(reserva);
                    nro++;

                    ActualizarGraficoPastel();
                    ActualizarGraficoBarras();
                    reservaV.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        ////////////////////////////
        #endregion

        ///////Reservas/////////
        #region
        Rectangle limites;

        //Métodos de apoyo
        private void ActualizarlbDatos(Alojamiento obj)
        {
            reservaV.lBDatos.Items.Clear();
            reservaV.lBDatos.Items.Add("Direccion: " + obj.Direccion);

            if (obj is Hotel2E || obj is Hotel3E)
            {
                switch (((Hotel2E)obj).Tipo)
                {
                    case 1:
                        reservaV.lBDatos.Items.Add("Tipo de Habitacion: Simple");
                        break;
                    case 2:
                        reservaV.lBDatos.Items.Add("Tipo de Habitacion: Doble");
                        break;
                    case 3:
                        reservaV.lBDatos.Items.Add("Tipo de Habitacion: Triple");
                        break;
                }

                reservaV.lBDatos.Items.Add(" ");
                foreach (Reserva reserva in obj.Reservas)
                {
                    reservaV.lBDatos.Items.Add("+" + reserva.FechaIn + " a " + reserva.FechaOut);
                }
            }
            else
            {
                Casa objC = (Casa)obj;
                reservaV.lBDatos.Items.Add("Cant. Camas: " + objC.CantCamas);
                reservaV.lBDatos.Items.Add("Dias Min. Exigidos: " + objC.MinDias);
                reservaV.nUdDias.Minimum = objC.MinDias;
                reservaV.lBDatos.Items.Add("Servicios:");
                for (int i = 0; i < objC.Servicios.Count; i++)
                {
                    reservaV.lBDatos.Items.Add("  +" + objC.Servicios[i]);
                }
                reservaV.lBDatos.Items.Add("Precio: $" + objC.Preciobase);
                reservaV.lBDatos.Items.Add("Dias Reservado:");
                reservaV.pictureBox1.Image = (Image)obj.Getimagen(0);
                reservaV.pictureBox2.Image = (Image)obj.Getimagen(1);
                reservaV.pictureBox3.Image = (Image)obj.Getimagen(2);
                reservaV.pictureBox4.Image = (Image)obj.Getimagen(3);

                foreach (Reserva reserva in obj.Reservas)
                {
                    reservaV.lBDatos.Items.Add("+" + reserva.FechaIn + " a " + reserva.FechaOut);
                }
            }

        }
        private void InicializarVentanaParaConsultarReservas()
        {
            consultarReservasV.DGVReservas.Rows.Clear();
            //Carga los rows
            foreach (Reserva obj in empresa.ReservasRegistradas)
            {
                string[] campos = new string[3];
                if (obj != null)
                {
                    campos[0] = obj.Nro.ToString();
                    if (obj.alojamiento != null)
                    {
                        if (obj.alojamiento is Casa)
                            campos[1] = "Casa";
                        else if (obj.alojamiento is Hotel2E || obj.alojamiento is Hotel3E)
                            campos[1] = "Hotel";
                    }
                    //
                    else
                        campos[1] = "No Especificado";
                    //
                    if (obj.cliente != null)
                    {
                        campos[2] = obj.cliente.DNI.ToString();
                    }
                    else
                        campos[2] = "No Especificado";

                    consultarReservasV.DGVReservas.Rows.Add(campos);
                }
            }
        }
        private void Exportar_Reserva(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell DGVCell = consultarReservasV.DGVReservas.SelectedCells[0];
                DataGridViewRow indexRow = consultarReservasV.DGVReservas.Rows[DGVCell.RowIndex];
                reserva = empresa.ReservaSearch(Convert.ToInt32(indexRow.Cells[0].Value));

                if (reserva != null)
                {
                    string nombre = "Reserva_" + DateTime.Now.ToLongDateString() + ".txt";
                    Alojamiento aloj = reserva.alojamiento;
                    if (aloj is Casa)
                    {
                        Casa casa = (Casa)aloj;

                        FileStream fs1 = new FileStream(pathExportacion + nombre, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs1);

                        sw.WriteLine(reserva.ToString());
                        sw.Close();
                        fs1.Close();

                    }
                    if (aloj is Hotel2E)
                    {
                        Hotel2E hotel = (Hotel2E)aloj;

                        FileStream fs1 = new FileStream(pathExportacion + nombre, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs1);

                        sw.WriteLine(reserva.ToString());
                        sw.Close();
                        fs1.Close();
                    }
                    if (aloj is Hotel3E)
                    {
                        Hotel3E hotel = (Hotel3E)aloj;

                        FileStream fs1 = new FileStream(pathExportacion + nombre, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs1);

                        sw.WriteLine(reserva.ToString());
                        sw.Close();
                        fs1.Close();
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void ActualizarLista(object sender, EventArgs e)
        {
            foreach (Alojamiento aloj in empresa.Alojamientos)
            {
                if (aloj.Reservas.Count > 0)
                    aloj.Reservas.Clear();
            }
            empresa.ReservasRegistradas.Clear();
            consultarReservasV.DGVReservas.Rows.Clear();
        }
        private void InicializarVentanaParaHacerReservas()
        {
            reservaV.lblDNI.Text = reserva.cliente.DNI.ToString();
            reservaV.lblNombre.Text = reserva.cliente.Nombre.ToString();
            reservaV.monthCalendar1.SetDate(reserva.FechaIn);
            reservaV.nUdDias.Value = reserva.CantDias;
            reservaV.nUdPersonas.Value = reserva.CantPersonas;
            reservaV.labelEgreso.Text = reserva.FechaOut.ToString();
        }
        //Métodos de checkeo
        private void CheckearDatosReserva(Alojamiento obj)
        {
            //Revisa si se completaron
            bool ingreso = reservaV.labelIngreso.Text != "...", egreso = reservaV.labelEgreso.Text != "...", cliente = reservaV.lblDNI.Text != "...";
            if (obj != null) reservaV.labelCostoT.Text = obj.Precio(Convert.ToInt32(reservaV.nUdDias.Value)).ToString();
            if (ingreso && egreso && cliente) reservaV.btnGuardar.Enabled = true; //Activa boton
        } //Datos ingresados?

        //Metodo para imprimir reserva
        private void Imprimir(object sender, EventArgs e)
        {
            V.printPreviewDialog1.Document = V.printDocument1;
            V.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(V_printDocument1_PrintPage);
            V.printDialog1.PrinterSettings = V.printDocument1.PrinterSettings;
            if (V.printDialog1.ShowDialog() == DialogResult.OK)
            {
                V.printDocument1.PrinterSettings = V.printDialog1.PrinterSettings;
                V.printDocument1.DocumentName = "Reserva_" + V.lbIDp.Text;
                V.printDocument1.Print();
            }
            V.printDocument1.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(V_printDocument1_PrintPage);
        }

        //Abre la ventana para consultar reservas
        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarReservasV = new ConsultarReserva();
            InicializarVentanaParaConsultarReservas();

            consultarReservasV.btnInfo.Click += new System.EventHandler(consultarReservasV_btnInfo_Click);
            consultarReservasV.btnBorrar.Click += new System.EventHandler(consultarReservasV_btnBorrar_Click);
            consultarReservasV.btnExportarReserva.Click += new System.EventHandler(Exportar_Reserva);
            consultarReservasV.btnLimpiar.Click += new System.EventHandler(ActualizarLista);

            consultarReservasV.ShowDialog();

            consultarReservasV.btnInfo.Click -= new System.EventHandler(consultarReservasV_btnInfo_Click);
            consultarReservasV.btnBorrar.Click -= new System.EventHandler(consultarReservasV_btnBorrar_Click);
            consultarReservasV.btnLimpiar.Click -= new System.EventHandler(ActualizarLista);
            consultarReservasV.btnExportarReserva.Click -= new System.EventHandler(Exportar_Reserva);
        } //Ver reservas
        //Abre la ventana para modificar/hacer reservas
        private void ModificarReserva(object sender, EventArgs e)
        {
            reservaV = new ReservaV();
            Modificando = true;
            reserva = empresa.ReservaSearch(Convert.ToInt32(consultarReservasV.DGVReservas.SelectedRows[0].Cells[0].Value));
            reservaV.nUdDias.ValueChanged += new EventHandler(reservaV_nUdDias_ValueChanged);
            reservaV.btnNuevo.Click += new System.EventHandler(reservaV_btnNuevo_Click);
            reservaV.btnExistentes.Click += new System.EventHandler(reservaV_btnExistentes_Click);
            InicializarVentanaParaHacerReservas();
            Alojamiento obj = reserva.alojamiento;
            if (obj == null)
            {
                string[] numaloj = reservaV.lblTitulo.Text.Split(' ');
                obj = empresa.BinarySearch(Convert.ToInt32(numaloj[2]));
            }
            Obj2 = obj;
            if (obj != null)
            {
                ActualizarlbDatos(obj);
                InicializarVentanaParaHacerReservas();
                if (obj is Casa) reservaV.lblTitulo.Text = "Casa Nro: " + obj.Nro;
                CheckearDatosReserva(obj);
            }
            if (reservaV.ShowDialog() == DialogResult.OK)
            {
                Modificando = false;
                DateTime fin, fout; int nro, personas, dias; double precio; Cliente cliente;

                //Porque se sacan los datos de los labels para agregar:
                fin = DateTime.Parse(reservaV.labelIngreso.Text);
                fout = DateTime.Parse(reservaV.labelEgreso.Text);
                cliente = empresa.ClienteSearch(Convert.ToInt32(reservaV.lblDNI.Text));
                precio = Convert.ToDouble(reservaV.labelCostoT.Text);
                dias = Convert.ToInt32(reservaV.nUdDias.Value);
                personas = Convert.ToInt32(reservaV.nUdPersonas.Value);
                nro = reserva.Nro;

                //Borra la anterior
                try
                {
                    Reserva r = empresa.ReservaSearch(reserva.Nro);
                    empresa.EliminarReserva(r);
                    if (reserva.alojamiento.Reservas.Contains(r)) reserva.alojamiento.Reservas.Remove(r);
                    //Crea la reserva
                    reserva = new Reserva(cliente, obj, dias,
                       fin,
                       fout,
                       precio,
                       nro,
                       personas
                       );
                    //Controla que la otra no exista
                    empresa.AgregarReserva(reserva); MessageBox.Show("La reserva se ha modificado con éxito"); //La agrega 
                }
                catch (FechaReservadaException)
                {
                    MessageBox.Show("Fecha ya reservada. Seleccione otra.", "Atencion");
                }
            }

        } //Modificar reserva seleccionada

        //Botones de la ventana de consulta
        private void consultarReservasV_btnInfo_Click(object sender, EventArgs e)
        {
            V = new TicketV();
            V.btEditar.Click += new System.EventHandler(ModificarReserva);
            try
            {
                DataGridViewCell DGVCell = consultarReservasV.DGVReservas.SelectedCells[0];
                DataGridViewRow indexRow = consultarReservasV.DGVReservas.Rows[DGVCell.RowIndex];
                reserva = empresa.ReservaSearch(Convert.ToInt32(indexRow.Cells[0].Value));

                //Parte general
                V.lblCheckIn.Text = reserva.FechaIn.ToString();
                V.lbPasajerosAdm.Text = "Máximo de personas: " + reserva.alojamiento.Camas; //CantPersonas

                if (reserva.alojamiento is Casa)
                {
                    V.lbIDp.Text = "ID: " + reserva.Nro.ToString(); //Numero
                    V.lblIDAloj.Text = reserva.alojamiento.Nro.ToString();
                    V.lbDireccion.Text = "Direccion: " + reserva.alojamiento.Direccion; //Direccion
                    V.lblDias.Text = reserva.CantDias.ToString();//CantDias
                    V.lblPasajeros.Text = reserva.CantPersonas.ToString();//CantPersonas
                    V.lbClienteDNI.Text = "DNI del cliente: " + reserva.cliente.DNI.ToString(); //DNI
                    V.lbClienteNombre.Text = "Nombre del cliente: " + reserva.cliente.Nombre; //NombreC
                    V.lbFechaReservap.Text = "Fecha de Reserva: " + reserva.FechaIn.ToString(); //FechaIN
                    V.lbFechaCheckOutp.Text = "Fecha de Check Out: " + reserva.FechaOut.ToString(); //FechaOUT
                    V.lbCostoTotal.Text = "Costo Total: $" + reserva.PrecioTotal;
                    V.lbCostoDia.Text = "Costo Base: $" + reserva.alojamiento.Preciobase;
                    V.panelHotel.Enabled = false;
                    V.panelHotel.Visible = false;
                }
                if (!(reserva.alojamiento is Casa)) //Solo Hotel
                {
                    V.lbPiso.Text = ((Hotel2E)reserva.alojamiento).Piso.ToString();
                    if (reserva.alojamiento is Hotel2E)
                    {
                        Hotel2E hotel = (Hotel2E)reserva.alojamiento;
                        V.panelHotel.Visible = true;
                        V.lbDescripcion.Visible = false;

                        V.lbIDp.Text = "ID: " + reserva.Nro.ToString(); //Numero
                        V.lblIDAloj.Text = reserva.alojamiento.Nro.ToString();
                        V.lbDireccion.Text = "Direccion: " + reserva.alojamiento.Direccion; //Direccion
                        V.lblDias.Text = reserva.CantDias.ToString();//CantDias
                        V.lblPasajeros.Text = reserva.CantPersonas.ToString();//CantPersonas
                        V.lbPasajerosAdm.Text = "Máximo de personas: " + reserva.alojamiento; //CantPersonas
                        V.lbClienteDNI.Text = "DNI del cliente: " + reserva.cliente.DNI.ToString(); //DNI
                        V.lbClienteNombre.Text = "Nombre del cliente: " + reserva.cliente.Nombre; //NombreC
                        V.lbFechaReservap.Text = "Fecha de Reserva: " + reserva.FechaIn.ToString(); //FechaIN
                        V.lbFechaCheckOutp.Text = "Fecha de Check Out: " + reserva.FechaOut.ToString(); //FechaOUT
                        V.lbCostoTotal.Text = "Costo Total: $" + reserva.PrecioTotal;
                        V.lbCostoDia.Text = "Costo Base: $" + reserva.alojamiento.Preciobase;
                        V.LbHabitacion.Text = hotel.Nro.ToString(); //Numero
                        V.lbEstrella.Text = " 2 Estrellas"; //Estrellas
                        V.lbHotel.Text = hotel.Nombre; //Nombre
                        V.lbCostoDia.Text = "Costo por Día: $" + hotel.CostoDia.ToString();
                    }
                    if (reserva.alojamiento is Hotel3E)
                    {
                        Hotel3E hotel = (Hotel3E)reserva.alojamiento;
                        V.panelHotel.Visible = true;
                        V.lbDescripcion.Visible = false;

                        V.lbIDp.Text = "ID: " + reserva.Nro.ToString(); //Numero
                        V.lblIDAloj.Text = reserva.alojamiento.Nro.ToString();
                        V.lbDireccion.Text = "Direccion: " + reserva.alojamiento.Direccion; //Direccion
                        V.lblDias.Text = reserva.CantDias.ToString();//CantDias
                        V.lblPasajeros.Text = reserva.CantPersonas.ToString();//CantPersonas
                        V.lbPasajerosAdm.Text = "Cantidad de personas Adm.: *COMPLETAR*"; //CantPersonas
                        V.lbClienteDNI.Text = "DNI del cliente: " + reserva.cliente.DNI.ToString(); //DNI
                        V.lbClienteNombre.Text = "Nombre del cliente: " + reserva.cliente.Nombre; //NombreC
                        V.lbFechaReservap.Text = "Fecha de Reserva: " + reserva.FechaIn.ToString(); //FechaIN
                        V.lbFechaCheckOutp.Text = "Fecha de Check Out: " + reserva.FechaOut.ToString(); //FechaOUT
                        V.lbCostoTotal.Text = "Costo Total: $" + reserva.PrecioTotal;
                        V.lbCostoDia.Text = "Costo Base: $" + reserva.alojamiento.Preciobase;
                        V.LbHabitacion.Text = hotel.Nro.ToString(); //Numero
                        V.lbEstrella.Text = " 3 Estrellas"; //Estrellas
                        V.lbHotel.Text = hotel.Nombre; //Nombre
                        V.lbCostoDia.Text = "Costo por Día: $" + hotel.CostoDia.ToString();
                    }
                }
                else
                {
                    V.lbDescripcion.Visible = true;
                    V.lbDescripcion.Text = "Nombre: " + ((Casa)reserva.alojamiento).Nombre;
                }
                V.btnImprimir.Click += new System.EventHandler(Imprimir);
                V.ShowDialog();
                V.btnImprimir.Click -= new System.EventHandler(Imprimir);
            }
            catch (Exception ex)
            {

            }

        }
        private void consultarReservasV_btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell DGVCell = consultarReservasV.DGVReservas.SelectedCells[0];
                DataGridViewRow indexRow = consultarReservasV.DGVReservas.Rows[DGVCell.RowIndex];

                Reserva obj1 = empresa.ReservaSearch(Convert.ToInt32(indexRow.Cells[0].Value));
                Alojamiento aloj1 = obj1.alojamiento;
                empresa.EliminarReserva(obj1);

                consultarReservasV.DGVReservas.Rows.Clear();
                foreach (Reserva obj in empresa.ReservasRegistradas)
                {
                    string[] campos = new string[3];

                    campos[0] = obj.Nro.ToString();
                    if (obj.alojamiento is Casa)
                        campos[1] = "Casa";
                    if (obj.alojamiento is Hotel2E || obj.alojamiento is Hotel3E)
                        campos[1] = "Hotel";
                    if (obj.cliente != null)
                    {
                        campos[2] = obj.cliente.DNI.ToString();
                    }

                    consultarReservasV.DGVReservas.Rows.Add(campos);
                }
                ActualizarGraficoPastel();
                ActualizarGraficoBarras();

            }
            catch(ArgumentOutOfRangeException ex)
            {

            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton Imprimir (en ver reserva)
        private void V_printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            limites = e.MarginBounds;
            Font fontT = new Font("Arial", 15);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            float x, y;


            x = 30;
            y = 30;
            //Cabecera ORIGINAL
            Bitmap UTNimg = new Bitmap(Properties.Resources.UTNLogo, 100, 100);
            e.Graphics.DrawImage(UTNimg, x + 30, y);
            e.Graphics.DrawString("Original", fontT, brush, x + 400, y + 40);
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), fontT, brush, x + 650, y + 40);
            e.Graphics.DrawLine(pen, x + UTNimg.Width + 50, y + UTNimg.Height - 40, x + limites.Width + 130, y + UTNimg.Height - 40);

            //Info básica
            Alojamiento aloj = empresa.BinarySearch(Convert.ToInt32(V.lblIDAloj.Text));
            Bitmap AlojImg = null;
            if (aloj.Getimagen(0) != null)
                AlojImg = new Bitmap(aloj.Getimagen(0), 200, 200);

            e.Graphics.DrawString("Reserva " + V.lbIDp.Text, fontT, brush, x + 100, y + UTNimg.Height + 80);
            string nombre = "";
            if (aloj is Casa)
                nombre = ((Casa)aloj).Nombre;
            if (aloj is Hotel2E)
                nombre = ((Hotel2E)aloj).Nombre;
            if (aloj is Hotel3E)
                nombre = ((Hotel3E)aloj).Nombre;
            e.Graphics.DrawString("Alojamiento " + nombre, fontT, brush, x + 300, y + UTNimg.Height + 80);
            e.Graphics.DrawLine(pen, x + 10, y + 220, x + limites.Width + 130, y + +220);

            //Info Alojamiento
            e.Graphics.DrawString("Info. Alojamiento:", fontT, brush, x + 100, y + 225);
            if (aloj is Casa)
            {
                e.Graphics.DrawString("Casa", fontT, brush, x + 100, y + 260);
                e.Graphics.DrawString(V.lbDescripcion.Text, fontT, brush, x + 100, y + 290);
                e.Graphics.DrawString(V.lbDireccion.Text, fontT, brush, x + 100, y + 320);
                e.Graphics.DrawString("Nro. Alojamiento: " + V.lblIDAloj.Text, fontT, brush, x + 100, y + 350);
                e.Graphics.DrawImage(AlojImg, x + 500, y + 250);
            }
            if (aloj is Hotel2E)
            {
                e.Graphics.DrawString("Hotel 2 Estrellas", fontT, brush, x + 100, y + 260);
                e.Graphics.DrawString(V.lbDescripcion.Text, fontT, brush, x + 100, y + 290);
                e.Graphics.DrawString(V.lbDireccion.Text, fontT, brush, x + 100, y + 320);
                e.Graphics.DrawString("Nro. Alojamiento: " + V.lblIDAloj.Text, fontT, brush, x + 100, y + 350);
                e.Graphics.DrawImage(AlojImg, x + 500, y + 250);
            }
            if (aloj is Hotel2E)
            {
                e.Graphics.DrawString("Hotel 3 Estrellas", fontT, brush, x + 100, y + 260);
                e.Graphics.DrawString(V.lbDescripcion.Text, fontT, brush, x + 100, y + 290);
                e.Graphics.DrawString(V.lbDireccion.Text, fontT, brush, x + 100, y + 320);
                e.Graphics.DrawString("Nro. Alojamiento: " + V.lblIDAloj.Text, fontT, brush, x + 100, y + 350);
                e.Graphics.DrawImage(AlojImg, x + 500, y + 250);
            }
            e.Graphics.DrawLine(pen, x + 10, y + AlojImg.Height + 280, x + limites.Width + 130, y + AlojImg.Height + 280);

            //Info reserva
            e.Graphics.DrawString("Info. Reserva General:", fontT, brush, x + 70, y + 510);
            e.Graphics.DrawString("Cliente. " + V.lbClienteNombre.Text, fontT, brush, x + 70, y + 550);
            e.Graphics.DrawString("Cliente. " + V.lbClienteDNI.Text, fontT, brush, x + 70, y + 580);
            e.Graphics.DrawString(V.lbFechaReservap.Text, fontT, brush, x + 70, y + 610);
            e.Graphics.DrawString(V.lbFechaCheckOutp.Text, fontT, brush, x + 70, y + 640);
            e.Graphics.DrawString("Cant. Dias de Estadia: " + V.lblDias.Text, fontT, brush, x + 70, y + 670);
            e.Graphics.DrawString("Cant. Pasajeros en Estadia: " + V.lblPasajeros.Text, fontT, brush, x + 70, y + 700);

            e.Graphics.DrawLine(pen, x + 10, y + 750, x + limites.Width + 130, y + 750);

            //Costos
            e.Graphics.DrawString(V.lbCostoDia.Text, fontT, brush, x + 70, y + 790);
            e.Graphics.DrawString(V.lbCostoTotal.Text, fontT, brush, x + 70, y + 820);

        }
        //////////////////////////////
        #endregion

        ////////Alojamientos/////////
        #region
        EventHandler Seleccion;
        Alojamiento aux;
        double costoAlojamiento = 0;
        bool ModoModificar = false;

        //Metodos de la ventana agregar
        private bool ValidarCamposHotel()
        {
            bool ok = true;
            if (agregar.textBox2.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox2, "Ingrese el Nombre del Hotel");
            }
            if (agregar.textBox3.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox3, "Ingrese la Direccion");
            }
            if (agregar.textBox4.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox4, "Ingrese Numero de Identificacion");
            }
            if (agregar.radioButton3.Checked == false && agregar.radioButton4.Checked == false)
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.radioButton4, "Seleccione el tipo de hotel");
            }
            if (agregar.comboBox2.SelectedIndex == -1)
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.comboBox2, "Seleccione el tipo de habitacion");
            }
            return ok;
        }
        private bool ValidarCamposCasa()
        {
            bool ok = true;
            if (agregar.textBox7.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox7, "Ingrese la Direccion");
            }
            if (agregar.textBox5.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox5, "Ingrese el Nro de la casa");
            }
            if (agregar.numericUpDown1.Value == 0)
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.numericUpDown1, "Ingrese el minimo de dias");
            }
            if (agregar.numericUpDown2.Value == 0)
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.numericUpDown2, "Ingrese el minimo de dias");
            }
            if (agregar.textBox6.Text == "")
            {
                ok = false;
                agregar.errorProvider1.SetError(agregar.textBox6, "Ingrese el Precio");
            }
            return ok;
        }
        private void HabilitacionDeEventos()
        {
            agregar.btnFinalizar.Click += new System.EventHandler(this.agregar_btnFinalizar_Click);
            agregar.pictureBox1.DoubleClick += new System.EventHandler(this.agregar_pictureBox1_DoubleClick);
            agregar.pictureBox2.DoubleClick += new System.EventHandler(this.agregar_pictureBox2_DoubleClick);
            agregar.pictureBox3.DoubleClick += new System.EventHandler(this.agregar_pictureBox3_DoubleClick);
            agregar.pictureBox4.DoubleClick += new System.EventHandler(this.agregar_pictureBox4_DoubleClick);
            agregar.comboBox1.SelectedIndexChanged += new System.EventHandler(this.agregar_comboBox1_SelectedIndexChanged);
            agregar.btnGuardarCambios.Click += new System.EventHandler(this.agregar_btnGuardarCambios_Click);
            agregar.Shown += new System.EventHandler(AlMostrarAgregar);
            Seleccion += new EventHandler(InicializarSeleccionAgregar);
        }

        //Muestra los datos de los Alojamientos en el DataGrid
        private void MostrarDatos()
        {
            Bitmap imageDelete = new Bitmap(Properties.Resources.deleteIcon, 40, 40);
            Bitmap imageEdit = new Bitmap(Properties.Resources.editIcon1, 40, 40);
            if (comBAlojamiento.SelectedIndex == 0)
            {
                try
                {
                    DGVCasas.Rows.Clear();

                    foreach (Alojamiento obj in empresa.Alojamientos)
                    {
                        if (obj is Casa)
                        {
                            Casa casa = (Casa)obj;

                            Bitmap bitmap = new Bitmap(Properties.Resources.UTNLogo);
                            if (obj.Getimagen(0) != null)
                                bitmap = new Bitmap(obj.Getimagen(0), 125, 100);

                            DGVCasas.Rows.Add(new object[]
                            {
                             casa.Nombre,
                             casa.Nro.ToString(),
                             casa.Direccion,
                             casa.Servicios.Count.ToString(),
                             casa.CantCamas.ToString(),
                             casa.Preciobase.ToString(),
                             bitmap,
                             imageEdit,
                             imageDelete

                            });
                        }
                    }
                }
                catch (Exception ex)
                { }
               

                gBHoteles.Enabled = false;
                gBHoteles.Visible = false;
                DGVHoteles.Visible = false;
                gBCasas.Enabled = true;
                gBCasas.Visible = true;
                DGVCasas.Visible = true;
                gBCasas.Location = new Point(20, 52);
            }
            else
            {
                DGVHoteles.Rows.Clear();
                string[] listH = new string[6];
                foreach (Alojamiento obj in empresa.Alojamientos)
                {
                    if (obj is Hotel2E)
                    {
                        Hotel2E hotel = (Hotel2E)obj;
                        Bitmap bitmap = new Bitmap(Properties.Resources.UTNLogo);
                        if (obj.Getimagen(0) != null)
                            bitmap = new Bitmap(obj.Getimagen(0), 125, 100);
                        DGVHoteles.Rows.Add(new object[]
                        {
                             hotel.Nombre,
                             hotel.Direccion,
                             "2 Estrellas",
                             hotel.Nro.ToString(),
                             hotel.Preciobase.ToString(),
                             hotel.Tipo.ToString(),
                             bitmap,
                             imageEdit,
                             imageDelete
                        });

                    }
                    if (obj is Hotel3E)
                    {
                        Hotel3E hotel = (Hotel3E)obj;
                        Bitmap bitmap = new Bitmap(Properties.Resources.UTNLogo);
                        if (obj.Getimagen(0) != null)
                            bitmap = new Bitmap(obj.Getimagen(0), 125, 100);
                        DGVHoteles.Rows.Add(new object[]
                        {
                             hotel.Nombre,
                             hotel.Direccion,
                             "3 Estrellas",
                             hotel.Nro.ToString(),
                             hotel.Preciobase.ToString(),
                             hotel.Tipo.ToString(),
                             bitmap,
                             imageEdit,
                             imageDelete
                        });

                    }
                    //{
                    //    Hotel2E hotel = (Hotel3E)obj;
                    //    listH[0] = hotel.Nombre;
                    //    listH[1] = hotel.Direccion;
                    //    listH[2] = "3";
                    //    listH[3] = hotel.Nro.ToString();
                    //    listH[4] = hotel.Preciobase.ToString();
                    //    listH[5] = hotel.Tipo.ToString();
                    //    DGVHoteles.Rows.Add(listH);
                    //}
                }

                gBCasas.Enabled = false;
                gBCasas.Visible = false;
                DGVCasas.Visible = false;
                gBHoteles.Enabled = true;
                gBHoteles.Visible = true;
                DGVHoteles.Visible = true;
                //gBHoteles.Location = new Point(20, 52);
            }
        }

        //Abre la ventana agregar alojamiento
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregar = new AgregarAlojamiento();
            HabilitacionDeEventos();
            agregar.ShowDialog();
            agregar.btnGuardarCambios.Visible = false;
            agregar.btnGuardarCambios.Enabled = false;
            agregar.btnFinalizar.Enabled = true;
            agregar.btnFinalizar.Visible = true;
            //modifAlojamientos.comboBox1.SelectedIndex = 0;
        }

       
             
        private void agregar_btnGuardarCambios_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Advertencia", "Esta seguro de Guardar los cambios?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.OK)
            {
                try
                {
                    alojamiento.Setimagen((Bitmap)agregar.pictureBox1.Image, 0);
                    alojamiento.Setimagen((Bitmap)agregar.pictureBox2.Image, 1);
                    alojamiento.Setimagen((Bitmap)agregar.pictureBox3.Image, 2);
                    alojamiento.Setimagen((Bitmap)agregar.pictureBox4.Image, 3);
                    if (alojamiento is Casa)
                    {
                        List<int> servicios = new List<int>();
                        alojamiento.Direccion = agregar.textBox7.Text;
                        alojamiento.Nro = Convert.ToInt32(agregar.textBox5.Text);
                        ((Casa)alojamiento).MinDias = Convert.ToInt32(agregar.numericUpDown1.Value);
                        ((Casa)alojamiento).CantCamas = Convert.ToInt32(agregar.numericUpDown2.Value);
                        alojamiento.Preciobase = Convert.ToDouble(agregar.textBox6.Text);
                        if (agregar.cbWIFI.Checked)
                            servicios.Add(0);
                        if (agregar.cbPileta.Checked)
                            servicios.Add(1);
                        if (agregar.cbCochera.Checked)
                            servicios.Add(2);
                        if (agregar.cbLimpieza.Checked)
                            servicios.Add(3);
                        if (agregar.cbDesayuno.Checked)
                            servicios.Add(4);
                        if (agregar.cbMascotas.Checked)
                            servicios.Add(5);
                        ((Casa)alojamiento).ModificarServicios(servicios);
                        agregar.Dispose();
                    }
                    else
                    {
                        alojamiento.Direccion = agregar.textBox3.Text;
                        ((Hotel2E)alojamiento).Nombre = agregar.textBox2.Text;
                        alojamiento.Nro = Convert.ToInt32(agregar.textBox4.Text);

                        switch (agregar.comboBox2.SelectedIndex)
                        {
                            case 0:
                                ((Hotel2E)alojamiento).Tipo = 1;
                                break;
                            case 1:
                                ((Hotel2E)alojamiento).Tipo = 2;
                                break;
                            case 2:
                                ((Hotel2E)alojamiento).Tipo = 3;
                                break;
                        }


                        //if(agregar.radioButton3.Checked)
                        //{
                        //    if(alojamiento is Hotel2E)
                        //    {
                        //        Hotel3E aux =(Hotel3E) alojamiento;
                        //        empresa.EliminarAlojamiento(alojamiento);
                        //        empresa.AgregarAlojamiento(aux);
                        //    }
                        //}
                        //else
                        //{
                        //    if (alojamiento is Hotel3E)
                        //    {
                        //        Hotel2E aux = (Hotel2E)alojamiento;
                        //        empresa.EliminarAlojamiento(alojamiento);
                        //        empresa.AgregarAlojamiento(aux);
                        //    }
                        //}
                        ((Hotel2E)alojamiento).Piso = Convert.ToInt32(agregar.numericUpDown3.Value);
                        agregar.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    agregar.Close();
                }
                comBAlojamiento.SelectedIndex = 0;
                MessageBox.Show("Alojamiento modificado con exito");
            }
        }   
        //Eventos de la ventana agregar
        private void agregar_btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (agregar.comboBox1.SelectedIndex == 0)
                {
                    ValidarCamposCasa();
                    if (ValidarCamposCasa() == false)
                        throw new CamposVaciosException();
                    DialogResult r = MessageBox.Show("¿Esta seguro de Guardar los datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (r == DialogResult.OK)
                    {
                        string direccion = agregar.textBox7.Text;
                        int num = Convert.ToInt32(agregar.textBox5.Text);
                        string nombre = agregar.tbNombre.Text;
                        double precio = Convert.ToDouble(agregar.textBox6.Text);
                        int minimoDias = Convert.ToInt32(agregar.numericUpDown1.Value);
                        int camas = Convert.ToInt32(agregar.numericUpDown2.Value);
                        List<int> lista = new List<int>();

                        if (agregar.cbWIFI.Checked)
                            lista.Add(0);
                        if (agregar.cbPileta.Checked)
                            lista.Add(1);
                        if (agregar.cbCochera.Checked)
                            lista.Add(2);
                        if (agregar.cbLimpieza.Checked)
                            lista.Add(3);
                        if (agregar.cbDesayuno.Checked)
                            lista.Add(4);
                        if (agregar.cbMascotas.Checked)
                            lista.Add(5);

                        bool[] sers = new bool[6];
                        if (agregar.cbWIFI.Checked)
                            sers[0] = true;
                        if (agregar.cbPileta.Checked)
                            sers[1] = true;
                        if (agregar.cbCochera.Checked)
                            sers[2] = true;
                        if (agregar.cbLimpieza.Checked)
                            sers[3] = true;
                        if (agregar.cbDesayuno.Checked)
                            sers[4] = true;
                        if (agregar.cbMascotas.Checked)
                            sers[5] = true;


                        alojamiento = new Casa(direccion, minimoDias, precio, camas, num, lista, nombre, sers);
                        alojamiento.Setimagen((Bitmap)agregar.pictureBox1.Image, 0);
                        alojamiento.Setimagen((Bitmap)agregar.pictureBox2.Image, 1);
                        alojamiento.Setimagen((Bitmap)agregar.pictureBox3.Image, 2);
                        alojamiento.Setimagen((Bitmap)agregar.pictureBox4.Image, 3);
                        empresa.AgregarAlojamiento(alojamiento);
                        agregar.Dispose();

                    }
                    else if (r == DialogResult.Cancel)
                    {

                    }
                }
                else if (agregar.comboBox1.SelectedIndex == 1)
                {
                    ValidarCamposHotel();
                    if (ValidarCamposHotel() == false)
                        throw new CamposVaciosException();
                    DialogResult r = MessageBox.Show("¿Esta seguro de Guardar los datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (r == DialogResult.OK)
                    {
                        int tipo = Convert.ToInt32(agregar.comboBox2.SelectedIndex);
                        string nombre = agregar.textBox2.Text;
                        string direccion = agregar.textBox3.Text;
                        int num = Convert.ToInt32(agregar.textBox4.Text);
                        if (agregar.radioButton4.Checked)
                        {
                            alojamiento = new Hotel2E(nombre, direccion, num, tipo, empresa.PrecioBase);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox1.Image, 0);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox2.Image, 1);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox3.Image, 2);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox4.Image, 3);
                            empresa.AgregarAlojamiento(alojamiento);

                        }
                        else if (agregar.radioButton3.Checked)
                        {
                            alojamiento = new Hotel3E(nombre, direccion, num, tipo, empresa.PrecioBase);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox1.Image, 0);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox2.Image, 1);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox3.Image, 2);
                            alojamiento.Setimagen((Bitmap)agregar.pictureBox4.Image, 3);
                            empresa.AgregarAlojamiento(alojamiento);


                        }
                        agregar.btnFinalizar.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (agregar.comboBox1.SelectedIndex == 1)
                {
                    if (ValidarCamposHotel() == true)
                        agregar.Dispose();
                }
                else if (agregar.comboBox1.SelectedIndex == 0)
                {
                    if (ValidarCamposCasa() == true)
                        agregar.Dispose();
                }
                else
                   agregar.Dispose();  
            }
        }
        private void agregar_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (agregar.comboBox1.SelectedIndex == 0)
            {
                agregar.gBhotel.Enabled = false;
                agregar.gBhotel.Visible = false;
                agregar.gBcasa.Enabled = true;
                agregar.gBcasa.Visible = true;
            }
            if (agregar.comboBox1.SelectedIndex == 1)
            {
                agregar.gBcasa.Enabled = false;
                agregar.gBcasa.Visible = false;
                agregar.gBhotel.Enabled = true;
                agregar.gBhotel.Visible = true;
            }
        }
        private void agregar_pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            modificarImg = new ModificarImg();
            try
            {
                if (modificarImg.ShowDialog() == DialogResult.Yes)
                {
                    modificarImg.openFileDialog1.ShowDialog();
                    imagen = new Bitmap(Image.FromFile(modificarImg.openFileDialog1.FileName));
                    agregar.pictureBox1.Image = imagen;
                }
                else
                {
                    agregar.pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            modificarImg = new ModificarImg();
            if (modificarImg.ShowDialog() == DialogResult.Yes)
            {
                modificarImg.openFileDialog1.ShowDialog();
                imagen = new Bitmap(Image.FromFile(modificarImg.openFileDialog1.FileName));
                agregar.pictureBox2.Image = imagen;
            }
            else if (modificarImg.ShowDialog() == DialogResult.No)
            {
                agregar.pictureBox2.Image = null;
            }
        }
        private void agregar_pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            modificarImg = new ModificarImg();
            try
            {
                if (modificarImg.ShowDialog() == DialogResult.Yes)
                {
                    modificarImg.openFileDialog1.ShowDialog();
                    imagen = new Bitmap(Image.FromFile(modificarImg.openFileDialog1.FileName));
                    agregar.pictureBox3.Image = imagen;
                }
                else if (modificarImg.ShowDialog() == DialogResult.No)
                {
                    agregar.pictureBox3.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            modificarImg = new ModificarImg();
            try
            {
                if (modificarImg.ShowDialog() == DialogResult.Yes)
                {
                    modificarImg.openFileDialog1.ShowDialog();
                    imagen = new Bitmap(Image.FromFile(modificarImg.openFileDialog1.FileName));
                    agregar.pictureBox4.Image = imagen;
                }
                else if (modificarImg.ShowDialog() == DialogResult.No)
                {
                    agregar.pictureBox4.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            modificarImg = new ModificarImg();
            try
            {
                if (modificarImg.ShowDialog() == DialogResult.Yes)
                {
                    modificarImg.openFileDialog1.ShowDialog();
                    imagen = new Bitmap(Image.FromFile(modificarImg.openFileDialog1.FileName));

                }
                else if (modificarImg.ShowDialog() == DialogResult.No)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_btnAgregar_Click(object sender, EventArgs e)
        {

            //if (i < 5)
            //{
            //    if (agregar.openFileDialog1.ShowDialog() == DialogResult.OK)
            //    {

            //        imagen = new Bitmap(Image.FromFile(agregar.openFileDialog1.FileName));
            //        imagenes[i] = imagen;
            //        i++;
            //        agregar.pictureBox1.Image = (Image)imagenes[0];
            //        if (imagenes[1] != null)
            //            agregar.pictureBox2.Image = (Image)imagenes[1];

            //        if (imagenes[2] != null)
            //            agregar.pictureBox3.Image = (Image)imagenes[2];

            //        if (imagenes[3] != null)
            //            agregar.pictureBox4.Image = (Image)imagenes[3];

            //    }
            //}
            //else
            //    MessageBox.Show("Maximo solo 5 imagenes por alojamiento");

        }
        private void comBAlojamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void InicializarSeleccionAgregar(object sender, EventArgs e)
        {
            ComboBox CB1 = agregar.comboBox1;

            if (ModoModificar)
            {
                CB1.SelectedIndex = -1;
                if (alojamiento is Casa) CB1.SelectedIndex = 0;
                else CB1.SelectedIndex = 1;
                CB1.Enabled = false;
            }
            else CB1.Enabled = true;
            ModoModificar = false;
        }
        private void AlMostrarAgregar(object sender, EventArgs e)
        {
            Seleccion.Invoke(sender, e);
        }

        //////////////////////////////
        #endregion

        ////////Clientes/////////
        #region
        //Abre ventana para agregar Cliente
        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientesVNuevo = new ClientesVNuevo();
            if (clientesVNuevo.ShowDialog() == DialogResult.OK)
            {
                string[] campos = new string[2];

                try
                {
                    string nombre = clientesVNuevo.tBNombre.Text;
                    int dni = Convert.ToInt32(clientesVNuevo.tBDNI.Text);

                    cliente = new Cliente(nombre, dni);
                    empresa.AgregarCliente(cliente);
                    campos[0] = nombre;
                    campos[1] = dni.ToString();
                    clientesV.DGVClientes.Rows.Add(campos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    clientesVNuevo.Close();
                }
            }
        }
        //Abre ventana para Colsultar (Y futuro eliminar) Cliente
        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientesV = new ClientesV();
            clientesV.button1.Text = "Eliminar";
            clientesV.button1.DialogResult = DialogResult.None;
            clientesV.DGVClientes.Rows.Clear();
            string[] campos = new string[2];
            foreach (Cliente cliente in empresa.ClientesRegistrados)
            {
                campos[0] = cliente.Nombre;
                campos[1] = cliente.DNI.ToString();

                clientesV.DGVClientes.Rows.Add(campos);
            }
            clientesV.button1.Click += new System.EventHandler(EliminarCliente);
            clientesV.ShowDialog();
            clientesV.button1.Click -= new System.EventHandler(EliminarCliente);
        }
        private void EliminarCliente(object sender, EventArgs e)
        {
            DataGridViewCell DGVCell = clientesV.DGVClientes.SelectedCells[0];
            DataGridViewRow indexRow = clientesV.DGVClientes.Rows[DGVCell.RowIndex];

            cliente = empresa.ClienteSearch(Convert.ToInt32(indexRow.Cells[1].Value));
            empresa.EliminarCliente(cliente);
            clientesV.DGVClientes.Rows.Clear();
            string[] campos = new string[2];
            foreach (Cliente cliente in empresa.ClientesRegistrados)
            {
                campos[0] = cliente.Nombre;
                campos[1] = cliente.DNI.ToString();

                clientesV.DGVClientes.Rows.Add(campos);
            }
        }
        //////////////////////////
        #endregion

        ///////Graficos/////////
        #region
        //Actualiza
        private void ActualizarGraficoPastel()
        {
            pictureBox2.Refresh();
            int cantC = 0, cantH3 = 0, cantH2 = 0;
            foreach (Reserva obj in empresa.ReservasRegistradas)
            {
                if (obj != null)
                {
                    if (obj.alojamiento is Casa)
                        cantC++;
                    if (obj.alojamiento is Hotel3E)
                    {
                        cantH3++; cantH2 -= 1;
                    }

                    if (obj.alojamiento is Hotel2E)
                        cantH2++;
                }
            }

            //Graficando el pastel
            Graphics lienzo = pictureBox2.CreateGraphics();
            int total = cantC + cantH2 + cantH3;
            if (total == 0)
                total = 1;

            int gradosC = (cantC * 360) / total;
            int gradosH2 = (cantH2 * 360) / total;
            int gradosH3 = (cantH3 * 360) / total;

            lienzo.FillPie(new SolidBrush(Color.MediumSlateBlue), 10, 10, 140, 140, 0, gradosC);
            lienzo.FillPie(new SolidBrush(Color.Lavender), 10, 10, 140, 140, gradosC, gradosH2);
            lienzo.FillPie(new SolidBrush(Color.FromArgb(192, 192, 255)), 10, 10, 140, 140, gradosC + gradosH2, gradosH3);

            //lienzo.FillRectangle(new SolidBrush(Color.Red), 160, 10, 20, 10);
            lienzo.DrawString(cantC.ToString() + " Casa", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.MediumSlateBlue), 160, 10);
            //lienzo.FillRectangle(new SolidBrush(Color.Blue), 160, 40, 20, 10);
            lienzo.DrawString(cantH2.ToString() + " Hotel 2", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(175, 105, 205)), 160, 40);
            //lienzo.FillRectangle(new SolidBrush(Color.Green), 160, 70, 20, 10);
            lienzo.DrawString(cantH3.ToString() + " Hotel 3", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(192, 192, 255)), 160, 70);


        }
        private void ActualizarGraficoBarras()
        {
            pictureBox1.Refresh();
            //info a visualizar
            int wh = pictureBox1.Width;
            int hs = pictureBox1.Height;
            List<int> valores = new List<int>();
            string[] nums = new string[] { "1", "2", "3", "4", "5", "6", "+6" };
            string titulo = "";
            string etiquetaX = "X";
            string etiquetaY = "   1    2    3    4    5    6    +6";

            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, pm = 0;
            foreach (Reserva obj in empresa.ReservasRegistradas)
            {
                if (obj != null)
                {
                    switch (obj.CantPersonas)
                    {
                        case 1:
                            p1++; break;
                        case 2:
                            p2++; break;
                        case 3:
                            p3++; break;
                        case 4:
                            p4++; break;
                        case 5:
                            p5++; break;
                        case 6:
                            p6++; break;
                    }
                    if (obj.CantPersonas > 6)
                        pm++;
                }
            }
            valores.Add(p1);
            valores.Add(p2);
            valores.Add(p3);
            valores.Add(p4);
            valores.Add(p5);
            valores.Add(p6);
            valores.Add(pm);

            string[] valoresStr = new string[7];
            for (int i = 0; i < valores.Count; i++)
            {
                valoresStr[i] = valores[i].ToString();
            }

            DiagramaBarras dB = new DiagramaBarras();
            dB.Graficar(valores, valoresStr, titulo, etiquetaX, "", pictureBox1.CreateGraphics(), wh, hs);

            Font fontVE = new System.Drawing.Font("Arial", 16);
            SolidBrush brushVE = new System.Drawing.SolidBrush(Color.Black);
            StringFormat stringFormatVE = new StringFormat(StringFormatFlags.DirectionVertical);
            Graphics graphics = pictureBox3.CreateGraphics();

            graphics.TranslateTransform(0, pictureBox3.Height);
            graphics.RotateTransform(270);
            graphics.DrawString(etiquetaY, fontVE, brushVE, 0, 0, stringFormatVE);
        }

        //Eventos
        private void rbH2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
        }
        private void rbH3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
        }
        //////////////////////////////
        #endregion
        ///////WebBrowser/////////
        #region
        public event EventHandler ActualizadorDeLink; //Delegado para evento personalizado
        Uri fileURI = new Uri(Application.StartupPath + "\\..\\" + @"vista1.html");
        string estiloPath = Application.StartupPath + "\\..\\" + "style.css";

        //Actualiza el link
        private void UpdateLink(object sender, EventArgs e)
        {
            Uri fileURI = webV.wBrowser.Url;
            if (fileURI != null) webV.ttbEnlace.Text = fileURI.ToString();

        }

        //Abre El WebBrowser
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webV = new WebV();

            webV.tbtnAnterior.Click += new System.EventHandler(tbtnAnterior);
            webV.tbtnAnterior.Click += new System.EventHandler(tbtnAnterior);
            webV.tbtnPosterior.Click += new System.EventHandler(tbtnPosterior);
            webV.tbtnReload.Click += new System.EventHandler(tbtnReload);
            webV.tbtnHome.Click += new System.EventHandler(tbtnHome);
            ActualizadorDeLink += new System.EventHandler(UpdateLink);
            FileStream css = new FileStream(estiloPath, FileMode.Open); //Para que se vea el estilo
            webV.wBrowser.Navigate(fileURI);
            if (fileURI != null) webV.ttbEnlace.Text = fileURI.ToString();
            webV.ShowDialog();

            css.Close();
        }

        //Botones WebBrowser
        private void tbtnAnterior(object sender, EventArgs e)
        {
            webV.wBrowser.GoBack();
            ActualizadorDeLink.Invoke(sender, e);
        }
        private void tbtnPosterior(object sender, EventArgs e)
        {
            webV.wBrowser.GoForward();
            ActualizadorDeLink.Invoke(sender, e);
        }
        private void tbtnReload(object sender, EventArgs e)
        {
            webV.wBrowser.Refresh();
            ActualizadorDeLink.Invoke(sender, e);
        }
        private void tbtnHome(object sender, EventArgs e)
        {
            webV.wBrowser.Navigate(fileURI);
            ActualizadorDeLink.Invoke(sender, e);
        }
        //////////////////////////////
        #endregion

        private void importarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    string[] campos = sr.ReadLine().Split(';');
                    string nombre = campos[0];
                    int dni = Convert.ToInt32(campos[1]);

                    cliente = new Cliente(nombre, dni);
                    if (empresa.ClienteSearch(dni) == null)
                        empresa.AgregarCliente(cliente);
                }
                fs.Close();
                sr.Close();
            }
        }

        private void exportarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Cliente cliente in empresa.ClientesRegistrados)
            {
                FileStream fs = new FileStream(pathExportacion + "Cliente_" + cliente.DNI + ".txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(cliente.ToString());
                sw.Close();
                fs.Close();
            }
        }

        private void exportarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cant = 0;
            string nombre = "Reservas_" + DateTime.Now.ToLongDateString() + ".txt";
            FileStream fs1 = new FileStream(pathExportacion + nombre, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            foreach (Reserva r in empresa.ReservasRegistradas)
            {
                if (r != null)
                {
                    string s = r.ToString();
                    sw.WriteLine(s);
                    cant++;
                }
            }
            DirectoryInfo path = Directory.GetParent(nombre);
            sw.Close();
            fs1.Close();
            MessageBox.Show("Se han exportado " + cant + " reservas a " + nombre + ", ubicado en " + path.ToString());
        }

        //Eventos de la ventana modificar
        private void DGVCasas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVCasas.Columns[e.ColumnIndex].Name == "editar")
            {
                agregar = new AgregarAlojamiento();
                DataGridViewRow rowSeleccionado = DGVCasas.SelectedRows[0];
                alojamiento = empresa.BinarySearch(Convert.ToInt32(rowSeleccionado.Cells[1].Value));
                aux = alojamiento;
                agregar.comboBox1.SelectedIndex = 0;
                agregar.comboBox1.Visible = false;
                agregar.pictureBox1.Image = alojamiento.Getimagen(0);
                agregar.pictureBox2.Image = alojamiento.Getimagen(1);
                agregar.pictureBox3.Image = alojamiento.Getimagen(2);
                agregar.pictureBox4.Image = alojamiento.Getimagen(3);
                agregar.textBox7.Text = alojamiento.Direccion;
                agregar.textBox5.Text = alojamiento.Nro.ToString();
                agregar.numericUpDown1.Value = ((Casa)alojamiento).MinDias;
                agregar.numericUpDown2.Value = ((Casa)alojamiento).CantCamas;
                agregar.textBox6.Text = alojamiento.Preciobase.ToString();
                agregar.tbNombre.Text = ((Casa)alojamiento).Nombre;
                agregar.gBcasa.Enabled = true;
                agregar.gBcasa.Visible = true;
                agregar.btnGuardarCambios.Visible = true;
                agregar.btnGuardarCambios.Enabled = true;
                agregar.btnFinalizar.Enabled = false;
                agregar.btnFinalizar.Visible = false;
                foreach (string s in ((Casa)alojamiento).Servicios)
                {
                    if (s == "Wifi")
                        agregar.cbWIFI.Checked = true;
                    if (s == "Pileta")
                        agregar.cbPileta.Checked = true;
                    if (s == "Cochera")
                        agregar.cbCochera.Checked = true;
                    if (s == "Limpieza")
                        agregar.cbLimpieza.Checked = true;
                    if (s == "Desayuno")
                        agregar.cbDesayuno.Checked = true;
                    if (s == "Mascotas")
                        agregar.cbMascotas.Checked = true;
                }

                HabilitacionDeEventos();
                agregar.ShowDialog();
                bandera = true;
            }
            if (DGVCasas.Columns[e.ColumnIndex].Name == "delete")
            {
                DialogResult r = MessageBox.Show("Advertencia", "Esta seguro de eliminar los Datos?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    bandera = true;
                    DataGridViewCell DGVCell = DGVCasas.SelectedCells[0];
                    DataGridViewRow indexRow = DGVCasas.Rows[DGVCell.RowIndex];
                    alojamiento = empresa.BinarySearch(Convert.ToInt32(indexRow.Cells[1].Value));
                    empresa.EliminarAlojamiento(alojamiento);
                    MostrarDatos();

                }
                if (r == DialogResult.Cancel)
                    bandera = true;
            }


        }

        private void DGVHoteles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVHoteles.Columns[e.ColumnIndex].Name == "editarHotel")
            {
                agregar = new AgregarAlojamiento();
                DataGridViewRow rowSeleccionado = DGVHoteles.SelectedRows[0];
                alojamiento = empresa.BinarySearch(Convert.ToInt32(rowSeleccionado.Cells[3].Value));

                if (alojamiento is Hotel3E)
                    agregar.radioButton3.Checked = true; 
                else
                    agregar.radioButton4.Checked = true;
                agregar.gBhotel.Enabled = true;
                agregar.gBhotel.Visible = true;
                agregar.comboBox1.Visible = false;
                agregar.radioButton3.Enabled = false;
                agregar.radioButton4.Enabled = false;
                Hotel2E aux = (Hotel2E)alojamiento;
                agregar.pictureBox1.Image = alojamiento.Getimagen(0);
                agregar.pictureBox2.Image = alojamiento.Getimagen(1);
                agregar.pictureBox3.Image = alojamiento.Getimagen(2);
                agregar.pictureBox4.Image = alojamiento.Getimagen(3);

                agregar.textBox2.Text = aux.Nombre;
                agregar.textBox3.Text = alojamiento.Direccion;
                agregar.textBox4.Text = alojamiento.Nro.ToString();
                switch (aux.Tipo)
                {
                    case 1:
                        agregar.comboBox2.SelectedIndex = 0;
                        break;
                    case 2:
                        agregar.comboBox2.SelectedIndex = 1;
                        break;
                    case 3:
                        agregar.comboBox2.SelectedIndex = 2;
                        break;
                }
                agregar.numericUpDown3.Value = aux.Piso;

                agregar.btnGuardarCambios.Visible = true;
                agregar.btnGuardarCambios.Enabled = true;
                agregar.btnFinalizar.Enabled = false;
                agregar.btnFinalizar.Visible = false;

                HabilitacionDeEventos();

                agregar.ShowDialog();
                bandera = true;
            }
            if (DGVHoteles.Columns[e.ColumnIndex].Name == "deleteHotel")
            {
                DialogResult r = MessageBox.Show("Advertencia", "Esta seguro de eliminar los Datos?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    bandera = true;

                    DataGridViewCell DGVCell = DGVHoteles.SelectedCells[0];
                    DataGridViewRow indexRow = DGVHoteles.Rows[DGVCell.RowIndex];
                    alojamiento = empresa.BinarySearch(Convert.ToInt32(indexRow.Cells[3].Value));
                    empresa.EliminarAlojamiento(alojamiento);
                    MostrarDatos();


                }
                if (r == DialogResult.Cancel)
                    bandera = true;

            }
        }

        private void DGVHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void precioBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vinicio=new Inicio();
            Vinicio.textBox1.KeyPress += new KeyPressEventHandler(Vinicio_textBox1_KeyPress);
            Vinicio.label3.Visible = true;
            Vinicio.lbPrecio.Visible = true;
            Vinicio.lbPrecio.Text = empresa.PrecioBase.ToString()+"AR$";
            if (Vinicio.ShowDialog() == DialogResult.OK)
            {
                empresa.PrecioBase = Convert.ToDouble(Vinicio.textBox1.Text);
                Vinicio.Close();
            }
        }
    }
}

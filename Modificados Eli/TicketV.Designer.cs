
namespace TP2_LABII
{
    partial class TicketV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketV));
            this.btEditar = new System.Windows.Forms.Button();
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.lbClienteDNI = new System.Windows.Forms.Label();
            this.lbClienteNombre = new System.Windows.Forms.Label();
            this.groupBoxAlojamiento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHotel = new System.Windows.Forms.Panel();
            this.lbEstrella = new System.Windows.Forms.Label();
            this.lbPiso = new System.Windows.Forms.Label();
            this.LbHabitacion = new System.Windows.Forms.Label();
            this.lbHotel = new System.Windows.Forms.Label();
            this.lblIDAloj = new System.Windows.Forms.Label();
            this.lbPasajerosAdm = new System.Windows.Forms.Label();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.lbCostoTotal = new System.Windows.Forms.Label();
            this.lbCostoDia = new System.Windows.Forms.Label();
            this.lbFechaCheckOutp = new System.Windows.Forms.Label();
            this.lbFechaCheckP = new System.Windows.Forms.Label();
            this.lbFechaReservap = new System.Windows.Forms.Label();
            this.lbIDp = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.bTAceptar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.lblPasajeros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDias = new System.Windows.Forms.Label();
            this.lbDiasEstadiap = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.groupBoxCliente.SuspendLayout();
            this.groupBoxAlojamiento.SuspendLayout();
            this.panelHotel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEditar
            // 
            this.btEditar.BackColor = System.Drawing.Color.Lavender;
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditar.Location = new System.Drawing.Point(362, 233);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(75, 23);
            this.btEditar.TabIndex = 29;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = false;
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.lbClienteDNI);
            this.groupBoxCliente.Controls.Add(this.lbClienteNombre);
            this.groupBoxCliente.Location = new System.Drawing.Point(23, 204);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(235, 52);
            this.groupBoxCliente.TabIndex = 25;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Cliente";
            // 
            // lbClienteDNI
            // 
            this.lbClienteDNI.AutoSize = true;
            this.lbClienteDNI.Location = new System.Drawing.Point(6, 29);
            this.lbClienteDNI.Name = "lbClienteDNI";
            this.lbClienteDNI.Size = new System.Drawing.Size(83, 13);
            this.lbClienteDNI.TabIndex = 2;
            this.lbClienteDNI.Text = "DNI: xxx.xxx.xxx";
            // 
            // lbClienteNombre
            // 
            this.lbClienteNombre.AutoSize = true;
            this.lbClienteNombre.Location = new System.Drawing.Point(6, 16);
            this.lbClienteNombre.Name = "lbClienteNombre";
            this.lbClienteNombre.Size = new System.Drawing.Size(120, 13);
            this.lbClienteNombre.TabIndex = 1;
            this.lbClienteNombre.Text = "Nombre: xxxxxxxxxxxxxx";
            // 
            // groupBoxAlojamiento
            // 
            this.groupBoxAlojamiento.Controls.Add(this.label1);
            this.groupBoxAlojamiento.Controls.Add(this.panelHotel);
            this.groupBoxAlojamiento.Controls.Add(this.lblIDAloj);
            this.groupBoxAlojamiento.Controls.Add(this.lbPasajerosAdm);
            this.groupBoxAlojamiento.Controls.Add(this.lbDireccion);
            this.groupBoxAlojamiento.Controls.Add(this.lbDescripcion);
            this.groupBoxAlojamiento.Controls.Add(this.lbCostoTotal);
            this.groupBoxAlojamiento.Controls.Add(this.lbCostoDia);
            this.groupBoxAlojamiento.Location = new System.Drawing.Point(20, 97);
            this.groupBoxAlojamiento.Name = "groupBoxAlojamiento";
            this.groupBoxAlojamiento.Size = new System.Drawing.Size(514, 100);
            this.groupBoxAlojamiento.TabIndex = 24;
            this.groupBoxAlojamiento.TabStop = false;
            this.groupBoxAlojamiento.Text = "Alojamiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "ID:";
            // 
            // panelHotel
            // 
            this.panelHotel.Controls.Add(this.lbEstrella);
            this.panelHotel.Controls.Add(this.lbPiso);
            this.panelHotel.Controls.Add(this.LbHabitacion);
            this.panelHotel.Controls.Add(this.lbHotel);
            this.panelHotel.Location = new System.Drawing.Point(262, 6);
            this.panelHotel.Name = "panelHotel";
            this.panelHotel.Size = new System.Drawing.Size(155, 94);
            this.panelHotel.TabIndex = 6;
            this.panelHotel.Visible = false;
            // 
            // lbEstrella
            // 
            this.lbEstrella.AutoSize = true;
            this.lbEstrella.Location = new System.Drawing.Point(7, 31);
            this.lbEstrella.Name = "lbEstrella";
            this.lbEstrella.Size = new System.Drawing.Size(54, 13);
            this.lbEstrella.TabIndex = 3;
            this.lbEstrella.Text = "x Estrellas";
            // 
            // lbPiso
            // 
            this.lbPiso.AutoSize = true;
            this.lbPiso.Location = new System.Drawing.Point(7, 71);
            this.lbPiso.Name = "lbPiso";
            this.lbPiso.Size = new System.Drawing.Size(40, 13);
            this.lbPiso.TabIndex = 2;
            this.lbPiso.Text = "Piso xx";
            // 
            // LbHabitacion
            // 
            this.LbHabitacion.AutoSize = true;
            this.LbHabitacion.Location = new System.Drawing.Point(7, 50);
            this.LbHabitacion.Name = "LbHabitacion";
            this.LbHabitacion.Size = new System.Drawing.Size(81, 13);
            this.LbHabitacion.TabIndex = 1;
            this.LbHabitacion.Text = "Habitacion xxxx";
            // 
            // lbHotel
            // 
            this.lbHotel.AutoSize = true;
            this.lbHotel.Location = new System.Drawing.Point(7, 10);
            this.lbHotel.Name = "lbHotel";
            this.lbHotel.Size = new System.Drawing.Size(98, 13);
            this.lbHotel.TabIndex = 0;
            this.lbHotel.Text = "Hotel: xxxxxxxxxxxx";
            // 
            // lblIDAloj
            // 
            this.lblIDAloj.AutoSize = true;
            this.lblIDAloj.Location = new System.Drawing.Point(459, 17);
            this.lblIDAloj.Name = "lblIDAloj";
            this.lblIDAloj.Size = new System.Drawing.Size(37, 13);
            this.lblIDAloj.TabIndex = 33;
            this.lblIDAloj.Text = "xxxxxx";
            // 
            // lbPasajerosAdm
            // 
            this.lbPasajerosAdm.AutoSize = true;
            this.lbPasajerosAdm.Location = new System.Drawing.Point(6, 52);
            this.lbPasajerosAdm.Name = "lbPasajerosAdm";
            this.lbPasajerosAdm.Size = new System.Drawing.Size(187, 13);
            this.lbPasajerosAdm.TabIndex = 5;
            this.lbPasajerosAdm.Text = "Cantidad de Pasajeros Admitidos: xxxx";
            // 
            // lbDireccion
            // 
            this.lbDireccion.AutoSize = true;
            this.lbDireccion.Location = new System.Drawing.Point(7, 34);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(253, 13);
            this.lbDireccion.TabIndex = 4;
            this.lbDireccion.Text = "Dirección: xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(6, 17);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(250, 13);
            this.lbDescripcion.TabIndex = 3;
            this.lbDescripcion.Text = "Nombre: xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lbCostoTotal
            // 
            this.lbCostoTotal.AutoSize = true;
            this.lbCostoTotal.Location = new System.Drawing.Point(6, 84);
            this.lbCostoTotal.Name = "lbCostoTotal";
            this.lbCostoTotal.Size = new System.Drawing.Size(112, 13);
            this.lbCostoTotal.TabIndex = 1;
            this.lbCostoTotal.Text = "Costo Total: xxxxxxxxx";
            // 
            // lbCostoDia
            // 
            this.lbCostoDia.AutoSize = true;
            this.lbCostoDia.Location = new System.Drawing.Point(6, 68);
            this.lbCostoDia.Name = "lbCostoDia";
            this.lbCostoDia.Size = new System.Drawing.Size(118, 13);
            this.lbCostoDia.TabIndex = 0;
            this.lbCostoDia.Text = "Costo Por Dia: xxxxxxxx";
            // 
            // lbFechaCheckOutp
            // 
            this.lbFechaCheckOutp.AutoSize = true;
            this.lbFechaCheckOutp.Location = new System.Drawing.Point(226, 44);
            this.lbFechaCheckOutp.Name = "lbFechaCheckOutp";
            this.lbFechaCheckOutp.Size = new System.Drawing.Size(172, 13);
            this.lbFechaCheckOutp.TabIndex = 23;
            this.lbFechaCheckOutp.Text = "Fecha Check-Out: xxxxxxxxxxxxxxx";
            // 
            // lbFechaCheckP
            // 
            this.lbFechaCheckP.AutoSize = true;
            this.lbFechaCheckP.Location = new System.Drawing.Point(28, 44);
            this.lbFechaCheckP.Name = "lbFechaCheckP";
            this.lbFechaCheckP.Size = new System.Drawing.Size(86, 13);
            this.lbFechaCheckP.TabIndex = 21;
            this.lbFechaCheckP.Text = "Fecha Check In:";
            this.lbFechaCheckP.Click += new System.EventHandler(this.lbFechaCheckP_Click);
            // 
            // lbFechaReservap
            // 
            this.lbFechaReservap.AutoSize = true;
            this.lbFechaReservap.Location = new System.Drawing.Point(99, 19);
            this.lbFechaReservap.Name = "lbFechaReservap";
            this.lbFechaReservap.Size = new System.Drawing.Size(14, 13);
            this.lbFechaReservap.TabIndex = 19;
            this.lbFechaReservap.Text = "S";
            // 
            // lbIDp
            // 
            this.lbIDp.AutoSize = true;
            this.lbIDp.Location = new System.Drawing.Point(30, 19);
            this.lbIDp.Name = "lbIDp";
            this.lbIDp.Size = new System.Drawing.Size(54, 13);
            this.lbIDp.TabIndex = 18;
            this.lbIDp.Text = "ID: xxxxxx";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.Lavender;
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Location = new System.Drawing.Point(458, 233);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 17;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            // 
            // bTAceptar
            // 
            this.bTAceptar.BackColor = System.Drawing.Color.Lavender;
            this.bTAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bTAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bTAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTAceptar.Location = new System.Drawing.Point(268, 233);
            this.bTAceptar.Name = "bTAceptar";
            this.bTAceptar.Size = new System.Drawing.Size(75, 23);
            this.bTAceptar.TabIndex = 16;
            this.bTAceptar.Text = "Aceptar";
            this.bTAceptar.UseVisualStyleBackColor = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Lavender;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(454, 34);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 31;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Location = new System.Drawing.Point(385, 81);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(37, 13);
            this.lblPasajeros.TabIndex = 39;
            this.lblPasajeros.Text = "xxxxxx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Pasajeros en Estadia:";
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(155, 81);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(37, 13);
            this.lblDias.TabIndex = 37;
            this.lblDias.Text = "xxxxxx";
            // 
            // lbDiasEstadiap
            // 
            this.lbDiasEstadiap.AutoSize = true;
            this.lbDiasEstadiap.Location = new System.Drawing.Point(60, 81);
            this.lbDiasEstadiap.Name = "lbDiasEstadiap";
            this.lbDiasEstadiap.Size = new System.Drawing.Size(89, 13);
            this.lbDiasEstadiap.TabIndex = 36;
            this.lbDiasEstadiap.Text = "Dias de Estadía: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SlateBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 264);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "Versión 1.0.1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel1.LinkColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabel1.Text = "Sistema de reservas \"JES\" Versión 0.1.9";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(115, 44);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(82, 13);
            this.lblCheckIn.TabIndex = 41;
            this.lblCheckIn.Text = "xxxxxxxxxxxxxxx";
            // 
            // TicketV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(567, 286);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.lbDiasEstadiap);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.groupBoxAlojamiento);
            this.Controls.Add(this.lbFechaCheckOutp);
            this.Controls.Add(this.lbFechaCheckP);
            this.Controls.Add(this.lbFechaReservap);
            this.Controls.Add(this.lbIDp);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.bTAceptar);
            this.Name = "TicketV";
            this.Text = "TicketV";
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            this.groupBoxAlojamiento.ResumeLayout(false);
            this.groupBoxAlojamiento.PerformLayout();
            this.panelHotel.ResumeLayout(false);
            this.panelHotel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.GroupBox groupBoxCliente;
        public System.Windows.Forms.Label lbClienteDNI;
        public System.Windows.Forms.Label lbClienteNombre;
        private System.Windows.Forms.GroupBox groupBoxAlojamiento;
        public System.Windows.Forms.Panel panelHotel;
        public System.Windows.Forms.Label lbEstrella;
        public System.Windows.Forms.Label lbPiso;
        public System.Windows.Forms.Label LbHabitacion;
        public System.Windows.Forms.Label lbHotel;
        public System.Windows.Forms.Label lbPasajerosAdm;
        public System.Windows.Forms.Label lbDireccion;
        public System.Windows.Forms.Label lbDescripcion;
        public System.Windows.Forms.Label lbCostoTotal;
        public System.Windows.Forms.Label lbCostoDia;
        public System.Windows.Forms.Label lbFechaCheckOutp;
        private System.Windows.Forms.Label lbFechaCheckP;
        public System.Windows.Forms.Label lbFechaReservap;
        public System.Windows.Forms.Label lbIDp;
        public System.Windows.Forms.Button btCancelar;
        public System.Windows.Forms.Button bTAceptar;
        public System.Windows.Forms.Button btnImprimir;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblIDAloj;
        public System.Windows.Forms.PrintDialog printDialog1;
        public System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.Label lblPasajeros;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lbDiasEstadiap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Label lblCheckIn;
    }
}
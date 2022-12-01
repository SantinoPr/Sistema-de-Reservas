
namespace TP2_LABII
{
    partial class ReservaV
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
            this.components = new System.ComponentModel.Container();
            this.gBInfo = new System.Windows.Forms.GroupBox();
            this.lBDatos = new System.Windows.Forms.ListBox();
            this.gBCliente = new System.Windows.Forms.GroupBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExistentes = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gBReservar = new System.Windows.Forms.GroupBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.labelCostoT = new System.Windows.Forms.Label();
            this.labelEgreso = new System.Windows.Forms.Label();
            this.labelIngreso = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nUdPersonas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUdDias = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gBInfo.SuspendLayout();
            this.gBCliente.SuspendLayout();
            this.gBReservar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBInfo
            // 
            this.gBInfo.Controls.Add(this.lBDatos);
            this.gBInfo.Controls.Add(this.gBCliente);
            this.gBInfo.Controls.Add(this.lblTitulo);
            this.gBInfo.Location = new System.Drawing.Point(436, 35);
            this.gBInfo.Name = "gBInfo";
            this.gBInfo.Size = new System.Drawing.Size(235, 370);
            this.gBInfo.TabIndex = 4;
            this.gBInfo.TabStop = false;
            this.gBInfo.Text = "Info";
            // 
            // lBDatos
            // 
            this.lBDatos.BackColor = System.Drawing.Color.Lavender;
            this.lBDatos.FormattingEnabled = true;
            this.lBDatos.Location = new System.Drawing.Point(19, 32);
            this.lBDatos.Name = "lBDatos";
            this.lBDatos.Size = new System.Drawing.Size(196, 212);
            this.lBDatos.TabIndex = 1;
            // 
            // gBCliente
            // 
            this.gBCliente.Controls.Add(this.lblDNI);
            this.gBCliente.Controls.Add(this.lblNombre);
            this.gBCliente.Controls.Add(this.btnNuevo);
            this.gBCliente.Controls.Add(this.label7);
            this.gBCliente.Controls.Add(this.btnExistentes);
            this.gBCliente.Controls.Add(this.label6);
            this.gBCliente.Location = new System.Drawing.Point(6, 253);
            this.gBCliente.Name = "gBCliente";
            this.gBCliente.Size = new System.Drawing.Size(223, 108);
            this.gBCliente.TabIndex = 5;
            this.gBCliente.TabStop = false;
            this.gBCliente.Text = "Datos Cliente";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(123, 53);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(16, 13);
            this.lblDNI.TabIndex = 8;
            this.lblDNI.Text = "...";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(123, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(16, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "...";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Lavender;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(105, 77);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(112, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Crear Nuevo/ Usar";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "DNI:";
            // 
            // btnExistentes
            // 
            this.btnExistentes.BackColor = System.Drawing.Color.Lavender;
            this.btnExistentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExistentes.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnExistentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistentes.Location = new System.Drawing.Point(8, 77);
            this.btnExistentes.Name = "btnExistentes";
            this.btnExistentes.Size = new System.Drawing.Size(91, 23);
            this.btnExistentes.TabIndex = 0;
            this.btnExistentes.Text = "Elegir Existente";
            this.btnExistentes.UseVisualStyleBackColor = false;
            this.btnExistentes.Click += new System.EventHandler(this.btnExistentes_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(16, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(44, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo*";
            // 
            // gBReservar
            // 
            this.gBReservar.Controls.Add(this.btnImportar);
            this.gBReservar.Controls.Add(this.labelCostoT);
            this.gBReservar.Controls.Add(this.labelEgreso);
            this.gBReservar.Controls.Add(this.labelIngreso);
            this.gBReservar.Controls.Add(this.label5);
            this.gBReservar.Controls.Add(this.label4);
            this.gBReservar.Controls.Add(this.label3);
            this.gBReservar.Controls.Add(this.nUdPersonas);
            this.gBReservar.Controls.Add(this.label2);
            this.gBReservar.Controls.Add(this.nUdDias);
            this.gBReservar.Controls.Add(this.label1);
            this.gBReservar.Controls.Add(this.monthCalendar1);
            this.gBReservar.Controls.Add(this.btnGuardar);
            this.gBReservar.Location = new System.Drawing.Point(677, 35);
            this.gBReservar.Name = "gBReservar";
            this.gBReservar.Size = new System.Drawing.Size(297, 368);
            this.gBReservar.TabIndex = 5;
            this.gBReservar.TabStop = false;
            this.gBReservar.Text = "Reservar";
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Lavender;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Location = new System.Drawing.Point(181, 339);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(80, 23);
            this.btnImportar.TabIndex = 11;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            // 
            // labelCostoT
            // 
            this.labelCostoT.AutoSize = true;
            this.labelCostoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCostoT.Location = new System.Drawing.Point(116, 307);
            this.labelCostoT.Name = "labelCostoT";
            this.labelCostoT.Size = new System.Drawing.Size(19, 13);
            this.labelCostoT.TabIndex = 2;
            this.labelCostoT.Text = "...";
            // 
            // labelEgreso
            // 
            this.labelEgreso.AutoSize = true;
            this.labelEgreso.Location = new System.Drawing.Point(116, 280);
            this.labelEgreso.Name = "labelEgreso";
            this.labelEgreso.Size = new System.Drawing.Size(16, 13);
            this.labelEgreso.TabIndex = 10;
            this.labelEgreso.Text = "...";
            this.labelEgreso.Visible = false;
            // 
            // labelIngreso
            // 
            this.labelIngreso.AutoSize = true;
            this.labelIngreso.Location = new System.Drawing.Point(116, 253);
            this.labelIngreso.Name = "labelIngreso";
            this.labelIngreso.Size = new System.Drawing.Size(16, 13);
            this.labelIngreso.TabIndex = 9;
            this.labelIngreso.Text = "...";
            this.labelIngreso.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Costo Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dia Egreso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dia Ingreso:";
            // 
            // nUdPersonas
            // 
            this.nUdPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nUdPersonas.Location = new System.Drawing.Point(119, 219);
            this.nUdPersonas.Name = "nUdPersonas";
            this.nUdPersonas.Size = new System.Drawing.Size(109, 20);
            this.nUdPersonas.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cant. Personas:";
            // 
            // nUdDias
            // 
            this.nUdDias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nUdDias.Location = new System.Drawing.Point(119, 193);
            this.nUdDias.Name = "nUdDias";
            this.nUdDias.Size = new System.Drawing.Size(109, 20);
            this.nUdDias.TabIndex = 3;
            this.nUdDias.ValueChanged += new System.EventHandler(this.nUdDias_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cant. Dias:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.Lavender;
            this.monthCalendar1.Location = new System.Drawing.Point(36, 25);
            this.monthCalendar1.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MinDate = new System.DateTime(2022, 8, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Lavender;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(57, 339);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox4.Location = new System.Drawing.Point(293, 311);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(135, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox3.Location = new System.Drawing.Point(152, 311);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(135, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox2.Location = new System.Drawing.Point(12, 311);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(12, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SlateBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(986, 22);
            this.statusStrip1.TabIndex = 15;
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
            // ReservaV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(986, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gBReservar);
            this.Controls.Add(this.gBInfo);
            this.Name = "ReservaV";
            this.Text = "ReservaV";
            this.Load += new System.EventHandler(this.ReservaV_Load);
            this.Leave += new System.EventHandler(this.ReservaV_Leave);
            this.gBInfo.ResumeLayout(false);
            this.gBInfo.PerformLayout();
            this.gBCliente.ResumeLayout(false);
            this.gBCliente.PerformLayout();
            this.gBReservar.ResumeLayout(false);
            this.gBReservar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gBInfo;
        private System.Windows.Forms.GroupBox gBReservar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nUdPersonas;
        public System.Windows.Forms.NumericUpDown nUdDias;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label labelEgreso;
        public System.Windows.Forms.Label labelIngreso;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.ListBox lBDatos;
        public System.Windows.Forms.Label labelCostoT;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gBCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnExistentes;
        public System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.Label lblDNI;
        public System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
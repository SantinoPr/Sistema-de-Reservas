namespace TP2_LABII
{
    partial class ConsultarReserva
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
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.DGVReservas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnExportarReserva = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReservas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Lavender;
            this.btnInfo.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(16, 36);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(151, 24);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "Ver Reserva";
            this.btnInfo.UseVisualStyleBackColor = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Lavender;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Location = new System.Drawing.Point(16, 94);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(151, 24);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.Text = "Cancelar Reserva";
            this.btnBorrar.UseVisualStyleBackColor = false;
            // 
            // DGVReservas
            // 
            this.DGVReservas.AllowUserToAddRows = false;
            this.DGVReservas.AllowUserToDeleteRows = false;
            this.DGVReservas.AllowUserToOrderColumns = true;
            this.DGVReservas.AllowUserToResizeColumns = false;
            this.DGVReservas.AllowUserToResizeRows = false;
            this.DGVReservas.BackgroundColor = System.Drawing.Color.Lavender;
            this.DGVReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DGVReservas.Location = new System.Drawing.Point(187, 12);
            this.DGVReservas.Name = "DGVReservas";
            this.DGVReservas.ReadOnly = true;
            this.DGVReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReservas.Size = new System.Drawing.Size(346, 320);
            this.DGVReservas.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numero";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Hotel/Casa";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "DNI Cliente";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lavender;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(92, 309);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Cerrar";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(16, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(16, 124);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(151, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar Lista";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnExportarReserva
            // 
            this.btnExportarReserva.BackColor = System.Drawing.Color.Lavender;
            this.btnExportarReserva.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnExportarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarReserva.Location = new System.Drawing.Point(16, 65);
            this.btnExportarReserva.Name = "btnExportarReserva";
            this.btnExportarReserva.Size = new System.Drawing.Size(151, 24);
            this.btnExportarReserva.TabIndex = 9;
            this.btnExportarReserva.Text = "Exportar Reserva";
            this.btnExportarReserva.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SlateBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 336);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(545, 22);
            this.statusStrip1.TabIndex = 14;
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
            // ConsultarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(545, 358);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnExportarReserva);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DGVReservas);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnInfo);
            this.Name = "ConsultarReserva";
            this.Text = "ConsultarReserva";
            this.Load += new System.EventHandler(this.ConsultarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReservas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnInfo;
        public System.Windows.Forms.Button btnBorrar;
        public System.Windows.Forms.DataGridView DGVReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.Button btnExportarReserva;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
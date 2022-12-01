
namespace TP2_LABII
{
    partial class ClientesVNuevo
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
            this.gBCliente = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tBDNI = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gBCliente.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBCliente
            // 
            this.gBCliente.Controls.Add(this.button1);
            this.gBCliente.Controls.Add(this.btnCancelar);
            this.gBCliente.Controls.Add(this.tBDNI);
            this.gBCliente.Controls.Add(this.label7);
            this.gBCliente.Controls.Add(this.tBNombre);
            this.gBCliente.Controls.Add(this.label6);
            this.gBCliente.Location = new System.Drawing.Point(21, 12);
            this.gBCliente.Name = "gBCliente";
            this.gBCliente.Size = new System.Drawing.Size(223, 133);
            this.gBCliente.TabIndex = 7;
            this.gBCliente.TabStop = false;
            this.gBCliente.Text = "Datos Cliente";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Lavender;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(115, 94);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // tBDNI
            // 
            this.tBDNI.Location = new System.Drawing.Point(58, 54);
            this.tBDNI.Name = "tBDNI";
            this.tBDNI.Size = new System.Drawing.Size(159, 20);
            this.tBDNI.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "DNI:";
            // 
            // tBNombre
            // 
            this.tBNombre.Location = new System.Drawing.Point(58, 24);
            this.tBNombre.Name = "tBNombre";
            this.tBNombre.Size = new System.Drawing.Size(159, 20);
            this.tBNombre.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SlateBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 146);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(267, 22);
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
            // ClientesVNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(267, 168);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gBCliente);
            this.Name = "ClientesVNuevo";
            this.Text = "ClientesVNuevo";
            this.gBCliente.ResumeLayout(false);
            this.gBCliente.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBCliente;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox tBDNI;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tBNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
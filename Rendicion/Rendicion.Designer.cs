namespace PagoAgilFrba.Rendicion
{
    partial class Rendicion
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectorEmpresa = new System.Windows.Forms.ComboBox();
            this.btnObtener = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRendir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComision = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // selectorEmpresa
            // 
            this.selectorEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorEmpresa.FormattingEnabled = true;
            this.selectorEmpresa.Location = new System.Drawing.Point(137, 31);
            this.selectorEmpresa.Name = "selectorEmpresa";
            this.selectorEmpresa.Size = new System.Drawing.Size(140, 21);
            this.selectorEmpresa.TabIndex = 1;
            // 
            // btnObtener
            // 
            this.btnObtener.Location = new System.Drawing.Point(353, 29);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(105, 23);
            this.btnObtener.TabIndex = 2;
            this.btnObtener.Text = "Obtener facturas";
            this.btnObtener.UseVisualStyleBackColor = true;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Total,
            this.Cliente,
            this.FechaAlta,
            this.FechaVencimiento,
            this.Seleccionar,
            this.Seleccion});
            this.dgvFacturas.Location = new System.Drawing.Point(25, 151);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(637, 185);
            this.dgvFacturas.TabIndex = 67;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 70;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 50;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 70;
            // 
            // FechaAlta
            // 
            this.FechaAlta.HeaderText = "Fecha de Alta";
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "Seleccionar";
            this.Seleccion.Name = "Seleccion";
            // 
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(262, 354);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(101, 41);
            this.btnRendir.TabIndex = 68;
            this.btnRendir.Text = "Rendir";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(118, 354);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(101, 41);
            this.btnVolver.TabIndex = 68;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Comision";
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(137, 70);
            this.txtComision.Mask = "9999999";
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(140, 20);
            this.txtComision.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Facturas que pueden ser rendidas";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(400, 354);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 41);
            this.btnLimpiar.TabIndex = 68;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Rendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 407);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnObtener);
            this.Controls.Add(this.selectorEmpresa);
            this.Controls.Add(this.label1);
            this.Name = "Rendicion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Rendicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectorEmpresa;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtComision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccion;
    }
}
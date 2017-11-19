namespace PagoAgilFrba.AbmFactura
{
    partial class Baja
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
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAlta = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBaja = new System.Windows.Forms.Label();
            this.btnBaja = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.Monto,
            this.Cantidad});
            this.dgvItems.Location = new System.Drawing.Point(73, 172);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(348, 172);
            this.dgvItems.TabIndex = 68;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "¿Seguro que desea eliminar la factura?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Numero:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(143, 56);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(35, 13);
            this.lblNumero.TabIndex = 70;
            this.lblNumero.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Empresa:";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(143, 89);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(35, 13);
            this.lblEmpresa.TabIndex = 70;
            this.lblEmpresa.Text = "label2";
            this.lblEmpresa.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Cliente:";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(143, 127);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(35, 13);
            this.lblCliente.TabIndex = 70;
            this.lblCliente.Text = "label2";
            this.lblCliente.Click += new System.EventHandler(this.label2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Total:";
            this.label8.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "Fecha alta:";
            this.label9.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(376, 56);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 70;
            this.lblTotal.Text = "label2";
            this.lblTotal.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAlta
            // 
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(376, 89);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(35, 13);
            this.lblAlta.TabIndex = 70;
            this.lblAlta.Text = "label2";
            this.lblAlta.Click += new System.EventHandler(this.label2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Fecha vencimiento:";
            this.label12.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblBaja
            // 
            this.lblBaja.AutoSize = true;
            this.lblBaja.Location = new System.Drawing.Point(376, 127);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(35, 13);
            this.lblBaja.TabIndex = 70;
            this.lblBaja.Text = "label2";
            this.lblBaja.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(235, 350);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(104, 35);
            this.btnBaja.TabIndex = 71;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 72;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblBaja);
            this.Controls.Add(this.lblAlta);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvItems);
            this.Name = "Baja";
            this.Text = "Baja";
            this.Load += new System.EventHandler(this.Baja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBaja;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Button button1;
    }
}
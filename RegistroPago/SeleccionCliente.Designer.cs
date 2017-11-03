namespace PagoAgilFrba.RegistroPago
{
    partial class SeleccionCliente
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sucursal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.buscarCliente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCobro = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.fecha);
            this.panel2.Location = new System.Drawing.Point(208, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 52);
            this.panel2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha:";
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(3, 27);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(15, 16);
            this.fecha.TabIndex = 5;
            this.fecha.Text = "_";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sucursal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 52);
            this.panel1.TabIndex = 8;
            // 
            // sucursal
            // 
            this.sucursal.AutoSize = true;
            this.sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursal.Location = new System.Drawing.Point(3, 26);
            this.sucursal.Name = "sucursal";
            this.sucursal.Size = new System.Drawing.Size(16, 17);
            this.sucursal.TabIndex = 8;
            this.sucursal.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sucursal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(95, 103);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(16, 17);
            this.lblCliente.TabIndex = 11;
            this.lblCliente.Text = "_";
            // 
            // buscarCliente
            // 
            this.buscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarCliente.Location = new System.Drawing.Point(208, 134);
            this.buscarCliente.Name = "buscarCliente";
            this.buscarCliente.Size = new System.Drawing.Size(82, 38);
            this.buscarCliente.TabIndex = 12;
            this.buscarCliente.Text = "Buscar";
            this.buscarCliente.UseVisualStyleBackColor = true;
            this.buscarCliente.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(93, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCobro
            // 
            this.btnCobro.Enabled = false;
            this.btnCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobro.Location = new System.Drawing.Point(25, 183);
            this.btnCobro.Name = "btnCobro";
            this.btnCobro.Size = new System.Drawing.Size(265, 40);
            this.btnCobro.TabIndex = 14;
            this.btnCobro.Text = "Agregar Facturas";
            this.btnCobro.UseVisualStyleBackColor = true;
            this.btnCobro.Click += new System.EventHandler(this.btnCobro_Click);
            // 
            // SeleccionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 282);
            this.Controls.Add(this.btnCobro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buscarCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SeleccionCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago de facturas";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button buscarCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCobro;
    }
}
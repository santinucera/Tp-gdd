namespace PagoAgilFrba.Menu
{
    partial class MenuFuncionalidades
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
            this.btnABMRol = new System.Windows.Forms.Button();
            this.btnABMCliente = new System.Windows.Forms.Button();
            this.btnABMEmpresa = new System.Windows.Forms.Button();
            this.btnABMSucursal = new System.Windows.Forms.Button();
            this.btnABMFactura = new System.Windows.Forms.Button();
            this.btnRegistroFactura = new System.Windows.Forms.Button();
            this.btnRendicionFactura = new System.Windows.Forms.Button();
            this.btnListado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnABMRol
            // 
            this.btnABMRol.Location = new System.Drawing.Point(89, 73);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(174, 23);
            this.btnABMRol.TabIndex = 0;
            this.btnABMRol.Text = "ABM de Rol";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Visible = false;
            // 
            // btnABMCliente
            // 
            this.btnABMCliente.Location = new System.Drawing.Point(308, 73);
            this.btnABMCliente.Name = "btnABMCliente";
            this.btnABMCliente.Size = new System.Drawing.Size(174, 23);
            this.btnABMCliente.TabIndex = 0;
            this.btnABMCliente.Text = "ABM de Cliente";
            this.btnABMCliente.UseVisualStyleBackColor = true;
            this.btnABMCliente.Visible = false;
            // 
            // btnABMEmpresa
            // 
            this.btnABMEmpresa.Location = new System.Drawing.Point(89, 120);
            this.btnABMEmpresa.Name = "btnABMEmpresa";
            this.btnABMEmpresa.Size = new System.Drawing.Size(174, 23);
            this.btnABMEmpresa.TabIndex = 0;
            this.btnABMEmpresa.Text = "ABM de Empresa";
            this.btnABMEmpresa.UseVisualStyleBackColor = true;
            this.btnABMEmpresa.Visible = false;
            // 
            // btnABMSucursal
            // 
            this.btnABMSucursal.Location = new System.Drawing.Point(308, 120);
            this.btnABMSucursal.Name = "btnABMSucursal";
            this.btnABMSucursal.Size = new System.Drawing.Size(174, 23);
            this.btnABMSucursal.TabIndex = 0;
            this.btnABMSucursal.Text = "ABM de Sucursal";
            this.btnABMSucursal.UseVisualStyleBackColor = true;
            this.btnABMSucursal.Visible = false;
            this.btnABMSucursal.Click += new System.EventHandler(this.btnABMSucursal_Click);
            // 
            // btnABMFactura
            // 
            this.btnABMFactura.Location = new System.Drawing.Point(89, 167);
            this.btnABMFactura.Name = "btnABMFactura";
            this.btnABMFactura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnABMFactura.Size = new System.Drawing.Size(174, 23);
            this.btnABMFactura.TabIndex = 0;
            this.btnABMFactura.Text = "ABM de Facturas";
            this.btnABMFactura.UseVisualStyleBackColor = true;
            this.btnABMFactura.Visible = false;
            this.btnABMFactura.Click += new System.EventHandler(this.btnABMFactura_Click);
            // 
            // btnRegistroFactura
            // 
            this.btnRegistroFactura.Location = new System.Drawing.Point(308, 167);
            this.btnRegistroFactura.Name = "btnRegistroFactura";
            this.btnRegistroFactura.Size = new System.Drawing.Size(174, 23);
            this.btnRegistroFactura.TabIndex = 0;
            this.btnRegistroFactura.Text = "Registro de Pago de Facturas";
            this.btnRegistroFactura.UseVisualStyleBackColor = true;
            this.btnRegistroFactura.Visible = false;
            // 
            // btnRendicionFactura
            // 
            this.btnRendicionFactura.Location = new System.Drawing.Point(89, 225);
            this.btnRendicionFactura.Name = "btnRendicionFactura";
            this.btnRendicionFactura.Size = new System.Drawing.Size(174, 23);
            this.btnRendicionFactura.TabIndex = 0;
            this.btnRendicionFactura.Text = "Rendicion de Facturas Cobradas";
            this.btnRendicionFactura.UseVisualStyleBackColor = true;
            this.btnRendicionFactura.Visible = false;
            // 
            // btnListado
            // 
            this.btnListado.Location = new System.Drawing.Point(308, 225);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(174, 23);
            this.btnListado.TabIndex = 0;
            this.btnListado.Text = "Listado Estadistico";
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione funcionalidad disponible:";
            // 
            // MenuFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 316);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.btnRegistroFactura);
            this.Controls.Add(this.btnABMSucursal);
            this.Controls.Add(this.btnABMCliente);
            this.Controls.Add(this.btnRendicionFactura);
            this.Controls.Add(this.btnABMFactura);
            this.Controls.Add(this.btnABMEmpresa);
            this.Controls.Add(this.btnABMRol);
            this.Name = "MenuFuncionalidades";
            this.Text = "MenuFuncionalidades";
            this.Load += new System.EventHandler(this.MenuFuncionalidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnABMRol;
        private System.Windows.Forms.Button btnABMCliente;
        private System.Windows.Forms.Button btnABMEmpresa;
        private System.Windows.Forms.Button btnABMSucursal;
        private System.Windows.Forms.Button btnABMFactura;
        private System.Windows.Forms.Button btnRegistroFactura;
        private System.Windows.Forms.Button btnRendicionFactura;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Label label1;
    }
}
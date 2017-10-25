namespace PagoAgilFrba.AbmSucursal
{
    partial class Listado
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
            this.volver = new System.Windows.Forms.Button();
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BajaOModificacion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(293, 355);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(119, 23);
            this.volver.TabIndex = 56;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Direccion,
            this.CodigoPostal,
            this.Habilitada,
            this.Modificar,
            this.BajaOModificacion});
            this.dgvSucursales.Location = new System.Drawing.Point(38, 187);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.Size = new System.Drawing.Size(648, 149);
            this.dgvSucursales.TabIndex = 55;
            this.dgvSucursales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(518, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 25);
            this.button4.TabIndex = 54;
            this.button4.Text = "Buscar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(75, 131);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 25);
            this.btnLimpiar.TabIndex = 53;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(265, 77);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Direccion:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(424, 77);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Codigo Postal :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(117, 77);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nombre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.HeaderText = "CodigoPostal";
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.ReadOnly = true;
            // 
            // Habilitada
            // 
            this.Habilitada.HeaderText = "Habilitada";
            this.Habilitada.Name = "Habilitada";
            this.Habilitada.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            // 
            // BajaOModificacion
            // 
            this.BajaOModificacion.HeaderText = "BajaOModificacion";
            this.BajaOModificacion.Name = "BajaOModificacion";
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 404);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dgvSucursales);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.Listado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.DataGridView dgvSucursales;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitada;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn BajaOModificacion;
    }
}
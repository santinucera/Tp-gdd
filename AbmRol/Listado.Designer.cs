namespace PagoAgilFrba.AbmRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Baja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreFiltro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.Location = new System.Drawing.Point(90, 20);
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtNombreFiltro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToOrderColumns = true;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripción,
            this.Habilitado,
            this.Modificar,
            this.Baja});
            this.dgvRoles.Location = new System.Drawing.Point(12, 146);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(460, 150);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 105);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(397, 105);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 318);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            // 
            // Baja
            // 
            this.Baja.HeaderText = "Baja";
            this.Baja.Name = "Baja";
            this.Baja.ReadOnly = true;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 353);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.groupBox1);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.Listado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Baja;

    }
}
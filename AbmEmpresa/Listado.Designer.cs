namespace PagoAgilFrba.AbmEmpresa
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
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectorRubros = new System.Windows.Forms.ComboBox();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUITColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaRendicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CUITColumn,
            this.DiaRendicion,
            this.columnaRubro,
            this.Habilitada,
            this.Modificar,
            this.BajaOModificacion});
            this.dgvSucursales.Location = new System.Drawing.Point(12, 187);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.Size = new System.Drawing.Size(704, 149);
            this.dgvSucursales.TabIndex = 55;
            this.dgvSucursales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(555, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 25);
            this.button4.TabIndex = 54;
            this.button4.Text = "Buscar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(38, 116);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 25);
            this.btnLimpiar.TabIndex = 53;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(254, 77);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(100, 20);
            this.txtCuit.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "CUIT :";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Rubro:";
            // 
            // selectorRubros
            // 
            this.selectorRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorRubros.FormattingEnabled = true;
            this.selectorRubros.Location = new System.Drawing.Point(394, 77);
            this.selectorRubros.Name = "selectorRubros";
            this.selectorRubros.Size = new System.Drawing.Size(121, 21);
            this.selectorRubros.TabIndex = 58;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 110;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 80;
            // 
            // CUITColumn
            // 
            this.CUITColumn.HeaderText = "CUIT";
            this.CUITColumn.Name = "CUITColumn";
            this.CUITColumn.ReadOnly = true;
            this.CUITColumn.Width = 80;
            // 
            // DiaRendicion
            // 
            this.DiaRendicion.HeaderText = "DiaRendicion";
            this.DiaRendicion.Name = "DiaRendicion";
            this.DiaRendicion.ReadOnly = true;
            this.DiaRendicion.Width = 60;
            // 
            // columnaRubro
            // 
            this.columnaRubro.HeaderText = "Rubro";
            this.columnaRubro.Name = "columnaRubro";
            this.columnaRubro.ReadOnly = true;
            this.columnaRubro.Width = 70;
            // 
            // Habilitada
            // 
            this.Habilitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Habilitada.HeaderText = "Habilitada";
            this.Habilitada.Name = "Habilitada";
            this.Habilitada.ReadOnly = true;
            this.Habilitada.Width = 60;
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
            this.ClientSize = new System.Drawing.Size(737, 404);
            this.Controls.Add(this.selectorRubros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dgvSucursales);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Listado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Empresas";
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
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectorRubros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUITColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaRendicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaRubro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitada;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn BajaOModificacion;
    }
}
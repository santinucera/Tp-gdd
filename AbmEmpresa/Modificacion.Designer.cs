namespace PagoAgilFrba.AbmEmpresa
{
    partial class Modificacion
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
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.rubro = new System.Windows.Forms.Label();
            this.selectorRubros = new System.Windows.Forms.ComboBox();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(147, 131);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(100, 20);
            this.txtCuit.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(147, 99);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(147, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CUIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ingrese los siguientes campos";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(40, 198);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(207, 23);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Guardar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // rubro
            // 
            this.rubro.AutoSize = true;
            this.rubro.Location = new System.Drawing.Point(58, 161);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(36, 13);
            this.rubro.TabIndex = 11;
            this.rubro.Text = "Rubro";
            // 
            // selectorRubros
            // 
            this.selectorRubros.FormattingEnabled = true;
            this.selectorRubros.Location = new System.Drawing.Point(147, 161);
            this.selectorRubros.Name = "selectorRubros";
            this.selectorRubros.Size = new System.Drawing.Size(100, 21);
            this.selectorRubros.TabIndex = 12;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(101, 235);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 13;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 270);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.selectorRubros);
            this.Controls.Add(this.rubro);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIngresar);
            this.Name = "Modificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label rubro;
        private System.Windows.Forms.ComboBox selectorRubros;
        private System.Windows.Forms.Button volver;
    }
}
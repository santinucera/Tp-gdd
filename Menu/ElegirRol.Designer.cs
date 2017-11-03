namespace PagoAgilFrba.Menu
{
    partial class ElegirRol
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
            this.selectorRol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.selectorSucursales = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // selectorRol
            // 
            this.selectorRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectorRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorRol.FormattingEnabled = true;
            this.selectorRol.Location = new System.Drawing.Point(153, 62);
            this.selectorRol.Name = "selectorRol";
            this.selectorRol.Size = new System.Drawing.Size(168, 21);
            this.selectorRol.TabIndex = 0;
            this.selectorRol.SelectedIndexChanged += new System.EventHandler(this.selectorRol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione rol:";
            // 
            // btnAcceder
            // 
            this.btnAcceder.Enabled = false;
            this.btnAcceder.Location = new System.Drawing.Point(153, 187);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(95, 34);
            this.btnAcceder.TabIndex = 2;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = true;
            this.btnAcceder.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(42, 120);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(105, 13);
            this.lblSucursal.TabIndex = 4;
            this.lblSucursal.Text = "Seleccione sucursal:";
            this.lblSucursal.Visible = false;
            // 
            // selectorSucursales
            // 
            this.selectorSucursales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectorSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorSucursales.FormattingEnabled = true;
            this.selectorSucursales.Location = new System.Drawing.Point(153, 117);
            this.selectorSucursales.Name = "selectorSucursales";
            this.selectorSucursales.Size = new System.Drawing.Size(168, 21);
            this.selectorSucursales.TabIndex = 3;
            this.selectorSucursales.Visible = false;
            this.selectorSucursales.SelectedIndexChanged += new System.EventHandler(this.selectorSucursales_SelectedIndexChanged);
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 262);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.selectorSucursales);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectorRol);
            this.Name = "ElegirRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ElegirRol";
            this.Load += new System.EventHandler(this.ElegirRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectorRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.ComboBox selectorSucursales;
    }
}
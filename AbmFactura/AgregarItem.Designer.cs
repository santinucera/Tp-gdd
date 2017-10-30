namespace PagoAgilFrba.AbmFactura
{
    partial class AgregarItem
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
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.MaskedTextBox();
            this.txtMonto = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(125, 30);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(100, 20);
            this.txtConcepto.TabIndex = 23;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(125, 143);
            this.txtCantidad.Mask = "999999";
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 17;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(125, 84);
            this.txtMonto.Mask = "999999";
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Monto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Concepto:";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(150, 210);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarItem.TabIndex = 19;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click_1);
            // 
            // AgregarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAgregarItem);
            this.Name = "AgregarItem";
            this.Text = "AgregarItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.MaskedTextBox txtCantidad;
        private System.Windows.Forms.MaskedTextBox txtMonto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarItem;

    }
}
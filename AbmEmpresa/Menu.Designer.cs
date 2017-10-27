namespace PagoAgilFrba.AbmEmpresa
{
    partial class MenuEmpresas
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione opcion:";
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(163, 122);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(95, 35);
            this.btnBaja.TabIndex = 2;
            this.btnBaja.Text = "Listado";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(163, 55);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(95, 35);
            this.btnAlta.TabIndex = 3;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(91, 215);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(95, 35);
            this.volver.TabIndex = 5;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // MenuEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnAlta);
            this.Name = "MenuEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button volver;
    }
}
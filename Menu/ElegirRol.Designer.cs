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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectorRol
            // 
            this.selectorRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectorRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorRol.FormattingEnabled = true;
            this.selectorRol.Location = new System.Drawing.Point(143, 62);
            this.selectorRol.Name = "selectorRol";
            this.selectorRol.Size = new System.Drawing.Size(168, 21);
            this.selectorRol.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Acceder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectorRol);
            this.Name = "ElegirRol";
            this.Text = "ElegirRol";
            this.Load += new System.EventHandler(this.ElegirRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectorRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
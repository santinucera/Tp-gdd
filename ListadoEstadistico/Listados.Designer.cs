namespace PagoAgilFrba.ListadoEstadistico
{
    partial class Listados
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
            this.label2 = new System.Windows.Forms.Label();
            this.selectorTrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectorListado = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.selectorAnios = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // selectorTrimestre
            // 
            this.selectorTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorTrimestre.FormattingEnabled = true;
            this.selectorTrimestre.Location = new System.Drawing.Point(231, 99);
            this.selectorTrimestre.Name = "selectorTrimestre";
            this.selectorTrimestre.Size = new System.Drawing.Size(44, 21);
            this.selectorTrimestre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Listado";
            // 
            // selectorListado
            // 
            this.selectorListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorListado.FormattingEnabled = true;
            this.selectorListado.Location = new System.Drawing.Point(231, 154);
            this.selectorListado.Name = "selectorListado";
            this.selectorListado.Size = new System.Drawing.Size(198, 21);
            this.selectorListado.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(26, 242);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(89, 31);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(331, 242);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(98, 31);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // selectorAnios
            // 
            this.selectorAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorAnios.FormattingEnabled = true;
            this.selectorAnios.Location = new System.Drawing.Point(231, 45);
            this.selectorAnios.Name = "selectorAnios";
            this.selectorAnios.Size = new System.Drawing.Size(81, 21);
            this.selectorAnios.TabIndex = 9;
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 301);
            this.Controls.Add(this.selectorAnios);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.selectorListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectorTrimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Listados";
            this.Text = "Listados";
            this.Load += new System.EventHandler(this.Listados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectorTrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectorListado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox selectorAnios;
    }
}
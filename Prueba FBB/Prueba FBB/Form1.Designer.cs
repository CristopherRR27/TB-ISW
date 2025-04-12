namespace Prueba_FBB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNP = new System.Windows.Forms.Button();
            this.btnPropietario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNP
            // 
            this.btnNP.Font = new System.Drawing.Font("Rochester", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNP.Location = new System.Drawing.Point(179, 146);
            this.btnNP.Name = "btnNP";
            this.btnNP.Size = new System.Drawing.Size(286, 60);
            this.btnNP.TabIndex = 0;
            this.btnNP.Text = "Nuevo Propietario";
            this.btnNP.UseVisualStyleBackColor = true;
            this.btnNP.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPropietario
            // 
            this.btnPropietario.Font = new System.Drawing.Font("Rochester", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPropietario.Location = new System.Drawing.Point(179, 244);
            this.btnPropietario.Name = "btnPropietario";
            this.btnPropietario.Size = new System.Drawing.Size(286, 64);
            this.btnPropietario.TabIndex = 1;
            this.btnPropietario.Text = "Propietario ";
            this.btnPropietario.UseVisualStyleBackColor = true;
            this.btnPropietario.Click += new System.EventHandler(this.btnPropietario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rochester", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "CRR. Alquiler y venta de propiedades";
            // 
            // btnCA
            // 
            this.btnCA.Font = new System.Drawing.Font("Rochester", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCA.Location = new System.Drawing.Point(179, 338);
            this.btnCA.Name = "btnCA";
            this.btnCA.Size = new System.Drawing.Size(286, 64);
            this.btnCA.TabIndex = 3;
            this.btnCA.Text = "Compra y Alquiler";
            this.btnCA.UseVisualStyleBackColor = true;
            this.btnCA.Click += new System.EventHandler(this.btnCA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.btnCA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPropietario);
            this.Controls.Add(this.btnNP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNP;
        private System.Windows.Forms.Button btnPropietario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCA;
    }
}


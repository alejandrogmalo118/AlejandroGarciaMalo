namespace WindowsFormsImperio
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.listRebeldesAñadidos = new System.Windows.Forms.ListBox();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.lblPlaneta = new System.Windows.Forms.Label();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.txtPlaneta = new System.Windows.Forms.TextBox();
            this.lblTituloAñadir = new System.Windows.Forms.Label();
            this.lblRebeldes = new System.Windows.Forms.Label();
            this.listRebeldes = new System.Windows.Forms.ListBox();
            this.btnRebeldes = new System.Windows.Forms.Button();
            this.dateRegistro = new System.Windows.Forms.DateTimePicker();
            this.btnAñadirSubir = new System.Windows.Forms.Button();
            this.btnSubirLista = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 48);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // listRebeldesAñadidos
            // 
            this.listRebeldesAñadidos.FormattingEnabled = true;
            this.listRebeldesAñadidos.Location = new System.Drawing.Point(265, 34);
            this.listRebeldesAñadidos.Name = "listRebeldesAñadidos";
            this.listRebeldesAñadidos.Size = new System.Drawing.Size(220, 95);
            this.listRebeldesAñadidos.TabIndex = 2;
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(59, 135);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 3;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // lblPlaneta
            // 
            this.lblPlaneta.AutoSize = true;
            this.lblPlaneta.Location = new System.Drawing.Point(12, 77);
            this.lblPlaneta.Name = "lblPlaneta";
            this.lblPlaneta.Size = new System.Drawing.Size(43, 13);
            this.lblPlaneta.TabIndex = 4;
            this.lblPlaneta.Text = "Planeta";
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Location = new System.Drawing.Point(12, 104);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(46, 13);
            this.lblRegistro.TabIndex = 5;
            this.lblRegistro.Text = "Registro";
            // 
            // txtPlaneta
            // 
            this.txtPlaneta.Location = new System.Drawing.Point(59, 74);
            this.txtPlaneta.Name = "txtPlaneta";
            this.txtPlaneta.Size = new System.Drawing.Size(200, 20);
            this.txtPlaneta.TabIndex = 6;
            // 
            // lblTituloAñadir
            // 
            this.lblTituloAñadir.AutoSize = true;
            this.lblTituloAñadir.Location = new System.Drawing.Point(56, 18);
            this.lblTituloAñadir.Name = "lblTituloAñadir";
            this.lblTituloAñadir.Size = new System.Drawing.Size(128, 13);
            this.lblTituloAñadir.TabIndex = 8;
            this.lblTituloAñadir.Text = "Añadir Rebelde al registro";
            // 
            // lblRebeldes
            // 
            this.lblRebeldes.AutoSize = true;
            this.lblRebeldes.Location = new System.Drawing.Point(510, 18);
            this.lblRebeldes.Name = "lblRebeldes";
            this.lblRebeldes.Size = new System.Drawing.Size(52, 13);
            this.lblRebeldes.TabIndex = 9;
            this.lblRebeldes.Text = "Rebeldes";
            // 
            // listRebeldes
            // 
            this.listRebeldes.FormattingEnabled = true;
            this.listRebeldes.Location = new System.Drawing.Point(513, 34);
            this.listRebeldes.Name = "listRebeldes";
            this.listRebeldes.Size = new System.Drawing.Size(220, 95);
            this.listRebeldes.TabIndex = 10;
            // 
            // btnRebeldes
            // 
            this.btnRebeldes.Location = new System.Drawing.Point(513, 135);
            this.btnRebeldes.Name = "btnRebeldes";
            this.btnRebeldes.Size = new System.Drawing.Size(75, 23);
            this.btnRebeldes.TabIndex = 11;
            this.btnRebeldes.Text = "Obtener";
            this.btnRebeldes.UseVisualStyleBackColor = true;
            this.btnRebeldes.Click += new System.EventHandler(this.btnRebeldes_Click);
            // 
            // dateRegistro
            // 
            this.dateRegistro.Location = new System.Drawing.Point(59, 100);
            this.dateRegistro.Name = "dateRegistro";
            this.dateRegistro.Size = new System.Drawing.Size(200, 20);
            this.dateRegistro.TabIndex = 12;
            // 
            // btnAñadirSubir
            // 
            this.btnAñadirSubir.Location = new System.Drawing.Point(140, 135);
            this.btnAñadirSubir.Name = "btnAñadirSubir";
            this.btnAñadirSubir.Size = new System.Drawing.Size(94, 23);
            this.btnAñadirSubir.TabIndex = 13;
            this.btnAñadirSubir.Text = "Añadir y subir";
            this.btnAñadirSubir.UseVisualStyleBackColor = true;
            this.btnAñadirSubir.Click += new System.EventHandler(this.btnAñadirSubir_Click);
            // 
            // btnSubirLista
            // 
            this.btnSubirLista.Location = new System.Drawing.Point(265, 135);
            this.btnSubirLista.Name = "btnSubirLista";
            this.btnSubirLista.Size = new System.Drawing.Size(75, 23);
            this.btnSubirLista.TabIndex = 14;
            this.btnSubirLista.Text = "Subir lista";
            this.btnSubirLista.UseVisualStyleBackColor = true;
            this.btnSubirLista.Click += new System.EventHandler(this.btnSubirLista_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 196);
            this.Controls.Add(this.btnSubirLista);
            this.Controls.Add(this.btnAñadirSubir);
            this.Controls.Add(this.dateRegistro);
            this.Controls.Add(this.btnRebeldes);
            this.Controls.Add(this.listRebeldes);
            this.Controls.Add(this.lblRebeldes);
            this.Controls.Add(this.lblTituloAñadir);
            this.Controls.Add(this.txtPlaneta);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.lblPlaneta);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.listRebeldesAñadidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ListBox listRebeldesAñadidos;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Label lblPlaneta;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.TextBox txtPlaneta;
        private System.Windows.Forms.Label lblTituloAñadir;
        private System.Windows.Forms.Label lblRebeldes;
        private System.Windows.Forms.ListBox listRebeldes;
        private System.Windows.Forms.Button btnRebeldes;
        private System.Windows.Forms.DateTimePicker dateRegistro;
        private System.Windows.Forms.Button btnAñadirSubir;
        private System.Windows.Forms.Button btnSubirLista;
    }
}


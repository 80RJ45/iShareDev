namespace cDevelop.Forms
{
    partial class frmImportarInventario
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
            this.lblCargados = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.lblRechazados = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCargados
            // 
            this.lblCargados.AutoSize = true;
            this.lblCargados.Location = new System.Drawing.Point(104, 40);
            this.lblCargados.Name = "lblCargados";
            this.lblCargados.Size = new System.Drawing.Size(101, 13);
            this.lblCargados.TabIndex = 0;
            this.lblCargados.Text = "Registros cargados:";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 81);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.Size = new System.Drawing.Size(785, 418);
            this.dgvArticulos.TabIndex = 1;
            // 
            // lblRechazados
            // 
            this.lblRechazados.AutoSize = true;
            this.lblRechazados.Location = new System.Drawing.Point(576, 40);
            this.lblRechazados.Name = "lblRechazados";
            this.lblRechazados.Size = new System.Drawing.Size(110, 13);
            this.lblRechazados.TabIndex = 2;
            this.lblRechazados.Text = "Registros por corregir:";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(12, 35);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(722, 35);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // frmImportarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.lblRechazados);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.lblCargados);
            this.Name = "frmImportarInventario";
            this.Text = "Importar Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCargados;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label lblRechazados;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnSalvar;
    }
}

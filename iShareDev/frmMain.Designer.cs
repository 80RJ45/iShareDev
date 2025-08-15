namespace iShareDev
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.pruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoActivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroCostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depreciaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matriculaEagleWingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosEndpointPruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anticiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adelantosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cosechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobroBancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursosHumanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoCapacitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capacitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pruebaToolStripMenuItem,
            this.matriculaEagleWingsToolStripMenuItem,
            this.webToolStripMenuItem,
            this.anticiposToolStripMenuItem,
            this.cosechasToolStripMenuItem,
            this.cobroBancoToolStripMenuItem,
            this.importarToolStripMenuItem,
            this.recursosHumanosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(843, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // pruebaToolStripMenuItem
            // 
            this.pruebaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoActivoToolStripMenuItem,
            this.centroCostoToolStripMenuItem,
            this.activosToolStripMenuItem,
            this.depreciaciónToolStripMenuItem});
            this.pruebaToolStripMenuItem.Name = "pruebaToolStripMenuItem";
            this.pruebaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pruebaToolStripMenuItem.Text = "Activos";
            this.pruebaToolStripMenuItem.Click += new System.EventHandler(this.pruebaToolStripMenuItem_Click);
            // 
            // tipoActivoToolStripMenuItem
            // 
            this.tipoActivoToolStripMenuItem.Name = "tipoActivoToolStripMenuItem";
            this.tipoActivoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.tipoActivoToolStripMenuItem.Text = "Tipo Activo";
            this.tipoActivoToolStripMenuItem.Click += new System.EventHandler(this.tipoActivoToolStripMenuItem_Click);
            // 
            // centroCostoToolStripMenuItem
            // 
            this.centroCostoToolStripMenuItem.Name = "centroCostoToolStripMenuItem";
            this.centroCostoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.centroCostoToolStripMenuItem.Text = "Centro Costo";
            this.centroCostoToolStripMenuItem.Click += new System.EventHandler(this.centroCostoToolStripMenuItem_Click);
            // 
            // activosToolStripMenuItem
            // 
            this.activosToolStripMenuItem.Name = "activosToolStripMenuItem";
            this.activosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.activosToolStripMenuItem.Text = "Activos";
            this.activosToolStripMenuItem.Click += new System.EventHandler(this.activosToolStripMenuItem_Click);
            // 
            // depreciaciónToolStripMenuItem
            // 
            this.depreciaciónToolStripMenuItem.Name = "depreciaciónToolStripMenuItem";
            this.depreciaciónToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.depreciaciónToolStripMenuItem.Text = "Depreciación";
            this.depreciaciónToolStripMenuItem.Click += new System.EventHandler(this.depreciaciónToolStripMenuItem_Click);
            // 
            // matriculaEagleWingsToolStripMenuItem
            // 
            this.matriculaEagleWingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alumnosEndpointPruebaToolStripMenuItem});
            this.matriculaEagleWingsToolStripMenuItem.Name = "matriculaEagleWingsToolStripMenuItem";
            this.matriculaEagleWingsToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.matriculaEagleWingsToolStripMenuItem.Text = "Matricula EagleWings";
            // 
            // alumnosEndpointPruebaToolStripMenuItem
            // 
            this.alumnosEndpointPruebaToolStripMenuItem.Name = "alumnosEndpointPruebaToolStripMenuItem";
            this.alumnosEndpointPruebaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.alumnosEndpointPruebaToolStripMenuItem.Text = "Alumnos Endpoint prueba";
            this.alumnosEndpointPruebaToolStripMenuItem.Click += new System.EventHandler(this.alumnosEndpointPruebaToolStripMenuItem_Click);
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentQueryToolStripMenuItem});
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.webToolStripMenuItem.Text = "Web";
            // 
            // paymentQueryToolStripMenuItem
            // 
            this.paymentQueryToolStripMenuItem.Name = "paymentQueryToolStripMenuItem";
            this.paymentQueryToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.paymentQueryToolStripMenuItem.Text = "Payment Query";
            this.paymentQueryToolStripMenuItem.Click += new System.EventHandler(this.paymentQueryToolStripMenuItem_Click);
            // 
            // anticiposToolStripMenuItem
            // 
            this.anticiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adelantosToolStripMenuItem});
            this.anticiposToolStripMenuItem.Name = "anticiposToolStripMenuItem";
            this.anticiposToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.anticiposToolStripMenuItem.Text = "Anticipos";
            // 
            // adelantosToolStripMenuItem
            // 
            this.adelantosToolStripMenuItem.Name = "adelantosToolStripMenuItem";
            this.adelantosToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.adelantosToolStripMenuItem.Text = "Adelantos";
            this.adelantosToolStripMenuItem.Click += new System.EventHandler(this.adelantosToolStripMenuItem_Click);
            // 
            // cosechasToolStripMenuItem
            // 
            this.cosechasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sueloToolStripMenuItem});
            this.cosechasToolStripMenuItem.Name = "cosechasToolStripMenuItem";
            this.cosechasToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.cosechasToolStripMenuItem.Text = "Cosechas";
            // 
            // sueloToolStripMenuItem
            // 
            this.sueloToolStripMenuItem.Name = "sueloToolStripMenuItem";
            this.sueloToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sueloToolStripMenuItem.Text = "Suelo";
            this.sueloToolStripMenuItem.Click += new System.EventHandler(this.sueloToolStripMenuItem_Click);
            // 
            // cobroBancoToolStripMenuItem
            // 
            this.cobroBancoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cobrosToolStripMenuItem});
            this.cobroBancoToolStripMenuItem.Name = "cobroBancoToolStripMenuItem";
            this.cobroBancoToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cobroBancoToolStripMenuItem.Text = "Cobro Banco";
            // 
            // cobrosToolStripMenuItem
            // 
            this.cobrosToolStripMenuItem.Name = "cobrosToolStripMenuItem";
            this.cobrosToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.cobrosToolStripMenuItem.Text = "Cobros";
            this.cobrosToolStripMenuItem.Click += new System.EventHandler(this.cobrosToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarInventarioToolStripMenuItem});
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // importarInventarioToolStripMenuItem
            // 
            this.importarInventarioToolStripMenuItem.Name = "importarInventarioToolStripMenuItem";
            this.importarInventarioToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.importarInventarioToolStripMenuItem.Text = "Importar inventario";
            this.importarInventarioToolStripMenuItem.Click += new System.EventHandler(this.importarInventarioToolStripMenuItem_Click);
            // 
            // recursosHumanosToolStripMenuItem
            // 
            this.recursosHumanosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoCapacitacionToolStripMenuItem,
            this.capacitacionToolStripMenuItem});
            this.recursosHumanosToolStripMenuItem.Name = "recursosHumanosToolStripMenuItem";
            this.recursosHumanosToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.recursosHumanosToolStripMenuItem.Text = "Recursos Humanos";
            // 
            // tipoCapacitacionToolStripMenuItem
            // 
            this.tipoCapacitacionToolStripMenuItem.Name = "tipoCapacitacionToolStripMenuItem";
            this.tipoCapacitacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoCapacitacionToolStripMenuItem.Text = "Tipo Capacitacion";
            this.tipoCapacitacionToolStripMenuItem.Click += new System.EventHandler(this.tipoCapacitacionToolStripMenuItem_Click);
            // 
            // capacitacionToolStripMenuItem
            // 
            this.capacitacionToolStripMenuItem.Name = "capacitacionToolStripMenuItem";
            this.capacitacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.capacitacionToolStripMenuItem.Text = "Capacitacion";
            this.capacitacionToolStripMenuItem.Click += new System.EventHandler(this.capacitacionToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(843, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printPreviewToolStripButton.Text = "Print Preview";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "Help";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(843, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem pruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoActivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroCostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depreciaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matriculaEagleWingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosEndpointPruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anticiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adelantosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cosechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobroBancoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recursosHumanosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoCapacitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capacitacionToolStripMenuItem;
    }
}




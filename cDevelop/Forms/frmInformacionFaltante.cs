using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cDevelop.Forms
{
    public partial class frmInformacionFaltante : Form
    {
        private DataTable tabInformacion;
        public frmInformacionFaltante(DataTable tab)
        {
            InitializeComponent();
            tabInformacion = tab;

            dgv1.DataSource = tabInformacion;
        }
        public frmInformacionFaltante()
        {
            InitializeComponent();
        }

        private void frmInformacionFaltante_Load(object sender, EventArgs e)
        {
            dgv1.Columns[2].HeaderText = "Observación de la información faltante";
            dgv1.Columns[2].Width = 305;
            dgv1.Columns[0].Width = 210;
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.DeepSkyBlue;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                tabInformacion.DefaultView.RowFilter = null;
            }
            else
            {
                String str = txtBuscar.Text;
              
                tabInformacion.DefaultView.RowFilter = "Alumno" + " LIKE '%" + str + "%'";
              
            }
        }
    }
}

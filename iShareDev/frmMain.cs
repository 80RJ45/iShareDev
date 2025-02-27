using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cDevelop.Forms;

namespace iShareDev
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;
        dcLibrary.dcConnect Connect;
        dcLibrary.dcGeneral dcGral;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dcLibrary.dcLogin log = new dcLibrary.dcLogin("iShareDev");
            log.ShowDialog();

            if (log.isOK)
            {
                Connect = log.Connect;
                Connect.setUser();
                dcGral = new dcLibrary.dcGeneral();
            }
                
            else
                Close();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new cDevelop.Forms.frmProductoList(),this, Connect);
        }

        private void productovbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // dcGral.ShowList(new vbDevelop.frmProductoList(), this, Connect);
            dcGral.ShowList(new vbDevelop.frmProductoList2(), this, Connect);
        }

        private void fincaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmFincaList(), this, Connect);
        }

        private void tipoActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmTipoActivoCabList(), this, Connect);
        }

        private void centroCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmCentroCosto(), this, Connect);
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmActivoCabList(), this, Connect);
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void depreciaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmDepreciaCabList(), this, Connect);
        }

        private void alumnosEndpointPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dcGral.Sho(new cDevelop.Forms.frmCargarAlumnos(), this, Connect);             
            frmCargarAlumnos frm = new frmCargarAlumnos(Connect);
            frm.Show();
            
        }

        private void paymentQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // URL de la aplicación web ASP.NET
            string urlWeb = "http://localhost:49723";

            try
            {
                // Abre el navegador predeterminado con la URL
                Process.Start(new ProcessStartInfo("cmd", $"/c start {urlWeb}") { CreateNoWindow = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir la URL: {ex.Message}");
            }
        }

        private void adelantosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dcGral.ShowList(new vbDevelop.frmAdelantoList(), this, Connect);
        }

        private void sueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new cDevelop.Forms.Cosecha.frmSueloList(), this, Connect);
        }

        private void cobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dcGral.ShowList(new vbDevelop.frmCobroBancoCabList(), this, Connect);
        }
    }
}

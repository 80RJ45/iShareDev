using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cDevelop.Forms.Cosecha
{
    public partial class frmSueloList : dcLibrary.dcParentList
    {
        public frmSueloList()
        {
            InitializeComponent();
        }

        private void frmSueloList_Load(object sender, EventArgs e)
        {
            
        }
        public override void Init()
        {
            SQLGridParm = new SqlParameter();
            SQLGridParm.ParameterName = "@SueloID";
            SQLGridParm.Value = 0;

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = dcGral.getSQLCommand(Connect, "spSueloSelect", SQLGridParm);
            adp.InsertCommand = dcGral.getSQLCommand(Connect, "spSueloInsert");
            adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spSueloUpdate");
            adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spSueloDelete");

            Adaptador = adp;

            base.Init();
        }
        public override void Adicionar()
        {

            base.Adicionar();
        }
        public override void Modificar()
        {
            base.Modificar();
        }
    }
}

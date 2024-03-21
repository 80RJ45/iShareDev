using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cDevelop.Forms
{
    public partial class frmProductoList : dcLibrary.dcParentList
    {
        public frmProductoList()
        {
            InitializeComponent();
        }
        public override void Init()
        {
            SQLGridParm = new SqlParameter();
            SQLGridParm.ParameterName = "@ProductoID";        
            SQLGridParm.Value = 0;

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = dcGral.getSQLCommand(Connect, "spProductoSelect", SQLGridParm);
            adp.InsertCommand = dcGral.getSQLCommand(Connect, "spProductoInsert");
            adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spProductoUpdate");
            adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spProductoDelete");
            adp.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;
            Adaptador = adp;
            base.Init();
        }
        private void frmProductoList_Load(object sender, EventArgs e)
        {

        }
    }
}

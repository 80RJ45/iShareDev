﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cDevelop.Forms
{
    public partial class frmPruebaList : dcLibrary.dcParentList
    {
        public frmPruebaList()
        {
            InitializeComponent();
        }

        private void frmPruebaList_Load(object sender, EventArgs e)
        {
            CuentasPagar.frmProveedorList frm = new CuentasPagar.frmProveedorList();
        }
    }
}

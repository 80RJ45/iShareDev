using dcLibrary;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cDevelop.Forms
{
    public partial class frmImportarInventario : dcLibrary.dcDetail
    {
        dcLibrary.dcConnect connect;
        DataTable tabArticulos,tabValidaciones;
        SqlDataAdapter adpArticulos;
        int corregir;
        private string columnaSeleccionada = "Nombre"; // Valor predeterminado
        public frmImportarInventario(dcLibrary.dcConnect conn)
        {
            InitializeComponent();
            connect = conn;
            
            tabArticulos = new DataTable();
            progressBar1.Visible = false;
            panel1.Visible = false;lblArt.Visible = false;lblPorc.Visible = false;
        }

        private void frmImportarInventario_Load(object sender, EventArgs e)
        {
            tabArticulos.Columns.Add("Cantidad", type: typeof(int));
            tabArticulos.Columns.Add("Nombre", type: typeof(String));
            tabArticulos.Columns.Add("Modelo", type: typeof(String));
            tabArticulos.Columns.Add("Costo", type: typeof(float));
            tabArticulos.Columns.Add("Total", type: typeof(float));
            tabArticulos.Columns.Add("Ubicacion", type: typeof(String));
            tabArticulos.Columns.Add("Error", type: typeof(String));

            //tabArticulos.Columns["Error"].ReadOnly = true;
            
            dgvArticulos.DataSource = tabArticulos;
            dgvArticulos.Columns[0].Width = 60;dgvArticulos.Columns[1].Width = 220;
            dgvArticulos.Columns[2].Width = 75;dgvArticulos.Columns[3].Width = 60;
            dgvArticulos.Columns[4].Width = 60; dgvArticulos.Columns[5].Width = 60;
            dgvArticulos.Columns[6].Width = 500;

            dgvArticulos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(216, 230, 255);


            adpArticulos = new SqlDataAdapter();
            adpArticulos.InsertCommand = dcGral.getSQLCommand(connect,"spImportArticulos");


            tabValidaciones = new DataTable();
            tabValidaciones = dcGral.getDataTable("Select *from dbo.ValidacionesImportArticulo()", connect);


            //eventos para filtrar
            dgvArticulos.ColumnHeaderMouseClick += dgvArticulos_ColumnHeaderMouseClick;            

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (tabArticulos.Rows.Count == 0)
            {
                //Extraer las filas del portapapeles
                cargarFilas();
            }
            else
            {
                MessageBox.Show("Ya hay datos cargados");
            }

            lblCargados.Text = "Registros cargados: " + tabArticulos.Rows.Count.ToString();
            lblRechazados.Text = "Registros rechazados: " + corregir.ToString();
            progressBar1.Step = 10;
            progressBar1.PerformStep();

            //Actualizar lblCargados
            lblCargados.Text = "Registros cargados: " + tabArticulos.Rows.Count.ToString();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            /*
             TODO: Antes de salvar, validarInfo()
            si validar info == false, poner las filas con error al inicio,y marcarlas con color rojo
            si validar info == true, salvar en la base de datos
             */

            if (!validarInfo())
            {
                MessageBox.Show("Se han encontrado errores, revise la columna Error de los registros", "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Visible = false; panel1.Visible = false;

            }
            else
            {
                //salvar en la base de datos
                try
                {
                    adpArticulos.Update(tabArticulos);
                    tabArticulos.Clear();
                    lblCargados.Text = "Registros cargados: " + tabArticulos.Rows.Count.ToString();
                    lblRechazados.Text="Registros rechazados: 0";
                    progressBar1.Step = progressBar1.Maximum - progressBar1.Value;
                    progressBar1.PerformStep();
                    progressBar1.Visible = false; panel1.Visible = false;

                    MessageBox.Show("Se han importado los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }


        }

        private void cargarFilas()
        {
            try
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string clipboardText = Clipboard.GetText();
                    string[] rows = clipboardText.Split('\n');

                    if (rows.Length == 0) return;

                    // Limpiar el DataTable antes de cargar los nuevos datos
                    tabArticulos.Rows.Clear();

                    foreach (string row in rows)
                    {
                        if (!string.IsNullOrWhiteSpace(row))
                        {
                            string[] rowData = row.Split('\t');

                            if (rowData.Length == 6) // Caso normal (sin columna HP)
                            {
                                tabArticulos.Rows.Add(
                                    int.Parse(rowData[0]), // Cantidad
                                    rowData[1].Trim(),            // Nombre
                                    rowData[2].Trim(),            // Modelo
                                    float.Parse(rowData[3]), // Costo
                                    float.Parse(rowData[4]),  // Total
                                    rowData[5].Trim()             // Ubicacion
                                );
                            }
                            else if (rowData.Length == 7) // Caso con columna HP
                            {
                                tabArticulos.Rows.Add(
                                    int.Parse(rowData[0]),  // Cantidad
                                    rowData[1].Trim() + " " + rowData[3].Trim(),// Nombre y hp
                                    rowData[2].Trim(),             //modelo                                    
                                    float.Parse(rowData[4]), // Costo
                                    float.Parse(rowData[5]),  // Total
                                    rowData[6].Trim()                // Ubicacion
                                );
                            }
                            else
                            {
                                MessageBox.Show("El formato de los datos copiados no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos en el portapapeles o el formato no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cargar datos: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!validarInfo())
            {
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Visible = false; panel1.Visible = false;
                MessageBox.Show("Se han encontrado inconsistencias, revise la columna Error de los registros", "Inconsistencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Visible = false; panel1.Visible = false;
                MessageBox.Show("Se han cargado los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool validarInfo()
        {
            
            //Setear y mostrar ProgressBar
            progressBar1.Value = 0;
            progressBar1.Maximum = tabArticulos.Rows.Count+5;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Visible = true; panel1.Visible = true;
            lblArt.Visible = true;lblPorc.Visible = true;
            panel1.Refresh();

            //variables de control
            float porcentaje = 0;
            bool b = true;
            corregir = 0;
            HashSet<string> articulosUnicos = new HashSet<string>(); // Para almacenar combinaciones únicas de Código y Ubicación
            HashSet<string> modelos = new HashSet<string>(); // Para almacenar los modelos
            HashSet<string> modeloNombre = new HashSet<string>(); // Para almacenar los nombres de los modelos
           
            
            //recorrer filas de la tabla
            foreach (DataRow fila in tabArticulos.Rows)
            {
                //limpiar columna Error de la tabla
                fila["Error"] = "";

                lblArt.Text = "Art. " + fila["Nombre"].ToString();

                // verificar que los campos obligatorios estén completos
                    //verificar que tenga nombre
                    if (fila["Nombre"].ToString().Length == 0 && bool.Parse(tabValidaciones.Rows[0]["Activo"].ToString()) == true)
                    {
                    fila["Error"] = fila["Error"].ToString() + tabValidaciones.Rows[0]["Mensaje"].ToString();
                        b = false;
                        corregir++;
                        //continue;
                    }

                    //verificar que tenga ubicación
                    if (fila["Ubicacion"].ToString().Length == 0 && bool.Parse(tabValidaciones.Rows[1]["Activo"].ToString()) == true)
                    {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[1]["Mensaje"].ToString();
                        b = false;
                        corregir++;
                        //continue;
                    }

                        //ubicación valida
                        bool a = !(fila["Ubicacion"].ToString().Equals("Bodega"));
                        bool d = !(fila["Ubicacion"].ToString().Equals("Sala de venta"));
                        bool c = bool.Parse(tabValidaciones.Rows[2]["Activo"].ToString());
                        if (a && d && c)
                        {
                            fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[2]["Mensaje"].ToString();
                            corregir++;
                            b = false;
                            //continue;
                        }
                        
                    //verificar que tenga modelo
                    if (fila["Modelo"].ToString().Length == 0 && bool.Parse(tabValidaciones.Rows[3]["Activo"].ToString()) == true)
                    {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[3]["Mensaje"].ToString();
                        b = false;
                        corregir++;
                        //continue;
                    }

                    //verificar que tenga costo
                    if ((fila["Costo"].ToString().Length == 0 || !float.TryParse(fila["Costo"].ToString(), out float res)) && bool.Parse(tabValidaciones.Rows[4]["Activo"].ToString()) == true)
                    {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[4]["Mensaje"].ToString();
                        b = false;
                        corregir++;
                        //continue;
                    }

                
                string claveUnica = fila["Modelo"].ToString().Trim() + "-" + fila["Ubicacion"].ToString().Trim();
                string modnombre = fila["Modelo"].ToString().Trim() + "-" + fila["Nombre"].ToString().Trim();

                //si el modelo ya existe
                if (modelos.Contains(fila["Modelo"].ToString().Trim()))
                {
                    //no hay códigos repetidos en el mismo sitio entre estos registros
                    if (articulosUnicos.Contains(claveUnica) && bool.Parse(tabValidaciones.Rows[5]["Activo"].ToString()) == true)
                    {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[5]["Mensaje"].ToString() + "(" + claveUnica + ")";
                        corregir++;
                        b = false; //continue;
                    }
                    //este mismo modelo no está usado por otro nombre
                    if (modeloNombre.Contains(modnombre) && bool.Parse(tabValidaciones.Rows[6]["Activo"].ToString()) == true)
                    {
                        fila["Error"] = fila["Error"].ToString() +"      " +   tabValidaciones.Rows[6]["Mensaje"].ToString()+" (" + modnombre + ")";
                        b = false;
                        corregir++; //continue;
                    }
                }
                
                
                
                //no hay nombres repetidos entre estos y los de la base
                    DataTable table = dcGral.getDataTable(
                        "select *from articuloImport where nombre = '" + fila["Nombre"].ToString().Trim() + "'" +
                        "and ubicacion = '" + fila["Ubicacion"].ToString().Trim() + "'", connect);
                
                    if(table.Rows.Count > 0 && bool.Parse(tabValidaciones.Rows[7]["Activo"].ToString()) == true) {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[7]["Mensaje"].ToString();
                        b = false;
                        corregir++; //continue;
                    }


                table.Clear();
                //no hay modelos repetidos entre estos y los de la base
                    string consulta = "select *from articuloImport where codigo = '" + fila["Modelo"].ToString().Trim() + "'" +
                        "and ubicacion = '" + fila["Ubicacion"].ToString().Trim() + "'";

                    table = dcGral.getDataTable(consulta, connect);
                
                    if(table.Rows.Count > 0 && bool.Parse(tabValidaciones.Rows[8]["Activo"].ToString()) == true) {
                        fila["Error"] = fila["Error"].ToString() +"      " +  tabValidaciones.Rows[8]["Mensaje"] +": "+ table.Rows[0]["Nombre"].ToString() + " (" + table.Rows[0]["Codigo"].ToString() + ")";
                        b = false;
                        corregir++; //continue;
                    }

                articulosUnicos.Add(claveUnica);
                modelos.Add(fila["Modelo"].ToString().Trim());
                modeloNombre.Add(modnombre);


                progressBar1.PerformStep();
                porcentaje = (100 * progressBar1.Value) / progressBar1.Maximum;
                lblPorc.Text = "Porcentaje: " + porcentaje.ToString() + "%";
                panel1.Refresh();lblArt.Refresh();lblPorc.Refresh();

                fila["Error"] = fila["Error"].ToString().Trim();
            }

            dgvArticulos.Refresh();
            lblRechazados.Text = "Registros rechazados: " + corregir.ToString();
            return b;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //filtro de búsquedas
            if (tabArticulos.Rows.Count > 0)
            {
                string filtro = txtBuscar.Text.Trim();
                if (string.IsNullOrEmpty(filtro))
                {
                    (dgvArticulos.DataSource as DataTable).DefaultView.RowFilter = ""; // Mostrar todo si no hay texto
                }
                else
                {
                    // Filtrar la columna seleccionada con LIKE para texto y comparación para números
                    if (columnaSeleccionada == "Cantidad" || columnaSeleccionada == "Costo" || columnaSeleccionada == "Total")
                    {
                        // Buscar valores numéricos
                        (dgvArticulos.DataSource as DataTable).DefaultView.RowFilter =
                            $"{columnaSeleccionada} = {filtro}";
                    }
                    else
                    {
                        // Buscar valores de texto
                        (dgvArticulos.DataSource as DataTable).DefaultView.RowFilter =
                            $"{columnaSeleccionada} LIKE '%{filtro}%'";
                    }
                }
            }
        }

        private void dgvArticulos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            columnaSeleccionada = dgvArticulos.Columns[e.ColumnIndex].Name;
        }

        private void dgvArticulos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblCargados.Text = "Registros cargados: " + tabArticulos.Rows.Count.ToString();
        }
    }
}

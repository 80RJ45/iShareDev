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
        DataTable tabArticulos;
        SqlDataAdapter adpArticulos;

        public frmImportarInventario(dcLibrary.dcConnect conn)
        {
            InitializeComponent();
            connect = conn;
            
            tabArticulos = new DataTable();
            progressBar1.Visible = false;
            panel1.Visible = false;
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

            dgvArticulos.DataSource = tabArticulos;


            adpArticulos = new SqlDataAdapter();
            adpArticulos.InsertCommand = dcGral.getSQLCommand(connect,"spImportArticulos");
            //adpArticulos.InsertCommand.CommandType = CommandType.StoredProcedure;
            //adpArticulos.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int,4,"Cantidad");
            //adpArticulos.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar,100, "Nombre");
            //adpArticulos.InsertCommand.Parameters.Add("@Modelo", SqlDbType.VarChar,20,"Modelo");
            //adpArticulos.InsertCommand.Parameters.Add("@Costo", SqlDbType.Float, 8,"Costo");
            //adpArticulos.InsertCommand.Parameters.Add("@Ubicacion", SqlDbType.VarChar,20,"Ubicacion");
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
                    progressBar1.Step = 10;
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
                            else if (rowData.Length == 6) // Caso con columna HP
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
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validarInfo()
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = tabArticulos.Rows.Count+10;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Visible = true; panel1.Visible = true;
            lblArt.Visible = true;lblPorc.Visible = true;
            float porcentaje = 0;

            bool b = true;
            int corregir = 0;
            HashSet<string> articulosUnicos = new HashSet<string>(); // Para almacenar combinaciones únicas de Código y Ubicación
            HashSet<string> modelos = new HashSet<string>(); // Para almacenar los modelos
            HashSet<string> modeloNombre = new HashSet<string>(); // Para almacenar los nombres de los modelos
            foreach (DataRow fila in tabArticulos.Rows)
            {
                lblArt.Text = "Art. " + fila["Nombre"].ToString();
                // verificar que los campos obligatorios estén completos
                if (fila["Nombre"].ToString().Length == 0 || fila["Modelo"].ToString().Length == 0 || fila["Costo"].ToString().Length == 0)
                {
                    fila["Error"] = "Faltan datos obligatorios";  
                    b = false;
                    corregir++;
                    continue;
                }

                
                string claveUnica = fila["Modelo"].ToString().Trim() + "-" + fila["Ubicacion"].ToString().Trim();
                string modnombre = fila["Modelo"].ToString().Trim() + "-" + fila["Nombre"].ToString().Trim();

                //si el modelo ya existe
                if (modelos.Contains(fila["Modelo"].ToString().Trim()))
                {
                    //no hay códigos repetidos en el mismo sitio entre estos registros
                    if (articulosUnicos.Contains(claveUnica))
                    {
                        fila["Error"] = "Artículo duplicado en la misma ubicación";
                        corregir++;
                        b = false; continue;
                    }
                    //este mismo modelo no está usado por otro nombre
                    if (modeloNombre.Contains(modnombre))
                    {
                        fila["Error"] = "Modelo ya usado por otro nombre (" + modnombre + ")";
                        b = false;
                        corregir++; continue;
                    }
                }
                
                
                
                //no hay nombres repetidos entre estos y los de la base
                DataTable table = dcGral.getDataTable(
                    "select *from articuloImport where nombre = '" + fila["Nombre"].ToString().Trim() + "'" +
                    "and ubicacion = '" + fila["Ubicacion"].ToString().Trim() + "'", connect);
                
                if(table.Rows.Count > 0) { 
                    fila["Error"] = "Nombre ya existe en la base de datos";
                    b = false;
                    corregir++; continue;
                }
                table.Clear();
                //no hay modelos repetidos entre estos y los de la base
                string consulta = "select *from articuloImport where codigo = '" + fila["Modelo"].ToString().Trim() + "'" +
                    "and ubicacion = '" + fila["Ubicacion"].ToString().Trim() + "'";

                table = dcGral.getDataTable(consulta, connect);
                
                if(table.Rows.Count > 0) { 
                    fila["Error"] = "Este modelo ya existe en la base de datos " + table.Rows[0]["Nombre"].ToString() + " (" + table.Rows[0]["Codigo"].ToString() + ")";
                    b = false;
                    corregir++; continue;
                }

                articulosUnicos.Add(claveUnica);
                modelos.Add(fila["Modelo"].ToString().Trim());
                modeloNombre.Add(modnombre);


                progressBar1.PerformStep();
                porcentaje = (100 * progressBar1.Value) / progressBar1.Maximum;
                lblPorc.Text = "Porcentaje: " + porcentaje.ToString() + "%";
            }

            dgvArticulos.Refresh();
            lblRechazados.Text = "Registros rechazados: " + corregir.ToString();
            return b;
        }

        private void dgvArticulos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblCargados.Text = "Registros cargados: " + tabArticulos.Rows.Count.ToString();
        }
    }
}

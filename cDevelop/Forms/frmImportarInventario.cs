using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cDevelop.Forms
{
    public partial class frmImportarInventario : dcLibrary.dcDetail
    {
        dcLibrary.dcConnect connect;
        DataTable tabArticulos;
        public frmImportarInventario(dcLibrary.dcConnect conn)
        {
            InitializeComponent();
            connect = conn;
            //copiar estructura
            //tabArticulos = dcGral.getDataTable("select *from ArticuloImport where nombre is null and precio = 0", connect);
            tabArticulos = new DataTable();
        }

        private void frmImportarInventario_Load(object sender, EventArgs e)
        {
            tabArticulos.Columns.Add("Cantidad", type: typeof(int));
            tabArticulos.Columns.Add("Nombre", type: typeof(String));
            tabArticulos.Columns.Add("Modelo", type: typeof(String));
            tabArticulos.Columns.Add("Costo", type: typeof(float));
            tabArticulos.Columns.Add("Total", type: typeof(float));
            //tabArticulos.Columns.Add("Ubicacion", type: typeof(String));

            dgvArticulos.DataSource = tabArticulos;
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

            //Validarlas
            if (!validarInfo())
            {
                MessageBox.Show("Faltan datos o hay datos incorrectos");
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
             * */
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

                            if (rowData.Length == 5) // Caso normal (sin columna HP)
                            {
                                tabArticulos.Rows.Add(
                                    int.Parse(rowData[0]), // Cantidad
                                    rowData[1],            // Nombre
                                    rowData[2],            // Modelo
                                    float.Parse(rowData[3]), // Costo
                                    float.Parse(rowData[4])  // Total
                                );
                            }
                            else if (rowData.Length == 6) // Caso con columna HP
                            {
                                tabArticulos.Rows.Add(
                                    int.Parse(rowData[0]),  // Cantidad
                                    rowData[1] + " " + rowData[3],// Nombre y hp
                                    rowData[2],             //modelo                                    
                                    float.Parse(rowData[4]), // Costo
                                    float.Parse(rowData[5])  // Total
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
            // verificar que los campos obligatorios estén completos
            //no hay códigos repetidos en el mismo sitio
            //No hay codigos en distintos sitios con nombres diferentes
            //A la fila, agregar observación de que tiene malo 
            return true;
        }

    }
}

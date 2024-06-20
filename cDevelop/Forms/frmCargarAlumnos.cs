using cDevelop.Controllers;
using cDevelop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cDevelop.Forms
{
    public partial class frmCargarAlumnos : dcLibrary.dcDetail
    {
        private string parametros;
        private AlumnosController controller;
        private List<Alumno> alumnos;
        private DataTable tabAlumnos,tabClienteImport,tabZona,tabFaltante;        
        dcLibrary.dcConnect Connect;
        public frmCargarAlumnos(dcLibrary.dcConnect cnx)
        {
            InitializeComponent();

            Connect = cnx;
            controller = new AlumnosController(Connect);
            dsGral.Tables.Add(tabAlumnos = new DataTable());
            dsGral.Tables[dsGral.Tables.Count - 1].TableName = "tabAlumnos";

            dsGral.Tables["TabAlumnos"].Columns.Add("Identidad");
            dsGral.Tables["TabAlumnos"].Columns.Add("Nombre");
            dsGral.Tables["TabAlumnos"].Columns.Add("Transporte");
            dsGral.Tables["TabAlumnos"].Columns.Add("Grado");
            dsGral.Tables["TabAlumnos"].Columns.Add("Ano");
            dsGral.Tables["TabAlumnos"].Columns.Add("cantMeses");
            dsGral.Tables["TabAlumnos"].Columns.Add("SitioID");
            dsGral.Tables["TabAlumnos"].Columns.Add("FechaModificacion");
            dsGral.Tables["TabAlumnos"].Columns.Add("HorarioTransporte");
            dsGral.Tables["TabAlumnos"].Columns.Add("Direccion");
            dsGral.Tables["TabAlumnos"].Columns.Add("TransporteColonia");

            //responsables
            dsGral.Tables["TabAlumnos"].Columns.Add("nombreMadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("identidadMadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("celularMadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("emailMadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("nombrePadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("identidadPadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("celularPadre");
            dsGral.Tables["TabAlumnos"].Columns.Add("emailPadre");

            tabClienteImport = new DataTable();
            tabZona = new DataTable();

            tabFaltante = new DataTable();
            tabFaltante.Columns.Add("Alumno");
            tabFaltante.Columns.Add("Identidad");
            tabFaltante.Columns.Add("Observacion");            
        }
        
        private void frmCargarAlumnos_Load(object sender, EventArgs e)
        {            
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void getAlumnos()
        {
            int max,importados;
            alumnos = await
                controller.GetAllAlumnos();

            if (alumnos != null)
            {
                importados = 0;
                lblIniciar.Text = "Importando: "; lblIniciar.Refresh();
                lblNombre.Visible = true;
                progressBar1.Minimum = 1;
                max = alumnos.ToArray().Length;
                progressBar1.Maximum = max;
                progressBar1.Step = 1;
                Err.Clean();
                foreach (var alumno in alumnos)
                {
                    lblIniciar.Text = "Importando: " + importados.ToString();
                    lblNombre.Text = alumno.firstName;
                    lblPorcentaje.Text = ((100 * progressBar1.Value) / max).ToString() + "%";
                    lblPorcentaje.Refresh(); lblNombre.Refresh();lblIniciar.Refresh();
                    progressBar1.PerformStep();
                    if (alumno.status == "Enrolled")
                    {
                        tabClienteImport = dcGral.getDataTable("exec spClienteImportSelect '" + alumno.ssn + "' ,'" + alumno.fechaModificacion.Year + "'", Connect);

                        if (tabClienteImport.Rows.Count == 0)
                        {
                            DataRow row = dsGral.Tables["TabAlumnos"].NewRow();
                            row["Identidad"] = alumno.ssn;
                            row["Nombre"] = alumno.firstName + " " + alumno.lastName;
                            if (alumno.transporteColonia.Length > 1)//and alumno.horarioTransporte != ""
                                row["Transporte"] = 1;
                            else
                                row["Transporte"] = 0;
                            row["Grado"] = alumno.gradeLevel[0] == '0' ? alumno.gradeLevel.Substring(1) : alumno.gradeLevel;
                            row["Ano"] = alumno.fechaModificacion.Year;
                            row["cantMeses"] = alumno.plandePagos.Split('M')[0].Length > 0 ? alumno.plandePagos.Split('M')[0] : "10";
                            row["SitioID"] = alumno.schoolCode == "EWH" ? 1 : 2;
                            row["FechaModificacion"] = alumno.fechaModificacion.Year + "-" + alumno.fechaModificacion.Month + "-" + alumno.fechaModificacion.Day;
                            row["HorarioTransporte"] = alumno.planTransporte;
                            row["Direccion"] = alumno.address1 + " / " + alumno.address2;
                            row["TransporteColonia"] = alumno.transporteColonia;
                                                        
                            //verificar que la colonia existe
                            if (int.Parse(row["Transporte"].ToString()) == 1)
                            {
                                tabZona = dcGral.getDataTable("exec spVZonaSelect '" + alumno.transporteColonia + "'", Connect);
                                if (tabZona.Rows.Count == 0)
                                {
                                    DataRow info = tabFaltante.NewRow();
                                    info["Alumno"] = row["Nombre"];
                                    info["Identidad"] = row["Identidad"];
                                    info["Observacion"] = "La colonia ingresada no existe";
                                    tabFaltante.Rows.Add(info);
                                    continue;
                                }
                            }
                            //Responsables
                            row["nombreMadre"] = alumno.nombreMadre;
                            row["identidadMadre"] = alumno.identidadMadre;
                            row["celularMadre"] = alumno.celularMadre;
                            row["emailMadre"] = alumno.emailMadre;
                            row["nombrePadre"] = alumno.nombrePadre;
                            row["identidadPadre"] = alumno.identidadPadre;
                            row["celularPadre"] = alumno.celularPadre;
                            row["emailPadre"] = alumno.emailPadre;


                            int result = validarAlumno(row);

                            if (result ==1)
                            {
                                DataRow info = tabFaltante.NewRow();
                                info["Alumno"] = row["Nombre"];
                                info["Identidad"] = row["Identidad"];
                                info["Observacion"] = "Información sobre el grado y la cantidad de meses";
                                continue;
                            }
                            if (result == 2)
                            {
                                DataRow info = tabFaltante.NewRow();
                                info["Alumno"] = row["Nombre"];
                                info["Identidad"] = row["Identidad"];
                                info["Observacion"] = "Ningun responsable registrado (con nombre e identidad)";
                                tabFaltante.Rows.Add(info);
                                continue;
                            }
                            if(result == 3)
                            {
                                DataRow info = tabFaltante.NewRow();
                                info["Alumno"] = row["Nombre"];
                                info["Identidad"] = row["Identidad"];
                                info["Observacion"] = "Ningún numero de celular de responsable";
                                tabFaltante.Rows.Add(info);
                                continue;
                            }
                            if (!validarTransporte(row))
                            {
                                DataRow info = tabFaltante.NewRow();
                                info["Alumno"] = row["Nombre"];
                                info["Identidad"] = row["Identidad"];
                                info["Observacion"] = "Error en los datos ingresados para transporte";
                                tabFaltante.Rows.Add(info);
                                continue;
                            }

                            dsGral.Tables["TabAlumnos"].Rows.Add(row);

                            //ya que el cliente no existe mandar a llamar el procedimiento para registrarlo

                            parametros = string.Concat("'", alumno.ssn, "','", row["Nombre"], "',", row["Transporte"], ",'", row["TransporteColonia"], "','",
                                row["Grado"], "',", row["Ano"], ",", row["cantMeses"], ",", 0, ",", 0, ",", 1, ",", row["SitioID"], ",'", row["fechaModificacion"], "','",
                                row["HorarioTransporte"], "','", row["NombreMadre"], "','", row["identidadMadre"], "','", row["celularMadre"], "','", row["emailMadre"], "','",
                                row["NombrePadre"], "','", row["identidadPadre"], "','", row["celularPadre"], "','", row["emailPadre"], "'");
                            dcGral.executeProcedure("exec spRegistroAlumno " + parametros, Connect);
                            importados++;
                        }
                    }
                }

                //llamar al frm y enviarle el dataTable
                frmInformacionFaltante frm = new frmInformacionFaltante(tabFaltante);
                frm.ShowDialog();
                Close();
            }
            else
                MessageBox.Show(this, "No se pudo obtener la petición", "Error", MessageBoxButtons.OK);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {            
            lblIniciar.Text = "Iniciando.....";
            btnCancelar.Enabled = false;
            getAlumnos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int validarAlumno(DataRow row)
        {
            if (row["Identidad"].Equals("") || row["Nombre"].Equals("") ||row["Grado"].Equals("") || row["cantMeses"].Equals("") )
                return 1;
            //responsables
            if ((row["nombreMadre"].Equals("") || row["identidadMadre"].Equals("")) && (row["nombrePadre"].Equals("") || row["identidadPadre"].Equals("")))
                return 2; //al menos los 3 datos de uno de los padres    
            if (row["celularMadre"].Equals("") && row["celularPadre"].Equals(""))
                return 3;
            return 0;
        }

        private bool validarTransporte(DataRow row)
        {
            if (row["Transporte"].ToString() == "1")
            {
                if (row["HorarioTransporte"].ToString() != "AM" && row["HorarioTransporte"].ToString() != "PM" && row["HorarioTransporte"].ToString() != "AM/PM")
                    return false;                      
            }
            return true;
        }
    }
}

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
        private DataTable tabAlumnos,tabClienteImport,tabZona;
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
        }
        
        private void frmCargarAlumnos_Load(object sender, EventArgs e)
        {
            getAlumnos();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;            
            dataGridView1.Refresh();
            dataGridView1.DataSource = dsGral.Tables["tabAlumnos"];
        }

        private async void getAlumnos()
        {
            alumnos = await
                controller.GetAllAlumnos();

            if (alumnos != null)
            {
                Err.Clean();
                foreach (var alumno in alumnos)
                {
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
                            if(int.Parse(row["Transporte"].ToString()) == 1)
                            {
                                tabZona = dcGral.getDataTable("exec spVZonaSelect '" + alumno.transporteColonia + "'", Connect);
                                if (tabZona.Rows.Count == 0)
                                {
                                    Err.AddError("Error, la colonia de: " + row["Nombre"] + " No existe", 0);
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


                            if (!validarAlumno(row))
                            {
                                Err.AddError("Error, falta información del alumno: " + row["Nombre"], 0);
                                continue;
                            }
                            if (!validarTransporte(row))
                            {
                                Err.AddError("Error en los datos de transporte de: " + row["Nombre"], 0);
                                continue;
                            }

                            dsGral.Tables["TabAlumnos"].Rows.Add(row);

                            //ya que el cliente no existe mandar a llamar el procedimiento para registrarlo


                            parametros = string.Concat("'", alumno.ssn, "','", row["Nombre"], "',", row["Transporte"], ",'", row["TransporteColonia"], "','",
                                row["Grado"], "',", row["Ano"], ",", row["cantMeses"], ",", 0, ",", 0, ",", 1, ",", row["SitioID"], ",'", row["fechaModificacion"], "','",
                                row["HorarioTransporte"], "','", row["NombreMadre"], "','", row["identidadMadre"], "','", row["celularMadre"], "','", row["emailMadre"], "','",
                                row["NombrePadre"], "','", row["identidadPadre"], "','", row["celularPadre"], "','", row["emailPadre"], "'");
                            dcGral.executeProcedure("exec spRegistroAlumno " + parametros, Connect);
                        }
                    }
                }
                dataGridView1.DataSource = dsGral.Tables["tabAlumno"];
                //mensaje de errores
                Err.ShowDialog();
            }
            else
                MessageBox.Show(this, "No se pudo obtener la petición", "Error", MessageBoxButtons.OK);
        }

        private bool validarAlumno(DataRow row)
        {
            if (row["Identidad"].Equals("") || row["Nombre"].Equals("") ||row["Grado"].Equals("") || row["cantMeses"].Equals("") )
                return false;
            //responsables
            if ((row["nombreMadre"].Equals("") || row["identidadMadre"].Equals("") || row["celularMadre"].Equals("")) && (row["nombrePadre"].Equals("") || row["identidadPadre"].Equals("") || row["celularPadre"].Equals("")))
                return false; //al menos los 4 datos de uno de los padres            
            return true;
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

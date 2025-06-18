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
        private DataTable tabAlumnos,tabClienteImport,tabPerAcad,tabZona,tabFaltante;   
        public int importados { get; set; }
        int extrangero,iniPerActual,finPerActual;
        string codPerActual;

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
            dsGral.Tables["TabAlumnos"].Columns.Add("Sexo");
            dsGral.Tables["TabAlumnos"].Columns.Add("Ciudadania");
            dsGral.Tables["TabAlumnos"].Columns.Add("Transporte");
            dsGral.Tables["TabAlumnos"].Columns.Add("Grado");
            dsGral.Tables["TabAlumnos"].Columns.Add("Ano");
            dsGral.Tables["TabAlumnos"].Columns.Add("cantMeses");
            dsGral.Tables["TabAlumnos"].Columns.Add("planPagos");
            dsGral.Tables["TabAlumnos"].Columns.Add("porcentajeBeca");
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


            tabPerAcad = new DataTable();
            tabPerAcad = dcGral.getDataTable("exec spPeriodoAcademicoSelect 0,'A'", Connect);
            if(tabPerAcad.Rows.Count > 0)
            {
                iniPerActual = 0; //para pruebas
                codPerActual = tabPerAcad.Rows[0]["fmtdCodigo"].ToString();                
                iniPerActual = int.Parse(tabPerAcad.Rows[0]["iniPer"].ToString());                
                finPerActual = int.Parse(tabPerAcad.Rows[0]["finPer"].ToString());                              
            }
        }
        //2025 - 2026
        
        private void frmCargarAlumnos_Load(object sender, EventArgs e)
        {            
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void getAlumnos()
        {            
            int max;
            alumnos = await
                controller.GetAllAlumnos();

            if (alumnos != null)
            {
                //inicializaciones
                importados = 0;
                lblIniciar.Text = "Importando: "; lblIniciar.Refresh();
                lblNombre.Visible = true;
                progressBar1.Minimum = 1;
                max = alumnos.ToArray().Length;
                progressBar1.Maximum = max;
                progressBar1.Step = 1;


                foreach (var alumno in alumnos)
                {
                
                    //mostrando proceso en la ventana
                    lblIniciar.Text = "Importando: " + importados.ToString();
                    lblNombre.Text = alumno.firstName;
                    lblPorcentaje.Text = ((100 * progressBar1.Value) / max).ToString() + "%";
                    lblPorcentaje.Refresh(); lblNombre.Refresh();lblIniciar.Refresh();
                    progressBar1.PerformStep();


                    int iniDefault = int.Parse(alumno.defaultYear.Substring(0, 4));
                    if (((iniDefault < iniPerActual) && alumno.nextStatus == "Enrolled") || ((alumno.defaultYear.Equals(codPerActual)) && alumno.status == "Enrolled"))
                    {
                        //Verificar que el alumno no ha sido importado este año
                        tabClienteImport = dcGral.getDataTable("exec spClienteImportSelect '" + alumno.ssn + "' ,'" + alumno.fechaModificacion.Year + "'", Connect);

                        if (tabClienteImport.Rows.Count == 0 || (tabClienteImport.Rows[0]["Transporte"].ToString().ToLower() == "false" && alumno.planTransporte.ToString().Length>1 && alumno.transporteColonia.ToString().Length > 2) )
                        {
                            DataRow row = dsGral.Tables["TabAlumnos"].NewRow();
                            row["Identidad"] = alumno.ssn;
                            row["Nombre"] = alumno.firstName + " " + alumno.lastName;
                            row["Sexo"] = alumno.gender == "Male" ? "M" : "F";
                            row["Ciudadania"] = alumno.citizenship;
                            if (alumno.transporteColonia.Length > 5 && alumno.planTransporte.Length >1)
                                row["Transporte"] = 1;
                            else
                                row["Transporte"] = 0;


                            //Definir que grado se va a usar
                            if (alumno.defaultYear.Equals(codPerActual)){
                                //usar gradeLevel
                                row["Grado"] = alumno.gradeLevel[0] == '0' ? alumno.gradeLevel.Substring(1) : alumno.gradeLevel;
                            }
                            else
                            {
                                //tomar el grado Siguiente
                                row["Grado"] = alumno.nextGradeLevel[0] == '0' ? alumno.nextGradeLevel.Substring(1) : alumno.nextGradeLevel;
                            }
                            //row["Grado"] = alumno.nextGradeLevel;


                            row["Ano"] = alumno.fechaModificacion.Year;
                            row["cantMeses"] = 11;
                            row["planPagos"] = alumno.plandePagos.Split('M')[0].Length > 0 ? alumno.plandePagos.Split('M')[0] : "10";
                            float descuento = alumno.descuento.ToString() == "" || alumno.descuento.ToString() == " " ? 0 : float.Parse(alumno.descuento.ToString());
                            row["porcentajeBeca"] = descuento / 100;
                            row["FechaModificacion"] = alumno.fechaModificacion.Year + "-" + alumno.fechaModificacion.Month + "-" + alumno.fechaModificacion.Day;
                            row["HorarioTransporte"] = alumno.planTransporte;
                            row["Direccion"] = alumno.address1 + " / " + alumno.address2;
                            row["TransporteColonia"] = alumno.transporteColonia;
                            

                            if (alumno.schoolCode.ToString().ToUpper() == "EWH" || alumno.schoolCode.ToString().ToUpper() == "EWR")
                                row["SitioID"] = alumno.schoolCode == "EWH" ? 1 : 2;
                            else
                            {
                                DataRow info = tabFaltante.NewRow();
                                info["Alumno"] = row["Nombre"];
                                info["Identidad"] = row["Identidad"];
                                info["Observacion"] = "Sitio " + alumno.schoolCode+ " no existe";
                                tabFaltante.Rows.Add(info);
                                continue;
                            }
                            //verificar que la colonia existe
                            if (int.Parse(row["Transporte"].ToString()) == 1 || row["Transporte"].ToString() == "1")
                            {
                                tabZona = dcGral.getDataTable("exec spvZonaPrecioSelect '" + alumno.transporteColonia + "'", Connect);
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


                            if (!validarAlumno(row))
                                continue;
                            if (!validarTransporte(row))
                                continue;
                            dsGral.Tables["TabAlumnos"].Rows.Add(row);

                            parametros = string.Concat(
                                "'", alumno.ssn,
                                "','",row["Nombre"], 
                                "','",row["Sexo"],
                                "','",row["Ciudadania"] ,
                                "',",row["Transporte"],
                                ",'",row["TransporteColonia"],
                                "','",row["Grado"], "',",
                                      row["Ano"], ",", 
                                      row["cantMeses"], "," //para cantidad de avisos
                                , row["planPagos"], //cantidadPagos
                                ",",row["porcentajeBeca"],
                                ",",0, //mora
                                ",",4, //Dia de corte constante =4
                                ",",row["SitioID"], 
                                ",'",row["fechaModificacion"],
                                "','",row["HorarioTransporte"], 
                                "','",row["NombreMadre"], 
                                "','",row["identidadMadre"], 
                                "','",row["celularMadre"], 
                                "','",row["emailMadre"], 
                                "','",row["NombrePadre"], 
                                "','",row["identidadPadre"], 
                                "','",row["celularPadre"], 
                                "','",row["emailPadre"], "'");
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


        //Validar datos importantes del alumno
        private bool validarAlumno(DataRow row)
        {
            bool valida = true;


            if (!validarGrado(row["Grado"].ToString()))
            {
                DataRow info = tabFaltante.NewRow();
                info["Alumno"] = row["Nombre"];
                info["Identidad"] = row["Identidad"];
                info["Observacion"] = "No existe el grado " + row["Grado"].ToString();
                tabFaltante.Rows.Add(info);
                valida = false;
            }
                

            //validar padre
            int responsables = 2;
            String idPadre = row["identidadPadre"].ToString();
            if (row["nombrePadre"].ToString().Length < 10 || !long.TryParse(idPadre, out long res) || res.ToString().Length < 11)
                responsables--;//no hay datos suficientes para el papá

            //validar madre
            idPadre = row["identidadMadre"].ToString();
            if (row["nombreMadre"].ToString().Length < 10 || !long.TryParse(idPadre, out long res2) || res2.ToString().Length < 11)
                responsables--;


            //responsables
            if (responsables==0)
            {
                DataRow info = tabFaltante.NewRow();
                info["Alumno"] = row["Nombre"];
                info["Identidad"] = row["Identidad"];
                info["Observacion"] = "Nombre e Identidad de al menos 1 responsable"; //al menos los 2 datos de uno de los padres  
                tabFaltante.Rows.Add(info);
                valida = false;
            }
            
            if (!long.TryParse(row["Identidad"].ToString(), out long a) || (row["Ciudadania"].ToString().Length==0 && row["Identidad"].ToString().Length<13))
            {                
                DataRow info = tabFaltante.NewRow();                
                info["Alumno"] = row["Nombre"];
                info["Identidad"] = row["Identidad"];
                info["Observacion"] = "Error en el formato del número de identidad del alumno";
                tabFaltante.Rows.Add(info);                
                valida = false;
            }
            if (row["Nombre"].ToString().Length < 10)
            {
                DataRow info = tabFaltante.NewRow();
                info["Alumno"] = row["Nombre"];
                info["Identidad"] = row["Identidad"];
                info["Observacion"] = "Nombre del alumno";
                tabFaltante.Rows.Add(info);
                valida = false;
            }
            return valida;
        }

        private bool validarTransporte(DataRow row)
        {
            bool valida = true;
            if (row["Transporte"].ToString() == "1")
            {
                if (row["HorarioTransporte"].ToString() != "AM" && row["HorarioTransporte"].ToString() != "PM" && row["HorarioTransporte"].ToString().ToLower() != "completo")
                {
                    DataRow info = tabFaltante.NewRow();
                    info["Alumno"] = row["Nombre"];
                    info["Identidad"] = row["Identidad"];
                    info["Observacion"] = "Error en el formato de horario de transporte especificado " + row["horarioTransporte"];
                    tabFaltante.Rows.Add(info);
                    valida = false;
                }
            }

            return valida;
        }
        private bool validarGrado(string codigo)
        {
            String codAlt,cadena;
            codAlt = codigo[0] == '0' ? codigo.Substring(1) : codigo; //si viene codigo como 09, lo va a encontrar, si viene K1,K2,...no
            cadena = "select *from GradoDet where Codigo = '" + codigo + "' or codigo like '%" + codAlt + "%'";
            if (dcGral.getDataTable(cadena, Connect).Rows.Count ==0)
                return false;
            return true;
        }
    }
}

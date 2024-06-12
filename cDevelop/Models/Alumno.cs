using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cDevelop.Models
{
   

    public class Alumno
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int studentID { get; set; }
        public string homePhone { get; set; }
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public string citizenship { get; set; }
        public string gender { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string gradeLevel { get; set; }
        public string placement { get; set; }
        public string ssn { get; set; }
        public string status { get; set; }
        public int familyID { get; set; }
        public string nombrePadre { get; set; }
        public string identidadPadre { get; set; }
        public string celularPadre { get; set; }
        public string emailPadre { get; set; }
        public string nombreMadre { get; set; }
        public string identidadMadre { get; set; }
        public string celularMadre { get; set; }
        public string emailMadre { get; set; }
        public string plandePagos { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string transporteColonia { get; set; }
        public string schoolCode { get; set; }
        public string planTransporte { get; set; }
    }
}

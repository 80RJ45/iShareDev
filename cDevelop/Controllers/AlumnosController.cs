using cDevelop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace cDevelop.Controllers
{
    public class AlumnosController
    {
        private HttpClient client;

        public AlumnosController()
        {
            client = new HttpClient();
        }
       
        public async Task<List<Alumno>> GetAllAlumnos()
        {
            try
            {                
                var authToken = Encoding.ASCII.GetBytes("ewws20240517:$sq4`xrucR]@>&xX{Z");
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                HttpResponseMessage response = await
                    client.GetAsync("https://ewws.hasbon.com/financial");

                response.EnsureSuccessStatusCode();

                String responseJson = await
                    response.Content.ReadAsStringAsync();

                List <Alumno> alumnos = JsonConvert.DeserializeObject<List<Alumno>>(responseJson);

                return alumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
                throw;
            }
        }
    }
}

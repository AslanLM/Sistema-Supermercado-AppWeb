using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Supermercado_AppWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Supermercado_AppWeb.Controllers
{
    public class EmpleadosController : Controller
    {
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public EmpleadosController()
        {
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors)
                =>
                { return true; };
        }
        // GET: EmpleadosController

        public async Task<ActionResult> Index()
        {

            var lstempleados = new List<Empleados>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/empleados"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstempleados = JsonConvert.DeserializeObject<List<Empleados>>(apiResponse);
                };
            }
            return View(lstempleados);

        }

        // GET: empleadosController/Details/5
        public async Task<ActionResult<Empleados>> Details(string codigo)
        {
            Empleados empleados = new Empleados();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/empleados" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empleados = JsonConvert.DeserializeObject<Empleados>(apiResponse);
                }
            }

            return View(empleados);
        }

        // GET: empleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Empleados empleados)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(empleados), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:44332/api/empleados/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                empleados = JsonConvert.DeserializeObject<Empleados>(apiResponse);

            }
            if (empleados != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }



        // GET: empleadosController/Edit/5
        public async Task<ActionResult<Empleados>> Edit(string codigo)
        {
            Empleados empleados = new Empleados();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/empleados" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empleados = JsonConvert.DeserializeObject<Empleados>(apiResponse);
                }
            }
            return View(empleados);
        }

        // POST: empleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string codigo, Empleados empleados)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(empleados), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44332/api/empleados/" + codigo, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: empleadosController/Delete/5
        public async Task<ActionResult<Empleados>> Delete(string codigo)
        {
            Empleados empleados = new Empleados();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/empleados/" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empleados = JsonConvert.DeserializeObject<Empleados>(apiResponse);
                }
            }
            return View(empleados);
        }

        // POST: empleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string codigo, Empleados empleados)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:44332/api/empleados/" + codigo))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

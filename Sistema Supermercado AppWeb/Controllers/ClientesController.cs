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
    public class ClientesController : Controller
    {
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public ClientesController()
        {
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors)
                =>
                { return true; };
        }
        // GET: ClientesController

        public async Task<ActionResult> Index()
        {

            var lstClientes = new List<Clientes>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Clientes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstClientes = JsonConvert.DeserializeObject<List<Clientes>>(apiResponse);
                };
            }
            return View(lstClientes);

        }

        // GET: ClientesController/Details/5
        public async Task<ActionResult<Clientes>> Details(int id)
        {
               Clientes clientes = new Clientes();
               using(var httpClient = new HttpClient())
               {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Clientes/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);
                }
               }
                    
         return View(clientes);
        }

     

        // GET: productosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Clientes clientes)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(clientes), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:44332/api/Clientes/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);

            }
            if (clientes != null)
            {
                return RedirectToAction("Tienda","Home");
            }
            else
            {
                return View();
            }
        }



        // GET: ClientesController/Edit/5
        public async  Task<ActionResult<Clientes>> Edit(int id)
        {
            Clientes clientes = new Clientes();
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44332/api/Clientes/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);
                }
            }
            return View(clientes);  
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Clientes clientes)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(clientes), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44332/api/Clientes/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        
        // GET: ClientesController/Delete/5
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            Clientes clientes = new Clientes();
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44332/api/Clientes/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);
                }
            }
            return View(clientes);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Clientes clientes)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:44332/api/Clientes/" + id))
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

        // GET: ClientesController/Create
        public async Task<ActionResult> Login()
        {

            var lstClientes = new List<Clientes>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Clientes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstClientes = JsonConvert.DeserializeObject<List<Clientes>>(apiResponse);
                };
            }
            return View(lstClientes);

        }

        // POST: ClientesController/Login/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Clientes>> Login(Clientes clientes)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(clientes), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:44332/api/Clientes/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);

            }
            if (clientes.EsAdministrador == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Tienda");
            }
        }



    }
}

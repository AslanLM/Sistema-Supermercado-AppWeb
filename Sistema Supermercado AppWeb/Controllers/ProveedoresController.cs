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
    public class ProveedoresController : Controller
    {
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public ProveedoresController()
        {
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors)
                =>
                { return true; };
        }
        // GET: proveedoresController

        public async Task<ActionResult> Index()
        {

            var lstproveedores = new List<Proveedores>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Proveedores"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstproveedores = JsonConvert.DeserializeObject<List<Proveedores>>(apiResponse);
                };
            }
            return View(lstproveedores);

        }

        // GET: proveedoresController/Details/5
        public async Task<ActionResult<Proveedores>> Details(int id)
        {
            Proveedores proveedores = new Proveedores();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Proveedores/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    proveedores = JsonConvert.DeserializeObject<Proveedores>(apiResponse);
                }
            }

            return View(proveedores);
        }

        // GET: proveedoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Proveedores proveedores)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(proveedores), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:44332/api/Proveedores/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                proveedores = JsonConvert.DeserializeObject<Proveedores>(apiResponse);

            }
            if (proveedores != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }



        // GET: proveedoresController/Edit/5
        public async Task<ActionResult<Proveedores>> Edit(int id)
        {
            Proveedores proveedores = new Proveedores();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Proveedores/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    proveedores = JsonConvert.DeserializeObject<Proveedores>(apiResponse);
                }
            }
            return View(proveedores);
        }

        // POST: proveedoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Proveedores proveedores)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(proveedores), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44332/api/Proveedores/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: proveedoresController/Delete/5
        public async Task<ActionResult<Proveedores>> Delete(int id)
        {
            Proveedores proveedores = new Proveedores();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Proveedores/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    proveedores = JsonConvert.DeserializeObject<Proveedores>(apiResponse);
                }
            }
            return View(proveedores);
        }

        // POST: proveedoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Proveedores proveedores)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:44332/api/Proveedores/" + id))
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

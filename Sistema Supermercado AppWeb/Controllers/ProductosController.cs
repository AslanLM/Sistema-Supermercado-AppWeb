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
    public class ProductosController : Controller
    {
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public ProductosController()
        {
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors)
                =>
                { return true; };
        }
        // GET: productosController

        public async Task<ActionResult> Index()
        {

            var lstproductos = new List<Productos>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/productos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstproductos = JsonConvert.DeserializeObject<List<Productos>>(apiResponse);
                };
            }
            return View(lstproductos);

        }

        // GET: productosController/Details/5
        public async Task<ActionResult<Productos>> Details(string id)
        {
               Productos productos = new Productos();
               using(var httpClient = new HttpClient())
               {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/productos" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<Productos>(apiResponse);
                }
               }
                    
         return View(productos);
        }

        // GET: productosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Productos productos)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(productos), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("https://localhost:44332/api/productos/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                productos = JsonConvert.DeserializeObject<Productos>(apiResponse);

            }
            if (productos != null)
            {
                return RedirectToAction("Tienda","Home");
            }
            else
            {
                return View();
            }
        }



        // GET: productosController/Edit/5
        public async  Task<ActionResult<Productos>> Edit(string id)
        {
            Productos productos = new Productos();
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44332/api/productos" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<Productos>(apiResponse);
                }
            }
            return View(productos);  
        }

        // POST: productosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Productos productos)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(productos), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44332/api/productos/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        
        // GET: productosController/Delete/5
        public async Task<ActionResult<Productos>> Delete(string id)
        {
            Productos productos = new Productos();
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44332/api/productos/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<Productos>(apiResponse);
                }
            }
            return View(productos);
        }

        // POST: productosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, Productos productos)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:44332/api/productos/" + id))
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

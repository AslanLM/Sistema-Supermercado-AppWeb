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
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientesController/Create
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
            StringContent content = new StringContent(JsonConvert.SerializeObject(clientes), Encoding.UTF8, "appplication/json");
            using (var response = await httpClient.PostAsync("https://localhost:000/api/", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<Clientes>(apiResponse);
            }
            if (clientes != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }



        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

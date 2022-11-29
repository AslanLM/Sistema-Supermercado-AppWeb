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
    public class CategoriasController : Controller
    {
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public CategoriasController()
        {
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors)
                =>
                { return true; };
        }
        // GET: CategoriasController
        public async Task<ActionResult> Index()
        {
            var lstCategoriass = new List<Categorias>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Categorias"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstCategoriass = JsonConvert.DeserializeObject<List<Categorias>>(apiResponse);
                };
            }
            return View(lstCategoriass);
        }

        // GET: CategoriasController/Details/5
        public async Task<ActionResult<Categorias>> Details(int id)
        {
            Categorias categorias = new Categorias();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Categorias/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categorias = JsonConvert.DeserializeObject<Categorias>(apiResponse);
                }
            }

            return View(categorias);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriasController/Edit/5
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

        // GET: CategoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriasController/Delete/5
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

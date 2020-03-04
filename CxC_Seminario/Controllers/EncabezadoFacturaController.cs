using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CxC_Seminario.DO;
using Newtonsoft.Json;

namespace CxC_Seminario.Controllers
{
    public class EncabezadoFacturaController : Controller
    {
        string _baseurl = "https://localhost:44313/";
        // GET: EncabezadoFactura
        public async Task<ActionResult> Index()
        {
            List<EncabezadoFactura> aux = new List<EncabezadoFactura>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/EncabezadoFactura/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<EncabezadoFactura>>(auxRes);
                }
            }
            return View(aux);
        }
        public async Task<ActionResult> Details(int? id)
        {
            EncabezadoFactura aux = new EncabezadoFactura();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/EncabezadoFactura/GetOneById/5?id= " + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<EncabezadoFactura>(auxRes);
                }
            }
            return View(aux);
        }
        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EncabezadoFactura entidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/EncabezadoFactura/Insert", byteContent).Result;

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(entidad);
        }
        #endregion
        #region Edit
        public async Task<ActionResult> Edit(int? id)
        {
            EncabezadoFactura aux = new EncabezadoFactura();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/EncabezadoFactura/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<EncabezadoFactura>(auxRes);
                }
            }
            return View(aux);
        }

        [HttpPost]
        public ActionResult Edit(EncabezadoFactura entidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/EncabezadoFactura/Update", byteContent).Result;

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(entidad);
        }
        #endregion
        #region Delete
        public async Task<ActionResult> Delete(int? id)
        {
            EncabezadoFactura aux = new EncabezadoFactura();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/EncabezadoFactura/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<EncabezadoFactura>(auxRes);
                }
            }
            return View(aux);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EncabezadoFactura aux = new EncabezadoFactura();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/EncabezadoFactura/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<EncabezadoFactura>(auxRes);
                }

                var myContent = JsonConvert.SerializeObject(aux);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/EncabezadoFactura/Delete", byteContent).Result;

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(aux);
        }
        #endregion
    }
}
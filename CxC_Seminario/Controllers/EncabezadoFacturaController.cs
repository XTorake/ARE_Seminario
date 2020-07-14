using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly string _baseurl = "https://localhost:44313/";
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
                   aux= aux.OrderByDescending(e => e.FechaPago).ToList();
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
        public async Task<ActionResult> Create()
        {
            Factura aux = new Factura();
            using (var client = new HttpClient())
            {
                List<Producto> productos = new List<Producto>();
                List<LineaFactura> lineas = new List<LineaFactura>();
                aux.Encabezado = new EncabezadoFactura();

                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resUsuario = await client.GetAsync("api/Usuario/GetAll");
                HttpResponseMessage resProducto = await client.GetAsync("api/Producto/GetAll");
                if (resUsuario.IsSuccessStatusCode && resProducto.IsSuccessStatusCode)
                {
                    var auxresUsuario = resUsuario.Content.ReadAsStringAsync().Result;
                    var auxresProducto = resProducto.Content.ReadAsStringAsync().Result;
                    List<Usuario> estudiantes = new List<Usuario>();
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(auxresUsuario);
                    foreach (var item in usuarios)
                    {
                        if (item.IdTipoUsuario == 3)
                        {
                            estudiantes.Add(item);
                        }
                    }
                    ViewData["Usuarios"] = estudiantes;
                    productos = JsonConvert.DeserializeObject<List<Producto>>(auxresProducto);
                    aux.Productos = productos;
                    foreach (Producto item in productos)
                    {
                        LineaFactura l = new LineaFactura
                        {
                            IdProducto = item.IdProducto
                        };
                        lineas.Add(l);
                    }
                    aux.Lineas = lineas;
                }
            }
            return View(aux);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Factura entidad)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneByString/5?id=" + entidad.Encabezado.IdEstudiante);
                var auxRes = res.Content.ReadAsStringAsync().Result;
                Usuario aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res2 = await client.GetAsync("api/Iglesia/GetOneById/5?id= " + aux.IdIglesia);
                var auxRes2 = res2.Content.ReadAsStringAsync().Result;
                Iglesia aux2 = JsonConvert.DeserializeObject<Iglesia>(auxRes);
                entidad.Encabezado.IdEncabezado = Cryptography.RandomID().ToUpper();
                entidad.Encabezado.FechaPago = System.DateTime.Now;
                List<LineaFactura> lineas = new List<LineaFactura>();
                entidad.Lineas = lineas;
                for (int i = 0; i < entidad.Productos.Count(); i++)
                {
                    if (entidad.Productos[i].isChecked)
                    {
                        entidad.Lineas.Add(new LineaFactura()
                        {
                            IdProducto = entidad.Productos[i].IdProducto,
                            IdEncabezado = entidad.Encabezado.IdEncabezado,
                            Descripcion = entidad.Encabezado.Direccion
                        });

                    }
                }
                if (entidad.Encabezado.TotalCobrar - entidad.Encabezado.TotalPagar > 0)
                {
                    aux.MontoAdeudado = (float)entidad.Encabezado.TotalCobrar - (float)entidad.Encabezado.TotalPagar;
                }
                if (entidad.Encabezado.TotalCobrar == 0 && entidad.Encabezado.TotalPagar > 0)
                {
                    aux.MontoAdeudado -= (float)entidad.Encabezado.TotalPagar;
                }
                var myContent = JsonConvert.SerializeObject(entidad.Encabezado);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/EncabezadoFactura/Insert", byteContent).Result;
                myContent = JsonConvert.SerializeObject(aux);
                buffer = Encoding.UTF8.GetBytes(myContent);
                byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;
                System.Threading.Thread.Sleep(1000);
                foreach (LineaFactura item in lineas)
                {
                    client.DefaultRequestHeaders.Clear();
                    myContent = JsonConvert.SerializeObject(item);
                    buffer = Encoding.UTF8.GetBytes(myContent);
                    byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    postTask = client.PostAsync("api/LineaFactura/Insert", byteContent).Result;
                }


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
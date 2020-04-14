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
        public async Task<ActionResult> Create()
        {
            Factura aux = new Factura();
            using (var client = new HttpClient())
            {
                List<Producto> productos = new List<Producto>();
                List<LineaFactura> lineas = new List<LineaFactura>();


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
                        LineaFactura l = new LineaFactura();
                        l.IdProducto = item.IdProducto;
                        lineas.Add(l);
                    }
                    aux.Lineas = lineas;
                }
            }
            return View(aux);
        }

        [HttpPost]
        public ActionResult Create(Factura entidad)
        {
            entidad.Encabezado.IdEncabezado = Cryptography.RandomID();
            entidad.Encabezado.FechaPago = System.DateTime.Now;
            List<LineaFactura> lineas = new List<LineaFactura>();
            double cobrar = 0;
            double pagar = 0;
            for (int i = 0; i < entidad.Productos.Count(); i++)
            {
                if (entidad.Productos[i].isChecked)
                {
                    entidad.Lineas[i].IdProducto = entidad.Productos[i].IdProducto;
                    entidad.Lineas[i].IdEncabezado = entidad.Encabezado.IdEncabezado;
                    pagar += entidad.Lineas[i].Pago;
                    cobrar += entidad.Productos[i].Precio;
                    lineas.Add(entidad.Lineas[i]);
                }

            }
            entidad.Encabezado.TotalCobrar = cobrar - ((cobrar * entidad.Encabezado.Descuento) / 100);
            entidad.Encabezado.TotalPagar = pagar;
            //DiscountPrice = FullPrice - (FullPrice * DiscountPercent)

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                var myContent = JsonConvert.SerializeObject(entidad.Encabezado);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/EncabezadoFactura/Insert", byteContent).Result;
                TimeSpan ts = TimeSpan.FromMilliseconds(150);
                
                Task t = Task.Delay(() =>
                {
                    foreach (LineaFactura item in lineas)
                    {
                        myContent = JsonConvert.SerializeObject(item);
                        buffer = Encoding.UTF8.GetBytes(myContent);
                        byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        postTask = client.PostAsync("api/LineaFactura/Insert", byteContent).Result;
                    }
                });
                t.Wait(ts);
                t.Start();

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
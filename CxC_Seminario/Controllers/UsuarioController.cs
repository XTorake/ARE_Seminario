using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CxC_Seminario.DO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
namespace CxC_Seminario.Controllers
{
    public class UsuarioController : Controller
    {
        string _baseurl = "https://localhost:44313/";
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            List<Usuario> aux = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Usuario>>(auxRes);
                }
            }
            return View(aux);
        }
        public async Task<ActionResult> Details(string id)
        {
            Usuario aux = new Usuario();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneByString/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                }

            }
            return View(aux);
        }
        #region Create
        public async Task<ActionResult> Create()
        {

            List<Persona> personas = new List<Persona>();
            List<Persona> personasFiltradas = new List<Persona>();
            List<Usuario> usuarios = new List<Usuario>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resTipoUsuarios = await client.GetAsync("api/TipoUsuario/GetAll");
                HttpResponseMessage resIglesia = await client.GetAsync("api/Iglesia/GetAll");
                HttpResponseMessage resMetodoPagos = await client.GetAsync("api/MetodoPago/GetAll");
                HttpResponseMessage resCarreras = await client.GetAsync("api/Carrera/GetAll");
                HttpResponseMessage resPersonas = await client.GetAsync("api/Persona/GetAll");
                HttpResponseMessage resUsuarios = await client.GetAsync("api/Usuario/GetAll");

                if (resTipoUsuarios.IsSuccessStatusCode && resIglesia.IsSuccessStatusCode && resMetodoPagos.IsSuccessStatusCode && resCarreras.IsSuccessStatusCode && resPersonas.IsSuccessStatusCode && resUsuarios.IsSuccessStatusCode)
                {

                    var auxResTipoUsuarios = resTipoUsuarios.Content.ReadAsStringAsync().Result;
                    var auxResIglesia = resIglesia.Content.ReadAsStringAsync().Result;
                    var auxResMetodoPagos = resMetodoPagos.Content.ReadAsStringAsync().Result;
                    var auxResCarreras = resCarreras.Content.ReadAsStringAsync().Result;
                    var auxResPersonas = resPersonas.Content.ReadAsStringAsync().Result;
                    var auxResUsuarios = resUsuarios.Content.ReadAsStringAsync().Result;

                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(auxResUsuarios);
                    personas = JsonConvert.DeserializeObject<List<Persona>>(auxResPersonas);
                    personasFiltradas = personas;
                    foreach (var item in usuarios)
                    {
                        Persona itemToRemove = personas.SingleOrDefault(r => r.Cedula == item.Cedula);

                        if (itemToRemove != null)
                        {
                            personasFiltradas.Remove(itemToRemove);
                        }


                    }
                    if (personasFiltradas.Any())
                    {

                    }
                    ViewData["TipoUsuarios"] = JsonConvert.DeserializeObject<List<TipoUsuario>>(auxResTipoUsuarios);
                    ViewData["Iglesias"] = JsonConvert.DeserializeObject<List<Iglesia>>(auxResIglesia);
                    ViewData["MetodoPagos"] = JsonConvert.DeserializeObject<List<MetodoPago>>(auxResMetodoPagos);
                    ViewData["Carreras"] = JsonConvert.DeserializeObject<List<Carrera>>(auxResCarreras);
                    ViewData["Personas"] = personasFiltradas;

                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario entidad)
        {
            entidad.Contrasena = Cryptography.Encrypt(entidad.Contrasena);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Usuario/Insert", byteContent).Result;

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
            Usuario aux = new Usuario();
            List<TipoUsuario> tipoUsuarios = new List<TipoUsuario>();
            List<Iglesia> iglesias = new List<Iglesia>();
            List<MetodoPago> metodoPagos = new List<MetodoPago>();
            List<Carrera> carreras = new List<Carrera>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resUsuario = await client.GetAsync("api/Usuario/GetOneById/5?id=" + id);

                if (resUsuario.IsSuccessStatusCode)
                {
                    var auxRes = resUsuario.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                }

            }
            return View(aux);
        }

        [HttpPost]
        public ActionResult Edit(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;

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
            Usuario aux = new Usuario();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                }
            }
            return View(aux);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario aux = new Usuario();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                }

                var myContent = JsonConvert.SerializeObject(aux);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Usuario/Delete", byteContent).Result;

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
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(Usuario entidad)
        {
            Usuario aux = new Usuario();
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneByString/5?id=" + entidad.Usuario1);


                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                    if (aux != null)
                    {
                        if (aux.Contrasena != entidad.Contrasena)
                        {
                            if (aux.LoginCount>=3)
                            {
                                aux.IsTemp = true;
                                aux.Contrasena = Cryptography.RandomPassword();
                            }
                            client.BaseAddress = new Uri(_baseurl);
                            aux.LoginCount=aux.LoginCount + 1;
                            var myContent = JsonConvert.SerializeObject(aux);
                            var buffer = Encoding.UTF8.GetBytes(myContent);
                            var byteContent = new ByteArrayContent(buffer);
                            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;

                            var result = postTask;
                            if (result.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }



                            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");

                            return View(entidad);
                        }
                        else
                        {
                            Session["Usuario"] = aux.Usuario1;

                            Session["Tipo"] = aux.TipoUsuario;

                            return RedirectToAction("", "");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                        return View(entidad);
                    }
                }
            }
            return View(entidad);

        }

        

        #endregion
    }
}
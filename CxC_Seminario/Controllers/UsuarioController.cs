﻿using System;
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
        readonly string _baseurl = "https://localhost:44313/";
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

                HttpResponseMessage resPersonas = await client.GetAsync("api/Persona/GetAll");
                HttpResponseMessage resUsuarios = await client.GetAsync("api/Usuario/GetAll");

                if (resTipoUsuarios.IsSuccessStatusCode && resIglesia.IsSuccessStatusCode && resMetodoPagos.IsSuccessStatusCode && resPersonas.IsSuccessStatusCode && resUsuarios.IsSuccessStatusCode)
                {

                    var auxResTipoUsuarios = resTipoUsuarios.Content.ReadAsStringAsync().Result;
                    var auxResIglesia = resIglesia.Content.ReadAsStringAsync().Result;
                    var auxResMetodoPagos = resMetodoPagos.Content.ReadAsStringAsync().Result;

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
                    ViewData["Personas"] = personasFiltradas;

                }

            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Usuario entidad)
        {
            Persona aux = new Persona();
            Pais auxPais = new Pais();
            Iglesia auxIgle = new Iglesia();
            string contrasena = Cryptography.RandomPassword();
            entidad.Contrasena = contrasena;
            PasswordMail.UsuarioCreado(entidad.Usuario1, entidad.Contrasena, entidad.Correo);
            entidad.MontoAdeudado = 0;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Persona/GetOneByString/5?id=" + entidad.Cedula);
                HttpResponseMessage resIglesia = await client.GetAsync("api/Iglesia/GetOneById/5?id= " + entidad.IdIglesia);

                if (res.IsSuccessStatusCode && resIglesia.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;
                    var auxResIgle = resIglesia.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Persona>(auxRes);
                    auxIgle = JsonConvert.DeserializeObject<Iglesia>(auxResIgle);

                    res = await client.GetAsync("api/Pais/GetOneById/5?id= " + aux.IdPais);
                    if (res.IsSuccessStatusCode)
                    {
                        auxRes = res.Content.ReadAsStringAsync().Result;

                        auxPais = JsonConvert.DeserializeObject<Pais>(auxRes);
                    }
                }

            }
            entidad.Descuento = (int)auxPais.Descuento + (int)auxIgle.Descuento;
            entidad.Contrasena = Cryptography.Encrypt(entidad.Contrasena);
            entidad.IsTemp = true;
            entidad.LoginCount = 0;
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
        public async Task<ActionResult> Edit(string id)
        {
            Usuario aux = new Usuario();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resUsuario = await client.GetAsync("api/Usuario/GetOneByString/5?id=" + id);
                HttpResponseMessage resTipoUsuarios = await client.GetAsync("api/TipoUsuario/GetAll");
                HttpResponseMessage resIglesia = await client.GetAsync("api/Iglesia/GetAll");
                HttpResponseMessage resMetodoPagos = await client.GetAsync("api/MetodoPago/GetAll");

                if (resTipoUsuarios.IsSuccessStatusCode && resIglesia.IsSuccessStatusCode && resMetodoPagos.IsSuccessStatusCode && resUsuario.IsSuccessStatusCode)
                {
                    var auxResTipoUsuarios = resTipoUsuarios.Content.ReadAsStringAsync().Result;
                    var auxResIglesia = resIglesia.Content.ReadAsStringAsync().Result;
                    var auxResMetodoPagos = resMetodoPagos.Content.ReadAsStringAsync().Result;
                    var auxRes = resUsuario.Content.ReadAsStringAsync().Result;
                    ViewData["TipoUsuarios"] = JsonConvert.DeserializeObject<List<TipoUsuario>>(auxResTipoUsuarios);
                    ViewData["Iglesias"] = JsonConvert.DeserializeObject<List<Iglesia>>(auxResIglesia);
                    ViewData["MetodoPagos"] = JsonConvert.DeserializeObject<List<MetodoPago>>(auxResMetodoPagos);
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
        public async Task<ActionResult> Delete(string id)
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

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
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
                        
                        if (Cryptography.Decrypt(aux.Contrasena) != entidad.Contrasena)
                        {
                            if (aux.LoginCount > 3)
                            {
                                aux.IsTemp = true;
                                aux.Contrasena = Cryptography.Encrypt(Cryptography.RandomPassword());

                                aux.LoginCount = 0;
                                var myContent = JsonConvert.SerializeObject(aux);
                                var buffer = Encoding.UTF8.GetBytes(myContent);
                                var byteContent = new ByteArrayContent(buffer);
                                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;
                                var result = postTask;
                                if (result.IsSuccessStatusCode)
                                {
                                    PasswordMail.UsuarioBloqueado(aux.Usuario1, aux.Correo);
                                    ModelState.AddModelError(string.Empty, "Su usuario ha sido bloqueado debido a multiples inicios erroneos.\n Seleccione Olvido su contraseña para restablecerla.");
                                    return View(entidad);
                                }
                            }
                            else
                            {
                                aux.LoginCount += 1;

                                var myContent = JsonConvert.SerializeObject(aux);
                                var buffer = Encoding.UTF8.GetBytes(myContent);
                                var byteContent = new ByteArrayContent(buffer);
                                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;
                                var result = postTask;
                                if (result.IsSuccessStatusCode)
                                {
                                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                                    return View(entidad);
                                }
                            }
                        }
                        else
                        {
                            if (aux.IsTemp != true)
                            {
                                client.DefaultRequestHeaders.Clear();
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                res = await client.GetAsync("api/Persona/GetOneByString/5?id=" + aux.Cedula);
                                auxRes = res.Content.ReadAsStringAsync().Result;
                                Persona persona = JsonConvert.DeserializeObject<Persona>(auxRes);
                                Session["Nombre"] = persona.Nombre;
                                Session["Usuario"] = aux.Usuario1;
                                Session["Tipo"] = aux.IdTipoUsuario;
                                aux.LoginCount = 0;
                                var myContent = JsonConvert.SerializeObject(aux);
                                var buffer = Encoding.UTF8.GetBytes(myContent);
                                var byteContent = new ByteArrayContent(buffer);
                                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                Session["Usuario"] = aux.Usuario1;
                                Session["Tipo"] = aux.TipoUsuario;

                                return RedirectToAction("PasswordReset", "Usuario");
                            }

                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                        return View(entidad);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No hay conexion con el servidor. Contacte un administrador");
                    return View(entidad);
                }
            }
            return View(entidad);

        }



        #endregion
        #region ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(Usuario entidad)
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
                        if (aux.Cedula == entidad.Cedula && aux.Correo == entidad.Correo)
                        {
                            aux.Contrasena = Cryptography.RandomPassword();

                            PasswordMail.RestablecerContraseña(aux.Usuario1, aux.Contrasena, aux.Correo);
                            aux.Contrasena = Cryptography.Encrypt(aux.Contrasena);
                            aux.LoginCount = 0;
                            aux.IsTemp = true;
                            var myContent = JsonConvert.SerializeObject(aux);
                            var buffer = Encoding.UTF8.GetBytes(myContent);
                            var byteContent = new ByteArrayContent(buffer);
                            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;

                            var result = postTask;
                            if (entidad.IdTipoUsuario == 4)
                            {
                                return RedirectToAction("Index", "Usuario");

                            }
                            if (result.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Login", "Usuario");
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "No hay conexion con el servidor. Contacte a su administrador");
                                return View(entidad);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Los datos ingresados no son validos.");
                            return View(entidad);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Los datos ingresados no son correctos");
                        return View(entidad);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No hay conexion con el servidor. Contacte a su administrador");
                    return View(entidad);
                }
            }
        }

        #endregion
        #region PasswordReset
        public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordConfirmation entidad)
        {
            if (ModelState.IsValid)
            {
                Usuario aux = new Usuario();
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(_baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneByString/5?id=" + Session["Usuario"]);

                    if (res.IsSuccessStatusCode)
                    {
                        var auxRes = res.Content.ReadAsStringAsync().Result;
                        aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                        aux.IsTemp = false;
                        aux.LoginCount = 0;
                        aux.Contrasena = Cryptography.Encrypt(entidad.Contrasena);
                        var myContent = JsonConvert.SerializeObject(aux);
                        var buffer = Encoding.UTF8.GetBytes(myContent);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var postTask = client.PostAsync("api/Usuario/Update", byteContent).Result;
                        var result = postTask;
                        Session["Usuario"] = aux.Usuario1;
                        Session["Tipo"] = aux.IdTipoUsuario;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("", "");
                        }

                    }
                }
            }
            return View();
        }


        #endregion
        #region LogOut
        public ActionResult LogOut()
        {

            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }
        #endregion
    }
}
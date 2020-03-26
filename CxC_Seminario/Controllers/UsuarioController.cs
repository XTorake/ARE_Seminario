﻿using System;
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
                HttpResponseMessage res = await client.GetAsync("api/Usuario/GetOneByString/id= " + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Usuario>(auxRes);
                }

                HttpResponseMessage restipoUsuarios = await client.GetAsync("api/TipoUsuario/GetOneById/5?id=" + aux.IdTipoUsuario);
                if (restipoUsuarios.IsSuccessStatusCode)
                {

                }

                if (aux.IdIglesia != null)
                {
                    HttpResponseMessage resIglesias = await client.GetAsync("api/Iglesia/GetOneById/5?id=" + aux.IdIglesia);
                    if (resIglesias.IsSuccessStatusCode)
                    {

                    }
                }

                if (aux.IdMetodoPago != null)
                {
                    HttpResponseMessage resMetodoPagos = await client.GetAsync("api/MetodoPago/GetOneById/5?id=" + aux.IdMetodoPago);
                    if (resMetodoPagos.IsSuccessStatusCode)
                    {

                    }
                }

                if (aux.IdCarrera != null)
                {
                    HttpResponseMessage resCarreras = await client.GetAsync("api/Carrera/GetOneById/5?id=" + aux.IdCarrera);
                    if (resCarreras.IsSuccessStatusCode)
                    {

                    }
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
        public ActionResult Create(Usuario entidad)
        {
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
        public ActionResult Login(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                //string nomb = ModelState["Nombre"].Value.AttemptedValue;
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
    }
}
using CxC_Seminario.DO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CxC_Seminario.Controllers
{
    public class CursoController : Controller
    {
        string baseurl = "https://localhost:44313/";
        // GET: Curso
        public async Task<ActionResult> Index()
        {
            List<Curso> aux = new List<Curso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Curso/GetAll");

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Curso>>(auxRes);
                }
            }
            return View(aux);
        }
        public async Task<ActionResult> Details(int? id)
        {
            Curso curso = new Curso();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resCurso = await client.GetAsync("api/Curso/GetOneById/5?id= " + id);
              

                if (resCurso.IsSuccessStatusCode)
                {
                    var auxResCurso = resCurso.Content.ReadAsStringAsync().Result;
                 

                    curso = JsonConvert.DeserializeObject<Curso>(auxResCurso);

                    

                }
            }
            return View(curso);
        }
        #region Create
        public async Task<ActionResult> Create()
        {
                       using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage resUsuario = await client.GetAsync("api/Usuario/GetAll");
                
                if (resUsuario.IsSuccessStatusCode)
                {
                                      var auxResUsuario = resUsuario.Content.ReadAsStringAsync().Result;
                                       
                    List<Usuario> usuarios = new List<Usuario>();
                    List<Usuario> usuariosFiltrados = new List<Usuario>();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(auxResUsuario);
                    foreach (var item in usuarios)
                    {
                        if (item.IdTipoUsuario == 2)
                        {
                            usuariosFiltrados.Add(item);
                        }
                    }
                    ViewData["Usuarios"] = usuariosFiltrados;

                }
                return View();
            }
            }

        [HttpPost]
        public ActionResult Create(Curso entidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Curso/Insert", byteContent).Result;

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
            Curso curso = new Curso();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resCurso = await client.GetAsync("api/Curso/GetOneById/5?id=" + id);
                HttpResponseMessage resUsuario = await client.GetAsync("api/Usuario/GetAll");


                if (resUsuario.IsSuccessStatusCode && resCurso.IsSuccessStatusCode)
                {
                    var auxResCurso = resCurso.Content.ReadAsStringAsync().Result;
                    var auxResUsuario = resUsuario.Content.ReadAsStringAsync().Result;

                    curso = JsonConvert.DeserializeObject<Curso>(auxResCurso);
                    List<Usuario> usuarios = new List<Usuario>();
                    List<Usuario> usuariosFiltrados = new List<Usuario>();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(auxResUsuario);
                    foreach (var item in usuarios)
                    {
                        if (item.IdTipoUsuario == 2)
                        {
                            usuariosFiltrados.Add(item);
                        }
                    }
                    ViewData["Usuarios"] = usuariosFiltrados;

                }
            }
            return View(curso);
        }

        [HttpPost]
        public ActionResult Edit(Curso entidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                var myContent = JsonConvert.SerializeObject(entidad);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Curso/Update", byteContent).Result;

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
            Curso aux = new Curso();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Curso/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Curso>(auxRes);
                }
            }
            return View(aux);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Curso aux = new Curso();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Curso/GetOneById/5?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<Curso>(auxRes);
                }

                var myContent = JsonConvert.SerializeObject(aux);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync("api/Curso/Delete", byteContent).Result;

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
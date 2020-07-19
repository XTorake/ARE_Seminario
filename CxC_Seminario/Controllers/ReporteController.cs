using CxC_Seminario.DO;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace CxC_Seminario.Controllers
{
    public class ReporteController : Controller
    {
        readonly string _baseurl = "https://localhost:44313/";

        // GET: Reporte
        public async Task<ActionResult> Lista_Usuarios()
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

        public ActionResult Factura_Usuarios()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ARE_SeminarioConnectionString"].ConnectionString);
            SqlCommand comando;
            SqlDataReader lector;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt.Columns.Add("Cedula");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("N° de Factura");
            dt.Columns.Add("Fecha de Pago");
            dt.Columns.Add("ID de Producto");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Descuento");
            dt.Columns.Add("Total a Cobrar");
            dt.Columns.Add("Total a Pagar");
            dt.Columns[7].DataType = typeof(Int32);
            dt.Columns[8].DataType = typeof(Int32);
            dt.Columns[9].DataType = typeof(Int32);
            dt.Columns[10].DataType = typeof(Int32);


            con.Open();
            string a = Session["Usuario"].ToString();
            //  comando = new SqlCommand("SELECT * FROM FacturaPorUsuario('"+ a  +"'); ", con);
            comando = new SqlCommand("SELECT * FROM Factura_Usuario", con);

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DataRow row = dt.NewRow();
                row["Cedula"] = lector["Cedula"];
                row["Nombre"] = lector["Nombre"];
                row["Usuario"] = lector["Usuario"];
                row["N° de Factura"] = lector["N° de Factura"];
                row["Fecha de Pago"] = lector["Fecha de Pago"];
                row["ID de Producto"] = lector["ID de Producto"];
                row["Descripcion"] = lector["Descripcion"];
                row["Precio"] = Convert.ToInt32(lector["Precio"]);
                row["Descuento"] = Convert.ToInt32(lector["Descuento"]);
                row["Total a Cobrar"] = Convert.ToInt32(lector["Total a Cobrar"]);
                row["Total a Pagar"] = Convert.ToInt32(lector["Total a Pagar"]);

                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);
            ReportViewer ReportViewer1 = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                //  Width = Unit.Percentage(100),
                // Height = Unit.Percentage(100),
                ZoomMode = ZoomMode.FullPage
            };
            ReportViewer1.LocalReport.ReportPath = "E:/Analisis/Proyecto/SeminarioReports/Factura_Usuario.rdl";
            ReportDataSource rpt = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rpt);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.LocalReport.Refresh();
            ViewBag.ReportViewer = ReportViewer1;
                                                  
            return View();
        }
        public ActionResult Factura_Usuario(string id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ARE_SeminarioConnectionString"].ConnectionString);
            SqlCommand comando;
            SqlDataReader lector;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt.Columns.Add("Cedula");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("N° de Factura");
            dt.Columns.Add("Fecha de Pago");
            dt.Columns.Add("ID de Producto");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Descuento");
            dt.Columns.Add("Total a Cobrar");
            dt.Columns.Add("Total a Pagar");
            dt.Columns[7].DataType = typeof(Int32);
            dt.Columns[8].DataType = typeof(Int32);
            dt.Columns[9].DataType = typeof(Int32);
            dt.Columns[10].DataType = typeof(Int32);


            con.Open();
            string a = Session["Usuario"].ToString();
            //  comando = new SqlCommand("SELECT * FROM FacturaPorUsuario('"+ a  +"'); ", con);
            comando = new SqlCommand("SELECT * FROM Factura_Usuario where Usuario = '"+id+"'", con);

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DataRow row = dt.NewRow();
                row["Cedula"] = lector["Cedula"];
                row["Nombre"] = lector["Nombre"];
                row["Usuario"] = lector["Usuario"];
                row["N° de Factura"] = lector["N° de Factura"];
                row["Fecha de Pago"] = lector["Fecha de Pago"];
                row["ID de Producto"] = lector["ID de Producto"];
                row["Descripcion"] = lector["Descripcion"];
                row["Precio"] = Convert.ToInt32(lector["Precio"]);
                row["Descuento"] = Convert.ToInt32(lector["Descuento"]);
                row["Total a Cobrar"] = Convert.ToInt32(lector["Total a Cobrar"]);
                row["Total a Pagar"] = Convert.ToInt32(lector["Total a Pagar"]);

                dt.Rows.Add(row);
            }
            ds.Tables.Add(dt);
            ReportViewer ReportViewer1 = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                //  Width = Unit.Percentage(100),
                // Height = Unit.Percentage(100),
                ZoomMode = ZoomMode.FullPage
            };
            ReportViewer1.LocalReport.ReportPath = "E:/Analisis/Proyecto/SeminarioReports/Factura_Usuario.rdl";
            ReportDataSource rpt = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rpt);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.LocalReport.Refresh();
            ViewBag.ReportViewer = ReportViewer1;

            return View();

        }
        public ActionResult Pagos_Mes_Usuario()
        {

            return View();
        }

    }
}
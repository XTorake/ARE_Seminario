using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CxC_Seminario.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Factura_Usuario()
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
            //  ReportViewer1.Width = Unit.Percentage(100);
            // ReportViewer1.Height = Unit.Percentage(100);
            ReportViewer1.LocalReport.Refresh();
            ViewBag.ReportViewer = ReportViewer1;





            //ReportViewer reportViewer = new ReportViewer
            //{
            //    ProcessingMode = ProcessingMode.Local,
            //    SizeToReportContent = true,
            //    Width = Unit.Percentage(100),
            //    Height = Unit.Percentage(100),
            //    ZoomMode = ZoomMode.FullPage
            //};

            //var connectionString = ConfigurationManager.ConnectionStrings["ARE_SeminarioConnectionString"].ConnectionString;


            //SqlConnection conx = new SqlConnection(connectionString); SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Factura_Usuario", conx);

            //adp.Fill(ds, ds.Factura_Usuario.TableName);

            //reportViewer.LocalReport.ReportPath = "E:/Analisis/Proyecto/SeminarioReports/Report1.rdl";
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetFactura_Usuario", ds.Tables[0]));


            //ViewBag.ReportViewer = reportViewer;

            return View();
        }
        public ActionResult Cuentas_Mes()
        {
            return View();

        }
        public ActionResult Pagos_Mes_Usuario()
        {

            return View();
        }

    }
}
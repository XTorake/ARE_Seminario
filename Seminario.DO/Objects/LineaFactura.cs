namespace Seminario.DO.Objects
{
    public class LineaFactura
    {
        public int IdLinea { get; set; }
        public int IdProducto { get; set; }
        public double Monto { get; set; }
        public double Pago { get; set; }
        public string Descripcion { get; set; }
        public string IdEncabezado { get; set; }
    }
}

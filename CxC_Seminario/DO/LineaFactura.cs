namespace CxC_Seminario.DO
{
    public class LineaFactura
    {
        public int IdLinea { get; set; }
        public int IdProducto { get; set; }
        public double Monto { get; set; }
        public double Pago { get; set; }
        public string Descripcion { get; set; }
        public string IdEncabezado { get; set; }

        public virtual EncabezadoFactura EncabezadoFactura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

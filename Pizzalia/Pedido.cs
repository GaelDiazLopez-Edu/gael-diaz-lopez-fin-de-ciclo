namespace Pizzalia
{
    public class Pedido
    {
        public string NombrePedido { get; set; }
        public string TipoPedido { get; set; }
        public string Direccion { get; set; }
        public string Motorista { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoItem> Articulos { get; set; }
        public decimal Total { get; set; }
    }

    public class PedidoItem
    {
        public string Categoria { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
    }
}
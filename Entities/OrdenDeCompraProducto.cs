using System;
using System.Collections.Generic;

namespace BestCoffee.Entities;

public partial class OrdenDeCompraProducto
{
    public int IdOrdenDeCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual OrdenDeCompra IdOrdenDeCompraNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}

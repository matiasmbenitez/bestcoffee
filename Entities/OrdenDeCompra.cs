using System;
using System.Collections.Generic;

namespace BestCoffee.Entities;

public partial class OrdenDeCompra
{
    public int IdOrdenDeCompra { get; set; }

    public decimal ImporteTotal { get; set; }

    public int IdProveedor { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; } = new List<OrdenDeCompraProducto>();
}

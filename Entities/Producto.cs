using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace BestCoffee.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Importe { get; set; }

    public int StockMin { get; set; }

    public int StockMax { get; set; }

    public int StockActual { get; set; }

    public int NumeroLote { get; set; }

    public DateTime FechaVenc { get; set; }

    public int IdProveedor { get; set; }
    [ValidateNever]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; } = new List<OrdenDeCompraProducto>();
}

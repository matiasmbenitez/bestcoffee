using System;
using System.Collections.Generic;

namespace BestCoffee.Entities;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public long Cuit { get; set; }

    public string? RazonSocial { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public long? Telefono { get; set; }

    public virtual ICollection<OrdenDeCompra> OrdenDeCompra { get; set; } = new List<OrdenDeCompra>();

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}

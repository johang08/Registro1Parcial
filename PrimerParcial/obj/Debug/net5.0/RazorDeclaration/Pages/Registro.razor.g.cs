// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PrimerParcial.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using PrimerParcial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\_Imports.razor"
using PrimerParcial.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\Pages\Registro.razor"
using PrimerParcial.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\Pages\Registro.razor"
using PrimerParcial.BLL;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Articulo")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/Articulo/{ArticuloId:int}")]
    public partial class Registro : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 77 "C:\Users\DANNY\source\repos\Registro1Parcial\PrimerParcial\Pages\Registro.razor"
       

    string Mensaje = string.Empty;

    [Inject]
    private ArticulosBLL articuloBLL { get; set; }

    [Parameter]
    public int ArticuloId { get; set; }

    Articulos articulo = new Articulos();

    protected override void OnInitialized()
    {
        Nuevo();
    }


    public async void Buscar()
    {
        var registro = await articuloBLL.Buscar(this.ArticuloId);

        if (registro != null)
        {
            articulo = registro;

        }
        else
        {
            Mensaje = "Encontrado";
        }
    }

    public void Nuevo()
    {
        Limpiar();
    }

    public async void Guardar()
    {
        articulo.ArticuloId = this.ArticuloId;
        if (await articuloBLL.Guardar(articulo))
        {

            Mensaje = (" Save");
            Limpiar();

        }
        else
        {
            Mensaje = ("No Save");

        }
    }

    public async void Eliminar()
    {
        if (await articuloBLL.Eliminar(this.ArticuloId))
        {
            Mensaje = ("Borrado");
            Limpiar();
        }
        else
        {
            Mensaje = ("No Borrado");

        }
    }

    public void Limpiar()
    {
        articulo = new Articulos();
        this.ArticuloId = 0;
    }

    private void Calcular()
    {
        articulo.ValorInventario = articulo.Costo * articulo.Existencia;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

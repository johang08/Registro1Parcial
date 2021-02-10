using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class ArticulosBLL
    {

            public static bool Guardar(Articulos articulo)
        {
            if (!Existe(articulo.articuloId))
                return Insertar(articulo);
            else
                return Modificar(articulo);
        }

    }
}

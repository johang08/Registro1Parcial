using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class ArticulosBLL
    {
        private Contexto _dbContext;

        public ArticulosBLL(Contexto _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<bool> Existe(int id)
        {
            bool pass = false;

            try
            {
                pass = await _dbContext.Articulos.AnyAsync(await => a.ProductoId == id);
            }
            catch
            {
                throw;
            }
            return pass;
        }

        private async Task<bool> Insertar(Articulos articulo)
        {
            bool pass = false;

            try
            {
                await _dbContext.Articulos.AddAsync(articulo);
                pass = await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
            return pass;
        }

    }
}
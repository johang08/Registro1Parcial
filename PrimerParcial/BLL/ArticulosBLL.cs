using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class ArticulosBLL
    {
        private Contexto contexto;
        public ArticulosBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> Guardar(Articulos articulos)
        {
            if (!await Existe(articulos.ArticuloId))
                return await Insertar(articulos);
            else
                return await Modificar(articulos);
        }
        private async Task<bool> Existe(int id)
        {
            bool ok = false;
            try
            {
                ok = await contexto.Articulos.AnyAsync(a => a.ArticuloId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }
        private async Task<bool> Insertar(Articulos articulos)
        {
            bool ok = false;
            try
            {
                await contexto.Articulos.AddAsync(articulos);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }
        private async Task<bool> Modificar(Articulos articulos)
        {
            bool ok = false;
            try
            {
                var aux = contexto.Set<Articulos>()
                    .Local.SingleOrDefault(a => a.ArticuloId == articulos.ArticuloId);
                if (aux != null)
                {
                    contexto.Entry(aux).State = EntityState.Detached;
                }

                contexto.Entry(articulos).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }
        public async Task<Articulos> Buscar(int id)
        {
            Articulos articulo;
            try
            {
                articulo = await contexto.Articulos.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

            return articulo;
        }
        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;

            try
            {
                var art = await Buscar(id);
                if (art != null)
                {
                    contexto.Articulos.Remove(art);
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }
        public async Task<List<Articulos>> GetArticulos()
        {
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = await contexto.Articulos.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
        public async Task<List<Articulos>> GetArticulos(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = await contexto.Articulos.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

    }
}
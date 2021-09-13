using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Services
{
    public class InventarioService : IInventarioService
    {
        private StarWarsContexto _context;

        public InventarioService(StarWarsContexto contexto)
        {
            _context = contexto;
        }



        public bool Delete(Inventario inventario)
        {
            var existe = _context.Inventario
                    .Where(x => x.Id == inventario.Id)
                    .FirstOrDefault();

            foreach(var remove in existe.Itens)
            {
                _context.ItemInventario.Remove(remove);
            }

            _context.Inventario.Remove(existe);

            _context.SaveChangesAsync();

            return true;
        }

        public async Task<Tuple<Rebelde, Rebelde>> NegociaInventario(int IdNegociante, int IdNegociador, int IdItemNegociante, int IdItemNegociador)
        {
            var negociante = await _context.Rebeldes.AsNoTracking()
                 .Include(c => c.Localizacao)
                 .Include(d => d.Inventario)
                 .Include(c => c.Inventario.Itens)
                 .Where(x => x.Id == IdNegociante).FirstOrDefaultAsync();

            var negociador = await _context.Rebeldes.AsNoTracking()
                .Include(c => c.Localizacao)
                .Include(d => d.Inventario)
                .Include(c => c.Inventario.Itens)
                .Where(x => x.Id == IdNegociador).FirstOrDefaultAsync();

            var itemFilteredNegociante = negociante.Inventario.Itens.Where(x => x.Id == IdItemNegociante).FirstOrDefault();
            var itemFilteredNegociador = negociador.Inventario.Itens.Where(x => x.Id == IdItemNegociador).FirstOrDefault();


            // Criando negociador temporario para armazenar o item atual
            var negocianteTemp = itemFilteredNegociante;
            var negociadorTemp = itemFilteredNegociador;

            // atualizando o negociante com os itens do negociador 
            itemFilteredNegociante.Pontuacao = negociadorTemp.Pontuacao;
            itemFilteredNegociante.Tipo = negociadorTemp.Tipo;

            // Salvando a troca do negociante com o negociador
            await SaveOrUpdateItem(itemFilteredNegociante);

            //Atualizando o negociador com os itens do negociante
            itemFilteredNegociador.Pontuacao = negocianteTemp.Pontuacao;
            itemFilteredNegociador.Tipo = negocianteTemp.Tipo;

            // Salvando a troca do negociador com o negociante
            await SaveOrUpdateItem(itemFilteredNegociante);

            // Filtrando novaente para retornar atualizado
            var negocianteAtual = await _context.Rebeldes.AsNoTracking()
                .Include(c => c.Localizacao)
                .Include(d => d.Inventario)
                .Include(c => c.Inventario.Itens)
                .Where(x => x.Id == IdNegociante).FirstOrDefaultAsync();

            var negociadorAtual = await _context.Rebeldes.AsNoTracking()
                .Include(c => c.Localizacao)
                .Include(d => d.Inventario)
                .Include(c => c.Inventario.Itens)
                .Where(x => x.Id == IdNegociador).FirstOrDefaultAsync();

            return new Tuple<Rebelde, Rebelde>(negociadorAtual, negocianteAtual);

        }
        public async Task<Inventario> SaveOrUpdate(Inventario model)
        {
            var existe = _context.Inventario
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

            if (existe == null)
            {
                _context.Inventario.Add(model);
                foreach (var item in model.Itens)
                {
                    await SaveOrUpdateItem(item);
                }

            }
            else
            {
                existe.Id = model.Id;
            }
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<ItemInventario> SaveOrUpdateItem(ItemInventario itens)
        {
            var existe = _context.ItemInventario
                    .Where(x => x.Id == itens.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.ItemInventario.Add(itens);
            else
            {
                existe.Id = itens.Id;
            }
            await _context.SaveChangesAsync();

            return itens;

        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoEstoqueASS.Data;
using ProjetoEstoqueASS.Models;

namespace ProjetoEstoqueASS.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Item Cadastrar(Item item)
        {
            if (_context.Itens.Any(i => i.Codigo == item.Codigo))
                throw new InvalidOperationException("Já existe um item com este código.");

            _context.Itens.Add(item);
            _context.SaveChanges();
            return item;
        }

        public IEnumerable<Item> ListarTodos()
        {
            return _context.Itens.AsNoTracking().ToList();
        }

        public Item? BuscarPorCodigo(string codigo)
        {
            return _context.Itens.AsNoTracking()
                .FirstOrDefault(i => i.Codigo == codigo.ToUpper());
        }

        public void Atualizar(Item item)
        {
            var existente = _context.Itens.Find(item.Codigo);
            if (existente == null)
                throw new InvalidOperationException("Item não encontrado.");

            _context.Entry(existente).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }

        public void Remover(string codigo)
        {
            var item = _context.Itens.Find(codigo);
            if (item != null)
            {
                _context.Itens.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
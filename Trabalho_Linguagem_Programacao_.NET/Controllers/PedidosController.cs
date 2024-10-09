using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho_Linguagem_Programacao_.NET.Models;

namespace Trabalho_Linguagem_Programacao_.NET.Controllers
{
    public class PedidosController : Controller
    {
        private readonly Contexto _context;

        public PedidosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pedidos.Include(p => p.cliente).Include(p => p.produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.cliente)
                .Include(p => p.produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            var tStatus = Enum.GetValues(typeof(Status))
                  .Cast<Status>()
                  .Select(e => new SelectListItem
                  {
                      Value = e.ToString(),
                      Text = e.ToString()
                  });

            ViewBag.tStatus = tStatus;



            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome");
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,data,clienteID,produtoID,quantidade,status,valor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var produto = await _context.Produtos.FindAsync(pedido.produtoID);      
                pedido.valor = pedido.quantidade * produto.preco;
                pedido.status = Status.Pendente;

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

         

            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", pedido.clienteID);
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", pedido.produtoID);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            var tStatus = Enum.GetValues(typeof(Status))
                  .Cast<Status>()
                  .Select(e => new SelectListItem
                  {
                      Value = e.ToString(),
                      Text = e.ToString()
                  });

            ViewBag.tStatus = tStatus;

            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", pedido.clienteID);
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", pedido.produtoID);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,data,clienteID,produtoID,quantidade,status,valor")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produto = await _context.Produtos.FindAsync(pedido.produtoID);
                    pedido.valor = pedido.quantidade * produto.preco;
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", pedido.clienteID);
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", pedido.produtoID);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.cliente)
                .Include(p => p.produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}

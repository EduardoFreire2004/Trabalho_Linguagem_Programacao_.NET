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
    public class MovimentacoesController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Movimentacoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Movimentacoes.Include(m => m.cliente).Include(m => m.produto).Include(m => m.fornecedor);
            return View(await contexto.ToListAsync());
        }

        // GET: Movimentacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.cliente)
                .Include(m => m.produto)
                .Include(m => m.fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacoes/Create
        public IActionResult Create()
        {
            var tTipo = Enum.GetValues(typeof(Tipo))
                   .Cast<Tipo>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   });

            ViewBag.tTipo = tTipo;

            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome");
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome");
            ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome");


            return View();


        }

        // POST: Movimentacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,data,tipo,produtoID,quantidade,clienteID,descricao,fornecedorID")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
              
                var produto = await _context.Produtos.FindAsync(movimentacao.produtoID);
                if (produto == null)
                {
                    ModelState.AddModelError("", "Produto não encontrado.");
                    ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", movimentacao.clienteID);
                    ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", movimentacao.produtoID);
                    ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome", movimentacao.fornecedorID);
                    return View(movimentacao);
                }

              
                if (movimentacao.tipo == Tipo.Saida)
                {
                   
                    if (produto.qtde_estoque < movimentacao.quantidade)
                    {
                        ModelState.AddModelError("", "Estoque insuficiente para a movimentação.");
                        ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", movimentacao.clienteID);
                        ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", movimentacao.produtoID);
                        ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome", movimentacao.fornecedorID);
                        return View(movimentacao);
                    }

                    produto.qtde_estoque -= movimentacao.quantidade;

                    
                    if (movimentacao.clienteID == 0)
                    {
                        ModelState.AddModelError("", "É necessário selecionar um cliente para uma saída.");
                        ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", movimentacao.clienteID);
                        ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", movimentacao.produtoID);
                        ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome", movimentacao.fornecedorID);
                        return View(movimentacao);
                    }

                    movimentacao.fornecedorID = null; 
                }
                else if (movimentacao.tipo == Tipo.Entrada)
                {
                    produto.qtde_estoque += movimentacao.quantidade;

                   
                    if (movimentacao.fornecedorID == 0)
                    {
                        ModelState.AddModelError("", "É necessário selecionar um fornecedor para uma entrada.");
                        ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", movimentacao.clienteID);
                        ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", movimentacao.produtoID);
                        ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome", movimentacao.fornecedorID);
                        return View(movimentacao);
                    }

                    movimentacao.clienteID = null; 
                }

                _context.Add(movimentacao);
                _context.Update(produto);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["clienteID"] = new SelectList(_context.Clientes, "Id", "nome", movimentacao.clienteID);
            ViewData["produtoID"] = new SelectList(_context.Produtos, "Id", "nome", movimentacao.produtoID);
            ViewData["fornecedorID"] = new SelectList(_context.Fornecedores, "Id", "nome", movimentacao.fornecedorID);
            return View(movimentacao);
        }





        // GET: Movimentacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.cliente)
                .Include(m => m.produto)
                .Include(m => m.fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);

            if (movimentacao != null)
            {
                var produto = await _context.Produtos.FindAsync(movimentacao.produtoID);

                if (produto != null)
                {
                    
                    if (movimentacao.tipo == Tipo.Saida)
                    {
                        
                        produto.qtde_estoque += movimentacao.quantidade;
                    }
                    else if (movimentacao.tipo == Tipo.Entrada)
                    {
                        
                        produto.qtde_estoque -= movimentacao.quantidade;
                    }

                   
                    _context.Update(produto);
                }

                _context.Movimentacoes.Remove(movimentacao);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

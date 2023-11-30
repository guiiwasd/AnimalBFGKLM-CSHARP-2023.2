using AnimalBFGKLM.Models;
using Microsoft.AspNetCore.Mvc;
using AnimalBFGKLM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalBFGKLM.Controllers
    {
        public class AnimalController : Controller
        {
            private readonly AnimalContext _context;

            public AnimalController(AnimalContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                return View(await _context.AnimalTipos.OrderBy(i => i.Nome).ToListAsync());
            }

            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create([Bind("Nome", "Peso", "Idade", "Descricao", "Domestico", "Selvagem", "Comportamento", "Habitat")] AnimalTipo animalTipo)
            {
                try
                {
                    if (animalTipo.Domestico && string.IsNullOrEmpty(animalTipo.Comportamento))
                    {
                        ModelState.AddModelError("Comportamento", "O campo Comportamento é obrigatório para animais domésticos.");
                    }

                    if (animalTipo.Selvagem && string.IsNullOrEmpty(animalTipo.Habitat))
                    {
                        ModelState.AddModelError("Habitat", "O campo Habitat é obrigatório para animais selvagens.");
                    }
                    if (ModelState.IsValid)
                        {
                        if (animalTipo.Domestico)
                        {
                            var comportamento = animalTipo.Comportamento;
                        }
                        else if (animalTipo.Selvagem)
                        {
                            var habitat = animalTipo.Habitat;
                        }

                        _context.Add(animalTipo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("Erro de cadastro", "Não foi possível cadastrar ao zoológico.");
                }
                return View(animalTipo);
            }
            public async Task<ActionResult> Edit(long id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var animalTipo = await _context.AnimalTipos.SingleOrDefaultAsync(i => i.AnimalId == id);
                if (animalTipo == null)
                {
                    return NotFound();
                }
                return View(animalTipo);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long? id, [Bind("AnimalId", "Nome", "Peso", "Idade", "Descricao", "Domestico", "Selvagem", "Comportamento", "Habitat")] AnimalTipo animalTipo)
            {
                if (id != animalTipo.AnimalId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(animalTipo);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!AnimalExists(animalTipo.AnimalId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View(animalTipo);
            }

            private bool AnimalExists(long? animalId)
            {
                var animal = _context.AnimalTipos.FirstOrDefault(i => i.AnimalId == animalId);
                if (animal == null)
                    return false;
                return true;
            }
            public async Task<ActionResult> Details(long id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var animalTipo = await _context.AnimalTipos.SingleOrDefaultAsync(i => i.AnimalId == id);
                if (animalTipo == null)
                {
                    return NotFound();
                }
                return View(animalTipo);
            }
            public async Task<ActionResult> Delete(long id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var animalTipo = await _context.AnimalTipos.SingleOrDefaultAsync(i => i.AnimalId == id);
                if (animalTipo == null)
                {
                    return NotFound();
                }
                return View(animalTipo);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(long? id)
            {
                var animalTipo = await _context.AnimalTipos.SingleOrDefaultAsync(i => i.AnimalId == id);
                _context.AnimalTipos.Remove(animalTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }

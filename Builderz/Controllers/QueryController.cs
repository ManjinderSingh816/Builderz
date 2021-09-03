using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Builderz.Data;
using Builderz.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Builderz.Controllers
{
    namespace Builderz.Controllers
    {
        public class QueryController : Controller
        {
            private readonly BuilderzContext _context;

            public QueryController(BuilderzContext context)
            {
                _context = context;
            }

            // GET: Query
            public async Task<IActionResult> Index()
            {
                return View(await _context.Query.ToListAsync());
            }

            // GET: Query/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Query = await _context.Query
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Query == null)
                {
                    return NotFound();
                }

                return View(Query);
            }

            public IActionResult Display()
            {
                return View();
            }

            // GET: Query/Create
            public IActionResult Create()
            {
                return View();
            }
            
            // POST: Query/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Email,QueryDetail")] Query Query)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Query);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Display));
                }
                return View(Query);
            }

            // GET: Query/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Query = await _context.Query.FindAsync(id);
                if (Query == null)
                {
                    return NotFound();
                }
                return View(Query);
            }

            // POST: Query/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,QueryDetail")] Query Query)
            {
                if (id != Query.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Query);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!QueryExists(Query.Id))
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
                return View(Query);
            }

            // GET: Query/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Query = await _context.Query
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Query == null)
                {
                    return NotFound();
                }

                return View(Query);
            }

            // POST: Query/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Query = await _context.Query.FindAsync(id);
                _context.Query.Remove(Query);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool QueryExists(int id)
            {
                return _context.Query.Any(e => e.Id == id);
            }
        }
    }
}

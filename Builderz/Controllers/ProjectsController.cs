using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Builderz.Data;
using Builderz.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace Builderz.Controllers
{
        public class ProjectsController : Controller
        {
            private readonly BuilderzContext _context;

            public ProjectsController(BuilderzContext context)
            {
                _context = context;
            }

            // GET: Projects
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Projects.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Projects.ToListAsync());
            }
        
            // GET: Projects/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Projects = await _context.Projects
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Projects == null)
                {
                    return NotFound();
                }

                return View(Projects);
            }

            // GET: Projects/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Projects/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectType,Price")] Projects Projects)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Projects);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Projects);
            }

            // GET: Projects/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Projects = await _context.Projects.FindAsync(id);
                if (Projects == null)
                {
                    return NotFound();
                }
                return View(Projects);
            }

            // POST: Projects/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectType,Price")] Projects Projects)
            {
                if (id != Projects.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Projects);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProjectsExists(Projects.Id))
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
                return View(Projects);
            }

            // GET: Projects/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Projects = await _context.Projects
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Projects == null)
                {
                    return NotFound();
                }

                return View(Projects);
            }

            // POST: Projects/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Projects = await _context.Projects.FindAsync(id);
                _context.Projects.Remove(Projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ProjectsExists(int id)
            {
                return _context.Projects.Any(e => e.Id == id);
            }
        }
    }
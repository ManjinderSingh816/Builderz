using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Builderz.Data;
using Builderz.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Builderz.Controllers
{
        public class SelectedProjectsController : Controller
        {
            private readonly BuilderzContext _context;

            public SelectedProjectsController(BuilderzContext context)
            {
                _context = context;
            }

        // GET: SelectedProjects
        public async Task<IActionResult> Index()
            {
               return View(await _context.SelectedProjects.ToListAsync());               
            }

        // GET: SelectedProjects/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var SelectedProjects = await _context.SelectedProjects
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (SelectedProjects == null)
                {
                    return NotFound();
                }

                return View(SelectedProjects);
            }
        public IActionResult ProjectNotFound()
        {
            return View();
        }
         public IActionResult SelectedProjectsed()
        {
            return View();
        }
        
        // GET: SelectedProjects/Create
        public IActionResult Create()
            {
            var Projects = _context.Projects.ToList();
            if (Projects.Count > 0)
            {
                Projects.Insert(0, new Projects { Id = 0, ProjectName = "Select Projects" });
                ViewBag.ListProjects = Projects;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(ProjectNotFound));
            }
            }



        // POST: SelectedProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,Email,Location,ProjectId")] SelectedProjects SelectedProjects)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(SelectedProjects);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(SelectedProjects);
            }

        // GET: SelectedProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var SelectedProjects = await _context.SelectedProjects.FindAsync(id);
                if (SelectedProjects == null)
                {
                    return NotFound();
                }
                return View(SelectedProjects);
            }

        // POST: SelectedProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,Email,Location,ProjectId")] SelectedProjects SelectedProjects)
            {
                if (id != SelectedProjects.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                    var item = _context.SelectedProjects.FirstOrDefault(x => x.Id == SelectedProjects.Id);
                    item.Id = SelectedProjects.Id;
                    item.Name = SelectedProjects.Name;
                    item.Contact = SelectedProjects.Contact;
                    item.Email = SelectedProjects.Email;
                    item.Location = SelectedProjects.Location;
                    _context.SelectedProjects.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SelectedProjectsExists(SelectedProjects.Id))
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
                return View(SelectedProjects);
            }

        // GET: SelectedProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var SelectedProjects = await _context.SelectedProjects
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (SelectedProjects == null)
                {
                    return NotFound();
                }

                return View(SelectedProjects);
            }

        // POST: SelectedProjects/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var SelectedProjects = await _context.SelectedProjects.FindAsync(id);
                _context.SelectedProjects.Remove(SelectedProjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SelectedProjectsExists(int id)
            {
                return _context.SelectedProjects.Any(e => e.Id == id);
            }
        }
    }

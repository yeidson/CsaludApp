using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CsaludApp.Web.Data;
using CsaludApp.Web.Data.Entities;

namespace CsaludApp.Web.Controllers
{
    public class InquiryTypesController : Controller
    {
        private readonly DataContext _context;

        public InquiryTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: InquiryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InquiryTypes.ToListAsync());
        }

        // GET: InquiryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryType = await _context.InquiryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquiryType == null)
            {
                return NotFound();
            }

            return View(inquiryType);
        }

        // GET: InquiryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InquiryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,NameInquiry")] InquiryType inquiryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiryType);
        }

        // GET: InquiryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryType = await _context.InquiryTypes.FindAsync(id);
            if (inquiryType == null)
            {
                return NotFound();
            }
            return View(inquiryType);
        }

        // POST: InquiryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,NameInquiry")] InquiryType inquiryType)
        {
            if (id != inquiryType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquiryTypeExists(inquiryType.Id))
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
            return View(inquiryType);
        }

        // GET: InquiryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryType = await _context.InquiryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquiryType == null)
            {
                return NotFound();
            }

            return View(inquiryType);
        }

        // POST: InquiryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquiryType = await _context.InquiryTypes.FindAsync(id);
            _context.InquiryTypes.Remove(inquiryType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquiryTypeExists(int id)
        {
            return _context.InquiryTypes.Any(e => e.Id == id);
        }
    }
}

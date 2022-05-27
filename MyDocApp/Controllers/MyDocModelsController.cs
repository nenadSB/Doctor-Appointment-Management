using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDocApp.Data;
using MyDocApp.Models;

namespace MyDocApp.Controllers
{
    public class MyDocModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyDocModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyDocModels

        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.MyDocModel != null ? 
                          View(await _context.MyDocModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MyDocModel'  is null.");
        }


        /// <summary>
        /// get method
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        /// <summary>
        /// post: myDocModelsController/ShowSearchResults
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase)
        {
            return View("Index", await _context.MyDocModel.Where(j =>
            j.PatientsName.Contains(SearchPhrase)).ToListAsync());
        }




        // GET: MyDocModels/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyDocModel == null)
            {
                return NotFound();
            }

            var myDocModel = await _context.MyDocModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myDocModel == null)
            {
                return NotFound();
            }

            return View(myDocModel);
        }

        // GET: MyDocModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyDocModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientsName,Street,DoctorsName,AppointmentData,PhoneNumber,Email,ZipCode,PainLevel,JPMGnumber,AboutPatient,PatientNetWorth,TreatmentDuration")] MyDocModel myDocModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myDocModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myDocModel);
        }

        // GET: MyDocModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyDocModel == null)
            {
                return NotFound();
            }

            var myDocModel = await _context.MyDocModel.FindAsync(id);
            if (myDocModel == null)
            {
                return NotFound();
            }
            return View(myDocModel);
        }

        // POST: MyDocModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientsName,Street,DoctorsName,AppointmentData,PhoneNumber,Email,ZipCode,PainLevel,JPMGnumber,AboutPatient,PatientNetWorth,TreatmentDuration")] MyDocModel myDocModel)
        {
            if (id != myDocModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myDocModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyDocModelExists(myDocModel.Id))
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
            return View(myDocModel);
        }

        // GET: MyDocModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyDocModel == null)
            {
                return NotFound();
            }

            var myDocModel = await _context.MyDocModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myDocModel == null)
            {
                return NotFound();
            }

            return View(myDocModel);
        }

        // POST: MyDocModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyDocModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyDocModel'  is null.");
            }
            var myDocModel = await _context.MyDocModel.FindAsync(id);
            if (myDocModel != null)
            {
                _context.MyDocModel.Remove(myDocModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        private bool MyDocModelExists(int id)
        {
          return (_context.MyDocModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

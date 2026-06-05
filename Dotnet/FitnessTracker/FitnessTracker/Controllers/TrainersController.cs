
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Models;
using FitnessTracker.Data;

public class TrainersController : Controller
{
    private readonly FitnessTrackerContext _context;

    public TrainersController(FitnessTrackerContext context)
    {
        _context = context;
    }

    // GET: TRAINERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Trainer.ToListAsync());
    }

    // GET: TRAINERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var trainer = await _context.Trainer
            .FirstOrDefaultAsync(m => m.Id == id);
        if (trainer == null)
        {
            return NotFound();
        }

        return View(trainer);
    }

    // GET: TRAINERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TRAINERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Specialization,Trainings")] Trainer trainer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(trainer);
    }

    // GET: TRAINERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var trainer = await _context.Trainer.FindAsync(id);
        if (trainer == null)
        {
            return NotFound();
        }
        return View(trainer);
    }

    // POST: TRAINERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Specialization,Trainings")] Trainer trainer)
    {
        if (id != trainer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(trainer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(trainer.Id))
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
        return View(trainer);
    }

    // GET: TRAINERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var trainer = await _context.Trainer
            .FirstOrDefaultAsync(m => m.Id == id);
        if (trainer == null)
        {
            return NotFound();
        }

        return View(trainer);
    }

    // POST: TRAINERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var trainer = await _context.Trainer.FindAsync(id);
        if (trainer != null)
        {
            _context.Trainer.Remove(trainer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TrainerExists(int? id)
    {
        return _context.Trainer.Any(e => e.Id == id);
    }

    [Route("/trainers/{id:int}")]
    public async Task<IActionResult> SingleTrainer()
    {
        return View("Single");
    }
}

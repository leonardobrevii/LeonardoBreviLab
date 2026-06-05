
using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class TrainingsController : Controller
{
    private readonly FitnessTrackerContext _context;

    public TrainingsController(FitnessTrackerContext context)
    {
        _context = context;
    }

    // GET: TRAININGS
    public async Task<IActionResult> Index(string searchString)
    {
        var trainings = from t in _context.Training
                        select t;

        if (!string.IsNullOrEmpty(searchString))
        {
            trainings = trainings.Where(s => s.Name.Contains(searchString));
        }

        return View(await trainings.ToListAsync());
    }
    // GET: TRAININGS/Create
    public IActionResult Create()
    {
        ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Name");
        return View();
    }

    // POST: TRAININGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Type,Intensity,TrainerId")] Training training)
    {
        if (ModelState.IsValid)
        {
            _context.Add(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(training);
    }

    // GET: TRAININGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var training = await _context.Training.FindAsync(id);
        if (training == null)
        {
            return NotFound();
        }
        return View(training);
    }

    // POST: TRAININGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Type,Intensity,TrainerId")] Training training)
    {
        if (id != training.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(training);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(training.Id))
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
        ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Name", training.TrainerId);
        return View(training);
    }

    // GET: TRAININGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var training = await _context.Training
            .FirstOrDefaultAsync(m => m.Id == id);
        if (training == null)
        {
            return NotFound();
        }

        return View(training);
    }

    // POST: TRAININGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var training = await _context.Training.FindAsync(id);
        if (training != null)
        {
            _context.Training.Remove(training);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TrainingExists(int? id)
    {
        return _context.Training.Any(e => e.Id == id);
    }
}

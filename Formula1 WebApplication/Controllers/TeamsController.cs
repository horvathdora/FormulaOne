using Formula1_WebApplication.DAL;
using Formula1_WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formula1_WebApplication.Controllers
{

    public class TeamsController : Controller
    {
        //private readonly FormulaOneContext _context;
        private readonly ITeamRepository teamRepository;

        public TeamsController( ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        // GET: Teams
        public IActionResult Index()
        {

            return View(teamRepository.List());
        }

        // GET: Teams/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = teamRepository.FindById(id.GetValueOrDefault());
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public  IActionResult Create([Bind("Id,Name,YearOfFoundation,AttainedWorldChampionships,PaidEntryFee")]Team team)
        {
            if (ModelState.IsValid)
            {
                teamRepository.Insert(team);

                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = teamRepository.FindById(id.GetValueOrDefault());
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,YearOfFoundation,AttainedWorldChampionships,PaidEntryFee")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    teamRepository.Edit(id, team);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teamRepository.TeamExists(team.Id))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = teamRepository.FindById(id.GetValueOrDefault());
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            var team = teamRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

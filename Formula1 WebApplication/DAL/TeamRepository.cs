using Formula1_WebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1_WebApplication.DAL
{
    public class TeamRepository : ITeamRepository
    {

        private readonly FormulaOneDbContext db;
        public TeamRepository(FormulaOneDbContext DbContext)
        {
            db = DbContext;
        }

        //csapat törlése ID alapján
        public Team Delete(int teamId)
        {
            var deleteRecord = db.Teams.FirstOrDefault(t => t.Id == teamId);
            if (deleteRecord == null) return null;
            db.Teams.Remove(deleteRecord);
            db.SaveChanges();
            return deleteRecord;
        }

        public Team FindById(int teamId)
        {
            Team selectedTeam = db.Teams.FirstOrDefault(t => t.Id == teamId);
            if (selectedTeam == null)
                return null;
            else
                return selectedTeam;
        }

        //új csapat beszúrása
        public Team Insert(Team value)
        {
            Team newTeam = new Team()
                {
                    Name = value.Name,
                    AttainedWorldChampionships = value.AttainedWorldChampionships,
                    PaidEntryFee = value.PaidEntryFee,
                    YearOfFoundation = value.YearOfFoundation
                };

                db.Teams.Add(newTeam);
                db.SaveChanges();

                return newTeam;
        }

        //csapat módosítása
        public Team Edit(int teamId, Team value)
        {
            Team updatedTeam = new Team()
                {
                    Id = value.Id,
                    AttainedWorldChampionships = value.AttainedWorldChampionships,
                    Name = value.Name,
                    PaidEntryFee = value.PaidEntryFee,
                    YearOfFoundation = value.YearOfFoundation
                };

                db.Teams.Update(updatedTeam);
                db.SaveChanges();


                return updatedTeam;
        }

        public IReadOnlyCollection<Team> List()
        {
            return db.Teams.ToList();
        }

        public bool TeamExists(int id)
        {
            return db.Teams.Any(t => t.Id == id);
        }
    }
}

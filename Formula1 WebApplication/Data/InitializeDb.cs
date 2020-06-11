using Formula1_WebApplication.Models;
using System.Linq;

namespace Formula1_WebApplication.Data
{
    public class InitializeDb
    {
        public static void Initialize(FormulaOneContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //already initialized
            if (!context.Teams.Any())
            {

                var teams = new Team[]
                {
                    new Team{ Name = "Scuderia Ferrari", YearOfFoundation = 1929, AttainedWorldChampionships = 15, PaidEntryFee = true},
                    new Team{ Name = "Red Bull Racing", YearOfFoundation = 2004, AttainedWorldChampionships = 4, PaidEntryFee = true},
                    new Team{ Name = "Mercedes-AMG Petronas", YearOfFoundation = 2010, AttainedWorldChampionships = 8, PaidEntryFee = true},
                    new Team{ Name = "McLaren", YearOfFoundation = 1963, AttainedWorldChampionships = 12, PaidEntryFee = true}
                };

                foreach (Team t in teams)
                {
                    context.Teams.Add(t);
                }
                context.SaveChanges();
            }

            /*
            if (!context.Users.Any())
            {
                var users = new ApplicationUser[]
                {
                    new ApplicationUser{Name = "admin", Password="f1test2018"}
                };
                foreach (ApplicationUser u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }
            */

        }
    }
}

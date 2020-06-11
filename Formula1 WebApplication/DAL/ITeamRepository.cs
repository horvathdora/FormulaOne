using Formula1_WebApplication.Models;
using System.Collections.Generic;

namespace Formula1_WebApplication.DAL
{
    public interface ITeamRepository
    {
        Team FindById(int teamId);
        Team Insert(Team value);
        Team Delete(int teamId);
        Team Edit(int teamId, Team value);
        IReadOnlyCollection<Team> List();
        bool TeamExists(int id);
    }
}

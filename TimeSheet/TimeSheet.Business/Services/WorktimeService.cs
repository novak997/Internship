using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class WorktimeService : IWorktimeService
    {
        private readonly WorktimeRepository _worktimeRepository = new WorktimeRepository();
        public string AddWorktime(Worktime worktime)
        {
            _worktimeRepository.AddWorktime(worktime);
            return "Worktime successfully added";
        }
        public IEnumerable<Worktime> GetWorktimesForUser(int id)
        {
            return _worktimeRepository.GetWorktimesForUser(id);
        }
        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate)
        {
            return _worktimeRepository.FilterReports(user, client, project, category, startDate, endDate);
        }
    }
}

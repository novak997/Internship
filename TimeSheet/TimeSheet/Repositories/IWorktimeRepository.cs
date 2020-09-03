using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Controllers.DTO;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface IWorktimeRepository
    {
        public void AddWorktime(Worktime worktime);
        public IEnumerable<Worktime> GetWorktimesForUser(int id);
        public IEnumerable<Worktime> FilterReports(WorktimeFilterDTO worktimeFilterDTO);
    }
}

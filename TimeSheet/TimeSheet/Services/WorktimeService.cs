using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Controllers.DTO;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class WorktimeService
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
        public IEnumerable<Worktime> FilterReports(WorktimeFilterDTO worktimeFilterDTO)
        {
            return _worktimeRepository.FilterReports(worktimeFilterDTO);
        }
    }
}

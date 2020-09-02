using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface IWorktimeRepository
    {
        public void AddWorktime(Worktime worktime);
        public IEnumerable<Worktime> GetWorktimesForUser(int id);
        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate);
    }
}

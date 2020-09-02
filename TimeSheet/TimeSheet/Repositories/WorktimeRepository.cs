using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using TimeSheet.Context;
using Microsoft.EntityFrameworkCore;

namespace TimeSheet.Repositories
{
    public class WorktimeRepository : IWorktimeRepository
    {
        private readonly DatabaseContext _context;
        public WorktimeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddWorktime(Worktime worktime)
        {
            _context.Database.ExecuteSqlRaw("exec uspAddWorktime {0}, {1}, {2}, {3}, {4}, {5}, {6}", worktime.ClientID, 
                worktime.ProjectID, worktime.CategoryID, worktime.UserID, worktime.Description, worktime.Hours, worktime.Overtime);
            
        }

        public IEnumerable<Worktime> GetWorktimesForUser(int id)
        {
            return _context.Worktimes.FromSqlRaw("exec uspGetWorktimesForUser {0}", id).ToList();
        }

        IEnumerable<Worktime> IWorktimeRepository.FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate)
        {
            return _context.Worktimes.FromSqlRaw("exec uspFilterReports {0}, {1}, {2}, {3}, {4}, {5}", user, client, project, category, startDate, endDate).ToList();
        }
    }
}

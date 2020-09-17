using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface IWorktimeService
    {
        public string AddWorktime(Worktime worktime);
        public string UpdateWorktime(Worktime worktime);
        public IEnumerable<Worktime> GetWorktimesForUser(int id);
        public IEnumerable<Worktime> GetWorktimesForUserAndDate(int id, DateTime date);
        public IEnumerable<object> GetWorktimesMonth(int id, DateTime startDate, DateTime endDate, int month);
        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate);
    }
}

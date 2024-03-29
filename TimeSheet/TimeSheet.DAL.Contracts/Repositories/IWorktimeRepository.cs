﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.Contracts.Repositories
{
    public interface IWorktimeRepository
    {
        public int AddWorktime(Worktime worktime);
        public void UpdateWorktime(Worktime worktime);
        public IEnumerable<Worktime> GetWorktimesForUser(int id);
        public IEnumerable<Worktime> GetWorktimesForUserAndDate(int id, DateTime date);
        public double GetWorktimesTotalHours(int id, DateTime date);
        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate);
    }
}

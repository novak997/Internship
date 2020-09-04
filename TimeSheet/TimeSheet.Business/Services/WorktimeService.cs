using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class WorktimeService : IWorktimeService
    {
        private readonly IWorktimeRepository _worktimeRepository;

        public WorktimeService(IWorktimeRepository worktimeRepository) 
        {
            _worktimeRepository = worktimeRepository;
        }
        public string AddWorktime(Worktime worktime)
        {
            try
            {
                _worktimeRepository.AddWorktime(worktime);
                return "Worktime successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Worktime> GetWorktimesForUser(int id)
        {
            try
            {
                return _worktimeRepository.GetWorktimesForUser(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<Worktime> FilterReports(int user, int client, int project, int category, DateTime startDate, DateTime endDate)
        {
            try
            {
                return _worktimeRepository.FilterReports(user, client, project, category, startDate, endDate);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
    }
}

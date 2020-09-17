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
        private readonly IUserRepository _userRepository;

        public WorktimeService(IWorktimeRepository worktimeRepository, IUserRepository userRepository) 
        {
            _worktimeRepository = worktimeRepository;
            _userRepository = userRepository;
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

        public string UpdateWorktime(Worktime worktime)
        {
            try
            {
                _worktimeRepository.UpdateWorktime(worktime);
                return "Worktime successfully updated";
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

        public IEnumerable<Worktime> GetWorktimesForUserAndDate(int id, DateTime date)
        {
            try
            {
                return _worktimeRepository.GetWorktimesForUserAndDate(id, date);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }

        }

        public IEnumerable<object> GetWorktimesMonth(int id, DateTime startDate, DateTime endDate, int month)
        {
            try
            {
                double sum = 0;
                User user = _userRepository.GetUserById(id);
                List<object> listOfAll = new List<object>();
                DateTime today = DateTime.Today;
                int i = 0;
                while (startDate <= endDate)
                {
                    List<object> list = new List<object>();
                    double totalHours = 0;
                    int status = -1;
                    if (startDate <= today)
                    {
                        totalHours = _worktimeRepository.GetWorktimesTotalHours(id, startDate);
                        if (i < 5)
                        {
                            if (totalHours >= user.Weekly / 5)
                            {
                                status = 1;
                            }
                            else
                            {
                                status = 0;
                            }
                        }
                    }
                    list.Add(startDate);
                    list.Add(totalHours);
                    list.Add(status);
                    listOfAll.Add(list);
                    i = (i + 1) % 7;
                    startDate = startDate.AddDays(1);
                    if (startDate.Month == month)
                    {
                        sum += totalHours;
                    }
                    
                }
                listOfAll.Add(sum);
                return listOfAll;

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

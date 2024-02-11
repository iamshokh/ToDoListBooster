using Microsoft.EntityFrameworkCore;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class TaskListService : StatusGenericHandler, ITaskListService
    {
        private readonly EfCoreContext _context;
        public TaskListService(EfCoreContext context)
        {
            _context = context;
        }

        public void Create(CreateTaskListDto dto)
        {
            try
            {
                var newTaskList = new TaskList()
                {
                    Title = dto.Title,
                    Descrition = dto.Descrition
                };
                _context.TaskLists.Add(newTaskList);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при создании");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var taskList = GetById(id);
                _context.TaskLists.Remove(taskList);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
        }

        public List<TaskList> GetAll(SortFilterDto dto)
        {
            var result = SortFilter(dto);
            return result;
        }

        public void Update(UpdateTaskListDto dto)
        {
            try
            {
                var updateTaskList = GetById(dto.Id);
                updateTaskList.Descrition = dto.Descrition;
                updateTaskList.Title = dto.Title;
                _context.TaskLists.Update(updateTaskList);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
            
        }

        private TaskList GetById(int id)
        {
            var result = _context.TaskLists.FirstOrDefault(a => a.Id == id);
            if(result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }

        private List<TaskList> SortFilter(SortFilterDto dto)
        {
            var result = _context.TaskLists.Include(a => a.TaskItems).ThenInclude(a => a.Comments)
                                           .Include(a => a.TaskItems).ThenInclude(a => a.Status)
                                           .OrderBy(p => p.Id).ToList();

            if (!string.IsNullOrEmpty(dto.Search))
                result = result.Where(a => a.Title.ToLower().Contains(dto.Search.ToLower()) ||
                                           a.Descrition.ToLower().Contains(dto.Search.ToLower())).ToList();

            if (dto.Limit.HasValue && dto.Page.HasValue)
            {
                result = result.Skip(((dto.Page ?? 1) - 1) * dto.Limit ?? 10)
                                              .Take(dto.Limit ?? 10)
                                              .ToList();
            }

            return result;
        }
    }
}

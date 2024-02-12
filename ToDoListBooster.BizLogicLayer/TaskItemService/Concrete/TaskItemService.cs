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

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class TaskItemService : StatusGenericHandler, ITaskItemService
    {
        private readonly EfCoreContext _context;
        public TaskItemService(EfCoreContext context)
        {
            _context = context;
        }
        public void Create(CreateTaskItemDto dto)
        {
            try
            {
                var newTaskList = new TaskItem()
                {
                    Title = dto.Title,
                    Descrition = dto.Descrition,
                    TaskListId = dto.TaskListId,
                    StatusId = StatusIdConst.PENDING
                };
                _context.TaskItems.Add(newTaskList);
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
                _context.TaskItems.Remove(taskList);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
        }

        public List<TaskItem> GetAll(SortFilterDto dto)
        {
            var result = SortFilter(dto);
            return result;
        }

        public void Update(UpdateTaskItemDto dto)
        {
            try
            {
                var updateTaskItem = GetById(dto.Id);
                updateTaskItem.Descrition = dto.Descrition;
                updateTaskItem.Title = dto.Title;
                updateTaskItem.TaskListId = dto.TaskListId;
                _context.TaskItems.Update(updateTaskItem);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
        }

        public void UpdateStatus(UpdateStatusTaskItemDto dto)
        {
            try
            {
                var taskItem = GetById(dto.Id);
                taskItem.StatusId = dto.StatusId;
                _context.TaskItems.Update(taskItem);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при изменении статуса");
            }
        }

        private TaskItem GetById(int id)
        {
            var result = _context.TaskItems.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }

        private List<TaskItem> SortFilter(SortFilterDto dto)
        {
            var result = _context.TaskItems.Include(a => a.TaskList)
                                           .Include(a => a.Comments)
                                           .Include(a => a.Status)
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

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

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public class CommentService : StatusGenericHandler, ICommentService
    {
        private readonly EfCoreContext _context;
        public CommentService(EfCoreContext context)
        {
            _context = context;
        }

        public void Create(CreateCommentDto dto)
        {
            try
            {
                var newComment = new Comment()
                {
                    Tekst = dto.Tekst,
                    TaskItemId = dto.TaskItemId
                };
                _context.Comments.Add(newComment);
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
                var comment = GetById(id);
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
        }

        public List<Comment> GetAll(SortFilterDto dto)
        {
            var result = SortFilter(dto);
            return result;
        }

        public void Update(UpdateCommentDto dto)
        {
            try
            {
                var comment = GetById(dto.Id);
                comment.Tekst = dto.Tekst;
                _context.Comments.Update(comment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                AddError("Ошибка при удалении");
            }
        }

        private Comment GetById(int id)
        {
            var result = _context.Comments.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }

        private List<Comment> SortFilter(SortFilterDto dto)
        {
            var result = _context.Comments.Include(a => a.Tekst)
                                          .Include(a => a.TaskItem)
                                          .OrderBy(p => p.Id).ToList();

            if (!string.IsNullOrEmpty(dto.Search))
                result = result.Where(a => a.Tekst.ToLower().Contains(dto.Search.ToLower())).ToList();

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

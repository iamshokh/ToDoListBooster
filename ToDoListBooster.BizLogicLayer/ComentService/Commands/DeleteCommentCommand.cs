﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public class DeleteCommentCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
    }
}

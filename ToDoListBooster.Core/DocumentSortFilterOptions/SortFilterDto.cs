using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.Core
{
    public class SortFilterDto
    {
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string? Search { get; set; }
    }
}

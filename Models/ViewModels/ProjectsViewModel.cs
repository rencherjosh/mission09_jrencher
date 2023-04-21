using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_jrencher.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Book> Book { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}

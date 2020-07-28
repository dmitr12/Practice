using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pract.Models
{
    public class ArticleContext:DbContext
    {
        public ArticleContext() : base("DefaultConnection") { }

        public DbSet<Article> Articles { get; set; }
    }
}
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Entities.Books
{
    public class Book : FullAuditedEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}

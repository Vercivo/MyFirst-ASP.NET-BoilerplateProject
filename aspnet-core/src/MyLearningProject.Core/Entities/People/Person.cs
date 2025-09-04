using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Entities.People
{
    public class Person : FullAuditedEntity<int>
    {
        public string FullName { get; set; }
        public string Age { get; set; }
    }
}

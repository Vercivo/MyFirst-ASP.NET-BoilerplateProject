using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyLearningProject.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Enitities.People.Dto
{
    [AutoMapFrom(typeof(Person)), AutoMapTo(typeof(Person))]
    public class PersonDto : EntityDto<int>
    {
        public string FullName { get; set; }
        public string Age { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Entities.Books.Dto
{
    [AutoMapFrom(typeof(Book)), AutoMapTo(typeof(Book))]
    public class BookDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}

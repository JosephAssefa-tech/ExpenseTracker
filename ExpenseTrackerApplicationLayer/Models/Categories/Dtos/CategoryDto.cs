using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerApplicationLayer.Models.Categories.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public Guid? UserId { get; set; }

        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

    }
}

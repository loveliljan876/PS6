using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Areas.Data.Models
{
    public class YearValidationResult
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Result { get; set; }
        public DateTime TimeAdded { get; set; }
        public string? UserLogin { get; set; }
        public string? UserId { get; set; }

    }
}

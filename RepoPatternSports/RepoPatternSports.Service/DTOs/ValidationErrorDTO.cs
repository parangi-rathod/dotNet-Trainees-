using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.DTOs
{
    public class ValidationErrorDTO
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } // Change the type to List<string>

        public ValidationErrorDTO()
        {
            Errors = new List<string>();
        }
    }
}

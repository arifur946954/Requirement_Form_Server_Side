using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Cvtable
    {
        public decimal CvId { get; set; }
        public string? Name { get; set; }
        public byte[]? Cv { get; set; }
        public decimal? EmpId { get; set; }
    }
}

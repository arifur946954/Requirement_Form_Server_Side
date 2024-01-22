using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Imagetbl
    {
        public decimal ImgId { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public decimal? EmpId { get; set; }
    }
}

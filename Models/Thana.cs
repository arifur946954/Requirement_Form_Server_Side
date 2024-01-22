using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Thana
    {
        public decimal ThanaId { get; set; }
        public decimal DisId { get; set; }
        public string Name { get; set; } = null!;
        public string BnName { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual District Dis { get; set; } = null!;
    }
}

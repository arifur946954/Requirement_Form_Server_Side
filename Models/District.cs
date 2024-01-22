using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class District
    {
        public District()
        {
            Thanas = new HashSet<Thana>();
        }

        public decimal DisId { get; set; }
        public decimal DivId { get; set; }
        public string Name { get; set; } = null!;
        public string BnName { get; set; } = null!;
        public string? Lat { get; set; }
        public string? Ion { get; set; }
        public string Url { get; set; } = null!;

        public virtual Division Div { get; set; } = null!;
        public virtual ICollection<Thana> Thanas { get; set; }
    }
}

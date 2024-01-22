using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Division
    {
        public Division()
        {
            Districts = new HashSet<District>();
        }

        public decimal DivId { get; set; }
        public string Name { get; set; } = null!;
        public string BnName { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual ICollection<District> Districts { get; set; }
    }
}

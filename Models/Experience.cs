using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Experience
    {
        public decimal ExpId { get; set; }
        public string? Post { get; set; }
        public string? Organization { get; set; }
        public string? Joblocation { get; set; }
        public decimal? Selery { get; set; }
        public string? Reportingto { get; set; }
        public string? Defaultproduct { get; set; }
        public decimal? EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}

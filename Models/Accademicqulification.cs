using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RequirementForm.Models
{
    public partial class Accademicqulification
    {
        public decimal AccQlfId { get; set; }
        public string? Degree { get; set; }
        public string? Board { get; set; }
        public string? Instution { get; set; }
        public string? Major { get; set; }
        public decimal? Result { get; set; }
        public decimal? Passingyear { get; set; }
        public decimal? EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}

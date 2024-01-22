using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Parmanentaddress
    {
        public decimal ParmanentAddId { get; set; }
        public string? Division { get; set; }
        public string? District { get; set; }
        public string? Thana { get; set; }
        public string? Postoffice { get; set; }
        public string? Village { get; set; }
        public string? Password { get; set; }
        public decimal? EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}

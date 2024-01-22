﻿using System;
using System.Collections.Generic;

namespace RequirementForm.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accademicqulifications = new HashSet<Accademicqulification>();
            Experiences = new HashSet<Experience>();
            Parmanentaddresses = new HashSet<Parmanentaddress>();
            Presentaddresses = new HashSet<Presentaddress>();
        }

        public decimal EmployeeId { get; set; }
        public string? Mobilenumber { get; set; }
        public string? Name { get; set; }
        public string? Fathername { get; set; }
        public string? Mothername { get; set; }
        public string? Nid { get; set; }
        public DateTime? Dateofbirthd { get; set; }
        public string? Birthplace { get; set; }
        public string? Religion { get; set; }
        public string? Bloodgroup { get; set; }
        public string? Gender { get; set; }
        public string? Maritalstatus { get; set; }
        public string? Spousename { get; set; }
        public string? Email { get; set; }
        public DateTime? Interviewdate { get; set; }
        public string? Appliedpost { get; set; }
        public DateTime? Probablyjoiningdate { get; set; }
        public string? Expectedselery { get; set; }
        public string? Appliedby { get; set; }

        public virtual ICollection<Accademicqulification> Accademicqulifications { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Parmanentaddress> Parmanentaddresses { get; set; }
        public virtual ICollection<Presentaddress> Presentaddresses { get; set; }
    }
}

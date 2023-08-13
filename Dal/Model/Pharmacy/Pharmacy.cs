﻿using Dal.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model.Pharmacy
{
    [Table("pharmacies")]
    public class Pharmacy : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public int FilledPrescriptions { get; set; }
    }
}

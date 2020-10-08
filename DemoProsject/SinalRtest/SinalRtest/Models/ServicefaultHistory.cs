using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinalRtest.Models
{
    public class ServicefaultHistory
    {
        [Key]
        public int Id { get; set; }
        public int TmsId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? FaultTime { get; set; }
        public string Description { get; set; }
    }
}
